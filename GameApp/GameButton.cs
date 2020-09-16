using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GameLogic;

namespace GameApp
{
	public class GameButton : Button
	{
		private readonly int r_GuessLineIndex;
		public GameButton(int i_GuessLineIndex)
		{
			r_GuessLineIndex = i_GuessLineIndex;
		}

		public int GuessLineIndex
		{
			get
			{
				return r_GuessLineIndex;
			}
		}
	}
}
