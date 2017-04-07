﻿using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML_Engine.Engine.IO;

namespace SFML_Engine.Engine
{
    public class PlayerController : Transformable, ITickable
    {
        public string Name { get; set; } = "PlayerController";
        public uint ID { get; internal set; } = 0;
        public View PlayerCamera { get; set; } = new View();

        public bool ReceiveInput { get; set; } = true;

        public SpriteActor PlayerPawn { get; set; }

		public InputManager Input { get; set; }

        public PlayerController()
        {
        }

        public PlayerController(SpriteActor playerPawn)
        {
            PlayerPawn = playerPawn;
        }

        public virtual void RegisterInput(Engine engine)
        {
	        Input = engine.InputManager;

			Input.RegisterInput(OnMouseButtonPressed, OnMouseButtonReleased, OnMouseMoved, OnMouseScrolled, 
				OnKeyPressed, OnKeyReleased, OnJoystickConnected, OnJoystickDisconnected, OnJoystickButtonPressed, OnJoystickButtonReleased, OnJoystickMoved,
				OnTouchBegan, OnTouchEnded, OnTouchMoved);
		}

		protected virtual void OnMouseButtonPressed(object sender, MouseButtonEventArgs mouseButtonEventArgs)
		{
			//Console.WriteLine("PlayerController: " + Name + "-" + ID + " Input Event: Mouse Button Pressed: " + mouseButtonEventArgs.Button + " at X: " + mouseButtonEventArgs.X + " Y: " + mouseButtonEventArgs.Y);
		}

		protected virtual void OnMouseButtonReleased(object sender, MouseButtonEventArgs mouseButtonEventArgs)
		{
			//Console.WriteLine("PlayerController: " + Name + "-" + ID + " Input Event: Mouse Button Released: " + mouseButtonEventArgs.Button + " at X: " + mouseButtonEventArgs.X + " Y: " + mouseButtonEventArgs.Y);
		}

		protected virtual void OnMouseMoved(object sender, MouseMoveEventArgs mouseMoveEventArgs)
		{
			//Console.WriteLine("PlayerController: " + Name + "-" + ID + " Input Event: Mouse Moved to X: " + mouseMoveEventArgs.X + " Y: " + mouseMoveEventArgs.Y);
		}

		protected virtual void OnMouseScrolled(object sender, MouseWheelScrollEventArgs mouseWheelScrollEventArgs)
		{
			//Console.WriteLine("PlayerController: " + Name + "-" + ID + " Input Event: Mouse Scrolled Wheel: " + mouseWheelScrollEventArgs.Wheel + " at X: " + mouseWheelScrollEventArgs.X + " Y: " + mouseWheelScrollEventArgs.Y + " by Scroll Amount: " + mouseWheelScrollEventArgs.Delta);
		}

		protected virtual void OnKeyPressed(object sender, KeyEventArgs keyEventArgs)
        {
           //Console.WriteLine("PlayerController: " + Name + "-" + ID + " Input Event: Keyboard Key Pressed: " + keyEventArgs.Code);
		}

		protected virtual void OnKeyReleased(object sender, KeyEventArgs keyEventArgs)
		{
			//Console.WriteLine("PlayerController: " + Name + "-" + ID + " Input Event: Keyboard Key Released: " + keyEventArgs.Code);
		}

		protected virtual void OnJoystickConnected(object sender, JoystickConnectEventArgs joystickConnectEventArgs)
		{
			//Console.WriteLine("PlayerController: " + Name + "-" + ID + " Input Event: Joystick Connected: ID: " + joystickConnectEventArgs.JoystickId);
		}

		protected virtual void OnJoystickDisconnected(object sender, JoystickConnectEventArgs joystickConnectEventArgs)
		{
			//Console.WriteLine("PlayerController: " + Name + "-" + ID + " Input Event: Joystick Disconnected: ID: " + joystickConnectEventArgs.JoystickId);
		}

		protected virtual void OnJoystickButtonPressed(object sender, JoystickButtonEventArgs joystickButtonEventArgs)
		{
			//Console.WriteLine("PlayerController: " + Name + "-" + ID + " Input Event: Joystick Button Pressed: ID: " + joystickButtonEventArgs.JoystickId + " Button: " + joystickButtonEventArgs.Button);
		}

		protected virtual void OnJoystickButtonReleased(object sender, JoystickButtonEventArgs joystickButtonEventArgs)
		{
			//Console.WriteLine("PlayerController: " + Name + "-" + ID + " Input Event: Joystick Button Released: ID: " + joystickButtonEventArgs.JoystickId + " Button: " + joystickButtonEventArgs.Button);
		}

		protected virtual void OnJoystickMoved(object sender, JoystickMoveEventArgs joystickMoveEventArgs)
		{
			//Console.WriteLine("PlayerController: " + Name + "-" + ID + " Input Event: Joystick Moved: ID: " + joystickMoveEventArgs.JoystickId + " Axis: " + joystickMoveEventArgs.Axis + " to Position: " + joystickMoveEventArgs.Position);
		}

		protected virtual void OnTouchBegan(object sender, TouchEventArgs touchEventArgs)
		{
			//Console.WriteLine("PlayerController: " + Name + "-" + ID + " Input Event: Touch Pressed: Finger: " + touchEventArgs.Finger + " at X: " + touchEventArgs.X + " Y: " + touchEventArgs.Y);
		}

		protected virtual void OnTouchEnded(object sender, TouchEventArgs touchEventArgs)
		{
			//Console.WriteLine("PlayerController: " + Name + "-" + ID + " Input Event: Touch Released: Finger: " + touchEventArgs.Finger + " at X: " + touchEventArgs.X + " Y: " + touchEventArgs.Y);
		}

		protected virtual void OnTouchMoved(object sender, TouchEventArgs touchEventArgs)
		{
			//Console.WriteLine("PlayerController: " + Name + "-" + ID + " Input Event: Touch Moved: Finger: " + touchEventArgs.Finger + " to X: " + touchEventArgs.X + " Y: " + touchEventArgs.Y);
		}

		public virtual void Tick(float deltaTime)
        {
            if (PlayerPawn != null)
            {
                
            }
        }
    }
}