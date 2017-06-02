﻿using System;
using SFML.Graphics;
using SFML.System;
using SFML_Engine.Engine.Core;
using SFML_Engine.Engine.Game;
using SFML_Engine.Engine.Graphics;
using SFML_Engine.Engine.Physics;
using SFML_Engine.Engine.Utility;
using VelcroPhysics.Dynamics;

namespace TestProject
{
	class TestProgram
	{
		static void Main(string[] args)
		{

			Engine engine = Engine.Instance;
			engine.EngineWindowWidth = 800;
			engine.EngineWindowHeight = 800;
			engine.InitEngine();


			var level = new Level();
			var physics = level.PhysicsEngine;
			physics.Gravity = new Vector2f(9.81f, 0.0f);

			// Creates a SpriteActor 
			var spriteActor = new SpriteActor(new Sprite(new Texture("Assets/TestProject/TestSprite.png")), level);
			spriteActor.GetRootComponent<PhysicsComponent>().CollisionResponseChannels &=
				~VelcroPhysics.Collision.Filtering.Category.Cat1;
			spriteActor.GetRootComponent<PhysicsComponent>().CollisionBody.GravityScale *= -1;

			// This is a normal actor that is equivalent to the spriteActor above but is manually composed.
			var spriteActor2 = new Actor(level);
			var spriteComponent = new SpriteComponent(new Sprite(new Texture("Assets/TestProject/TestSprite.png")));
			physics.ConstructRectangleCollisionComponent(spriteActor2, true, new TVector2f(0.0f, 0.0f), 0.0f, new TVector2f(1.0f, 1.0f), 1.0f, spriteComponent.ComponentBounds, BodyType.Dynamic);
			spriteActor2.AddComponent(spriteComponent);
			spriteActor2.GetRootComponent<PhysicsComponent>().Visible = false;
			spriteActor2.GetRootComponent<PhysicsComponent>().CollisionResponseChannels &=
				~VelcroPhysics.Collision.Filtering.Category.Cat1;
			spriteActor2.Origin = spriteComponent.Origin;

			var leftBorder = new Actor(level);
			physics.ConstructRectangleCollisionComponent(leftBorder, true, new TVector2f(-450.0f, 0.0f), 0.0f, new TVector2f(1.0f, 1.0f), 0.0f, new TVector2f(50.0f,400.0f), BodyType.Static);
			leftBorder.GetRootComponent<PhysicsComponent>().CollisionType = VelcroPhysics.Collision.Filtering.Category.Cat2;
			leftBorder.Visible = false;

			var rightBorder = new Actor(level);
			physics.ConstructRectangleCollisionComponent(rightBorder, true, new TVector2f(450.0f, 0.0f), 0.0f, new TVector2f(1.0f, 1.0f), 0.0f, new TVector2f(50.0f, 400.0f), BodyType.Static);
			rightBorder.Visible = false;

			var topBorder = new Actor(level);
			physics.ConstructRectangleCollisionComponent(topBorder, true, new TVector2f(0.0f, -450.0f), 0.0f, new TVector2f(1.0f, 1.0f), 0.0f, new TVector2f(400.0f, 50.0f), BodyType.Static);
			topBorder.Visible = false;

			var bottomBorder = new Actor(level);
			physics.ConstructRectangleCollisionComponent(bottomBorder, true, new TVector2f(0.0f, 450.0f), 0.0f, new TVector2f(1.0f, 1.0f), 0.0f, new TVector2f(400.0f, 50.0f), BodyType.Static);
			bottomBorder.Visible = false;
			/*
var testActor = new Actor();
var collisionShape = new BoxShape(50.0f);
var component = physics.ConstructCollisionComponent(1.0f, new Vector2f(0.0f, 0.0f), 43.0f, collisionShape, (short)CollisionTypes.Default);
component.CollisionBody.AngularVelocity = EngineMath.DegreesToRadians(30);
component.CollisionCallbacksEnabled = false;
testActor.SetRootComponent(component);

var bottomBorder = new Actor();
var bottomColShape = new BoxShape(200.0f, 10.0f, 50.0f);
var bottomComponent = physics.ConstructCollisionComponent(0.0f, new Vector2f(0.0f, 210.0f), 0.0f, bottomColShape, (short)CollisionTypes.Default);
bottomBorder.SetRootComponent(bottomComponent);

var topBorder = new Actor();
var topColShape = new BoxShape(200.0f, 10.0f, 50.0f);
var topComponent = physics.ConstructCollisionComponent(0.0f, new Vector2f(0.0f, -210.0f), 0.0f, topColShape, (short)CollisionTypes.Default);
topBorder.SetRootComponent(topComponent);

var leftBorder = new Actor();
var leftColShape = new BoxShape(10.0f, 200.0f, 50.0f);
var leftComponent = physics.ConstructCollisionComponent(0.0f, new Vector2f(-210.0f, 0.0f), 0.0f, leftColShape, (short)CollisionTypes.Default);
leftBorder.SetRootComponent(leftComponent);

var rightBorder = new Actor();
var rightColShape = new BoxShape(10.0f, 200.0f, 50.0f);
var rightComponent = physics.ConstructCollisionComponent(0.0f, new Vector2f(210.0f, 0.0f), 0.0f, rightColShape, (short)CollisionTypes.Default);
rightBorder.SetRootComponent(rightComponent);*/

			var player = new TestPlayerController();
			player.SetCameraSize(800);
			level.RegisterActor(spriteActor);
			level.RegisterActor(spriteActor2);
			//level.RegisterActor(testActor);
			level.RegisterActor(leftBorder);
			level.RegisterActor(rightBorder);
			level.RegisterActor(topBorder);
			level.RegisterActor(bottomBorder);
			level.RegisterPlayer(player);
			engine.LoadLevel(level);

			engine.StartEngine();
			Console.ReadLine();
		}
	}
}
