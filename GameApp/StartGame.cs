using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameApp
{
	public partial class StartGame : Form
	{
		private const string k_FormText = "Bool Pgia";
		private readonly Button r_ButtonStartGame = new Button();
		private const string k_ButtonStartGameText = "Start";
		private readonly Button r_ButtonNumOfChances = new Button();
		private const string k_ButtonNumOfChancesText = "Number of chances: {0}";
		private int m_NumOfChances = 4;

		public StartGame()
		{
			Size = new Size(250, 125);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			StartPosition = FormStartPosition.CenterScreen;
			Text = k_FormText;
			this.AutoSize = true;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			initControls();
		}
		private void initControls()
		{
			r_ButtonNumOfChances.Width = 230;
			r_ButtonNumOfChances.Height = 25;
			r_ButtonNumOfChances.Location = new Point(12, 21);
			r_ButtonNumOfChances.Text = string.Format(k_ButtonNumOfChancesText, m_NumOfChances);
			r_ButtonStartGame.Location = new Point(153, 90);
			r_ButtonStartGame.Text = k_ButtonStartGameText;
			Controls.AddRange(new Control[] { r_ButtonStartGame, r_ButtonNumOfChances });
			r_ButtonStartGame.Click += m_startGameButton_Click;
			r_ButtonNumOfChances.Click += m_buttonNumOfGuesses_Click;
		}
		private void m_startGameButton_Click(object sender, EventArgs i_EventArgs)
		{
			GameBoard boardGame = new GameBoard(m_NumOfChances);
			Hide();
			boardGame.ShowDialog();
		}

		private void m_buttonNumOfGuesses_Click(object sender, EventArgs i_EventArgs)
		{
			if (m_NumOfChances != 10)
				m_NumOfChances++;
			else
				m_NumOfChances = 4;
			r_ButtonNumOfChances.Text = string.Format(k_ButtonNumOfChancesText, m_NumOfChances);
		}
	}
}
