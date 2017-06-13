﻿using SFML.Window;
using SFML_Engine.Engine.Game;
using SFML_Engine.Engine.Graphics;
using SFML_Engine.Engine.Utility;
using SFML_SpaceSEM.Game.Actors;

namespace SFML_SpaceSEM.Game.Players
{
	public class SpaceGamePlayerController : PlayerController
	{
		private uint _score = 0;
		public SpaceShipPlayer Player { get; set; }
		public TextActor ScoreHUD { get; set; } = null;

		public uint Score
		{
			get => _score;
			set
			{
				_score = value;
				ScoreHUD.TextComp.RenderText.DisplayedString = "Highscore: " + _score;
			}
		}

		public SpaceGamePlayerController()
		{
		}

		public SpaceGamePlayerController(SpriteActor playerPawn) : base(playerPawn)
		{
			Player = playerPawn as SpaceShipPlayer;
			Player.ControllerRef = this;
		}

		public override void RegisterInput()
		{
			base.RegisterInput();
		}

		public override void UnregisterInput()
		{
			base.UnregisterInput();
		}

		public override void OnMouseButtonPressed(object sender, MouseButtonEventArgs mouseButtonEventArgs)
		{
			if (Input.MouseLeftPressed)
			{
				Player.FireWeapons();
			}
		}

		public override void OnKeyPressed(object sender, KeyEventArgs keyEventArgs)
		{
			if (Input.IsKeyPressed(Keyboard.Key.Escape))
			{
				LevelReference.EngineReference.LoadPreviousLevel(true);
			}
		}

		public override void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
		{
			if (Input.IsKeyDown(Keyboard.Key.Space))
			{
				Player.FireWeapons();
			}
			if (Input.IsKeyDown(Keyboard.Key.A))
			{
				Player.Velocity = Input.IsKeyDown(Keyboard.Key.LShift) ? new TVector2f(-200.0f, 0.0f) : new TVector2f(-400.0f, 0.0f);
			}
			if (Input.IsKeyDown(Keyboard.Key.D))
			{
				Player.Velocity = Input.IsKeyDown(Keyboard.Key.LShift) ? new TVector2f(200.0f, 0.0f) : new TVector2f(400.0f, 0.0f);
			}
		}

		public override void OnKeyReleased(object sender, KeyEventArgs keyEventArgs)
		{
			if (!Input.IsKeyDown(Keyboard.Key.A) || !Input.IsKeyDown(Keyboard.Key.D))
			{
				Player.Velocity = new TVector2f();
			}
		}

		public override void Tick(float deltaTime)
		{
			base.Tick(deltaTime);
		}

		public override void OnGameStart()
		{
			base.OnGameStart();
			ScoreHUD = LevelReference.FindActorInLevel<TextActor>("Highscore");
		}

		public override void OnGamePause()
		{
			base.OnGamePause();
		}

		public override void OnGameResume()
		{
			base.OnGameResume();
		}

		public override void OnGameEnd()
		{
			base.OnGameEnd();
		}
	}
}