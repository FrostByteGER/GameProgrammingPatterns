using SFML.Graphics;
using SFML_Engine.Engine.Game;
using SFML_Engine.Engine.Graphics;
using SFML_TowerDefense.Source.Game.Core;

namespace SFML_TowerDefense.Source.Game.Buildings
{
	public class TDNexus : TDBuilding
	{

		public uint NexusID { get; set; } = 0;
		public TDNexusState NexusState { get; set; } = TDNexusState.Alive;
		public TDNexus(Level level) : base(level)

		{
			var nexusSprite = new SpriteComponent(new Sprite(level.EngineReference.AssetManager.LoadTexture("Nexus")));
			SetRootComponent(nexusSprite);
			Origin = nexusSprite.Origin;
		}

		public override void ApplyDamage(TDActor instigator, int damage)
		{
			if (NexusState == TDNexusState.Dead) return;
			base.ApplyDamage(instigator, damage);
			if (damage >= Health)
			{
				Health = 0;
				NexusState = TDNexusState.Dead;
				if(TDGameModeRef.NexusLost.Status != SFML.Audio.SoundStatus.Playing) TDGameModeRef.NexusLost.Play();
				CanTick = false;
			}
			else
			{
				Health -= (uint)damage;
				if (TDGameModeRef.NexusUnderAttack.Status != SFML.Audio.SoundStatus.Playing) TDGameModeRef.NexusUnderAttack.Play();
			}
			
		}


		public override void Tick(float deltaTime)
		{
			base.Tick(deltaTime);
		}
	}

	public enum TDNexusState
	{
		Alive,
		Dead
	}
}