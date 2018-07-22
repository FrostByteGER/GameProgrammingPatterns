﻿using SFML_Engine.Engine.JUI;
using SFML_Roguelike.Source.Game.TileMap;

namespace SFML_Roguelike.Source.GUI
{
	public class TileElement : JCheckbox
	{

		public RTile tile;

		public TileElement(JGUI gui) : base(gui)
		{
		}
	}
}