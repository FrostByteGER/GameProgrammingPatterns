﻿using SFML_Engine.Engine.Game;
using SFML_Engine.Engine.Utility;

namespace SFML_TowerDefense.Source.Game
{
	public class TDActor : Actor
	{

		public TDLevel TDLevelRef { get; private set; } = null;

		public TDActor(Level level) : base(level)
		{
			TDLevelRef = level as TDLevel;
		}


	}
}