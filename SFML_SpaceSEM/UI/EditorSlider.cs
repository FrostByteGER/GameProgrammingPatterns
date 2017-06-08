﻿using SFML_Engine.Engine.JUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace SFML_SpaceSEM.UI
{
	public class EditorSlider : JSlider
	{

		public JLabel LinkedLable { set; get; }

		public EditorSlider(JGUI gui) : base(gui)
		{
		}

		public override void Drag(object sender, Vector2i position)
		{
			base.Drag(sender, position);

			if (LinkedLable != null)
			{
				LinkedLable.setTextString("Time :"+((int)(600*SliderValue)).ToString());
			}
		}
	}
}
