using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameApp
{
	public partial class QuitGame : Form
	{
		private const string k_FormText = "Bool Pgia";
		private readonly string r_QuitGameText;
		private Button m_ButtonQuitGame;
		private const string k_ClickToExit = "exit";

		public QuitGame(string i_QuitGameText)
		{
			Text = k_FormText;
			Size = new Size(420, 190);
			r_QuitGameText = i_QuitGameText;
			FormBorderStyle = FormBorderStyle.FixedDialog;
			StartPosition = FormStartPosition.CenterScreen;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			initControls();
		}

		private void initControls()
		{
			m_ButtonQuitGame = new Button();
			m_ButtonQuitGame.Text = r_QuitGameText + k_ClickToExit;
			m_ButtonQuitGame.Location = new Point(50, 50);
			m_ButtonQuitGame.Height = 40;
			m_ButtonQuitGame.Width = 300;
			m_ButtonQuitGame.Click += buttonQuitGame_Click;
			Controls.Add(m_ButtonQuitGame);
		}

		private void buttonQuitGame_Click(object sender, EventArgs i_EventArgs)
		{
			Application.Exit();
		}
	}
}
