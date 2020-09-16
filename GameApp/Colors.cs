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
	public class Colors
	{
		private readonly Dictionary<char, Color> r_OptionalColors;

		public Colors()
		{
			r_OptionalColors = new Dictionary<char, Color>();
			r_OptionalColors.Add('A', Color.Pink);
			r_OptionalColors.Add('B', Color.Red);
			r_OptionalColors.Add('C', Color.LimeGreen);
			r_OptionalColors.Add('D', Color.Cyan);
			r_OptionalColors.Add('E', Color.Blue);
			r_OptionalColors.Add('F', Color.Yellow);
			r_OptionalColors.Add('G', Color.SaddleBrown);
			r_OptionalColors.Add('H', Color.White);
		}

		public List<Color> GetColorsList(GameGuess i_GameGuess)
		{
			List<Color> colorsList = new List<Color>();
			foreach (char letter in i_GameGuess.SequenceOfRandomLetters)
			{
				colorsList.Add(r_OptionalColors[letter]);
			}
			return colorsList;
		}

		public string CreateUserGuess(List<GameButton> i_ColorButtonsList)
		{
			StringBuilder guessedletters = new StringBuilder();
			foreach (GameButton colorButton in i_ColorButtonsList)
			{
				switch (colorButton.BackColor.Name)
				{
					case "Pink":
						guessedletters.Append('A');
						break;
					case "Red":
						guessedletters.Append('B');
						break;
					case "LimeGreen":
						guessedletters.Append('C');
						break;
					case "Cyan":
						guessedletters.Append('D');
						break;
					case "Blue":
						guessedletters.Append('E');
						break;
					case "Yellow":
						guessedletters.Append('F');
						break;
					case "SaddleBrown":
						guessedletters.Append('G');
						break;
					case "White":
						guessedletters.Append('H');
						break;
				}
			}
			return guessedletters.ToString();
		}
	}
}
