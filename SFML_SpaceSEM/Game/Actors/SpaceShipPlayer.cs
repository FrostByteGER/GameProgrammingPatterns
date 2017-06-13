using SFML.Graphics;
using SFML_Engine.Engine.Events;
using SFML_Engine.Engine.Game;
using SFML_Engine.Engine.Graphics;
using SFML_Engine.Engine.IO;
using SFML_Engine.Engine.Utility;
using SFML_SpaceSEM.Game.Players;
using VelcroPhysics.Collision.ContactSystem;
using VelcroPhysics.Dynamics;

namespace SFML_SpaceSEM.Game.Actors
{
	public class SpaceShipPlayer : SpaceShipActor
	{

		public SpaceGamePlayerController ControllerRef { get; set; } = null;
		public TextActor HealthpointsHUD { get; set; } = null;

		public override uint Healthpoints
		{
			get => base.Healthpoints;
			set
			{
				base.Healthpoints = value;
				if(HealthpointsHUD != null) HealthpointsHUD.TextComp.RenderText.DisplayedString = "Health: " + base.Healthpoints;
			}
		}


		public SpaceShipPlayer(Sprite sprite, Level level) : base(sprite, level)
		{
			MaxVelocity = new TVector2f(600);
			var weapon1 = new WeaponComponent(new Sprite());
			var weapon2 = new WeaponComponent(new Sprite());
			weapon1.LocalPosition += new TVector2f(26.0f, 15.0f);
			weapon2.LocalPosition += new TVector2f(-26.0f, 15.0f);
			AddComponent(weapon1);
			AddComponent(weapon2);
			WeaponSystems.Add(weapon1);
			WeaponSystems.Add(weapon2);
			CollisionCallbacksEnabled = true;
		}

		public override void OnGameStart()
		{
			base.OnGameStart();
			HealthpointsHUD = LevelReference.FindActorInLevel<TextActor>("Health");
			HealthpointsHUD.TextComp.RenderText.DisplayedString = "Health: " + Healthpoints;
		}

		public override void FireWeapons()
		{
			foreach (var weapon in WeaponSystems)
			{
				weapon.OnFire();
			}
		}

		public override void OnDeath()
		{
			var engineRef = LevelReference.EngineReference;
			var killSound = engineRef.AssetManager.AudioManager.LoadSound(SoundPoolManager.SFXPath + "SFX_Explosion_01.ogg");
			killSound.Volume = engineRef.GlobalSoundVolume;
			killSound.Play();
			LevelReference.DestroyActor(this);
			engineRef.RegisterEvent(new SwitchLevelEvent<SwitchLevelParams>(new SwitchLevelParams(this, engineRef.LevelStack[0], true)));
		}

		public override void OnCollide(Fixture self, Fixture other, Contact contactInfo)
		{
			var otherComp = other.Body.UserData as ActorComponent;
			var otherActor = otherComp?.ParentActor as SpaceBullet;
			if (otherActor != null)
			{
				Healthpoints -= otherActor.Damage;
				if (Healthpoints <= 0)
				{
					OnDeath();
				}
			}
		}
	}
}