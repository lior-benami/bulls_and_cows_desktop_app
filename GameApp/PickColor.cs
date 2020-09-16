using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameApp
{
	public partial class PickColor : Form
	{
		private Color m_ColorPicked;
		private Button m_ButtonPink;
		private Button m_ButtonRed;
		private Button m_ButtonLimeGreen;
		private Button m_ButtonCyan;
		private Button m_ButtonBlue;
		private Button m_ButtonYellow;
		private Button m_ButtonSaddleBrown;
		private Button m_ButtonWhite;
		private const string k_FormText = "Pick A Color:";
		private const int k_ColorButtonSize = 50;
		public PickColor()
		{
			Text = k_FormText;
			Size = new Size(300, 190);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			StartPosition = FormStartPosition.CenterScreen;
			initControls();
		}

		protected override void OnLoad(EventArgs i_EventArgs)
		{
			base.OnLoad(i_EventArgs);
		}

		private void initControls()
		{
			m_ButtonPink = new Button();
			m_ButtonPink.Location = new Point(15, 15);
			m_ButtonPink.Width = k_ColorButtonSize;
			m_ButtonPink.Height = k_ColorButtonSize;
			m_ButtonPink.BackColor = Color.Pink;

			m_ButtonRed = new Button();
			m_ButtonRed.Location = new Point(m_ButtonPink.Right + 10, 15);
			m_ButtonRed.Width = k_ColorButtonSize;
			m_ButtonRed.Height = k_ColorButtonSize;
			m_ButtonRed.BackColor = Color.Red;

			m_ButtonLimeGreen = new Button();
			m_ButtonLimeGreen.Location = new Point(m_ButtonRed.Right + 10, 15);
			m_ButtonLimeGreen.Width = k_ColorButtonSize;
			m_ButtonLimeGreen.Height = k_ColorButtonSize;
			m_ButtonLimeGreen.BackColor = Color.LimeGreen;

			m_ButtonCyan = new Button();
			m_ButtonCyan.Location = new Point(m_ButtonLimeGreen.Right + 10, 15);
			m_ButtonCyan.Width = k_ColorButtonSize;
			m_ButtonCyan.Height = k_ColorButtonSize;
			m_ButtonCyan.BackColor = Color.Cyan;

			m_ButtonBlue = new Button();
			m_ButtonBlue.Location = new Point(15, m_ButtonPink.Bottom + 10);
			m_ButtonBlue.Width = k_ColorButtonSize;
			m_ButtonBlue.Height = k_ColorButtonSize;
			m_ButtonBlue.BackColor = Color.Blue;

			m_ButtonYellow = new Button();
			m_ButtonYellow.Location = new Point(m_ButtonBlue.Right + 10, m_ButtonRed.Bottom + 10);
			m_ButtonYellow.Width = k_ColorButtonSize;
			m_ButtonYellow.Height = k_ColorButtonSize;
			m_ButtonYellow.BackColor = Color.Yellow;

			m_ButtonSaddleBrown = new Button();
			m_ButtonSaddleBrown.Location = new Point(m_ButtonYellow.Right + 10, m_ButtonLimeGreen.Bottom + 10);
			m_ButtonSaddleBrown.Width = k_ColorButtonSize;
			m_ButtonSaddleBrown.Height = k_ColorButtonSize;
			m_ButtonSaddleBrown.BackColor = Color.SaddleBrown;

			m_ButtonWhite = new Button();
			m_ButtonWhite.Location = new Point(m_ButtonSaddleBrown.Right + 10, m_ButtonCyan.Bottom + 10);
			m_ButtonWhite.Width = k_ColorButtonSize;
			m_ButtonWhite.Height = k_ColorButtonSize;
			m_ButtonWhite.BackColor = Color.White;

			Controls.AddRange(new Control[] { m_ButtonPink, m_ButtonRed, m_ButtonLimeGreen, m_ButtonCyan,
				m_ButtonBlue, m_ButtonYellow , m_ButtonSaddleBrown, m_ButtonWhite });

			foreach (Control colorButton in Controls)
			{
				colorButton.Click += buttonColor_Click;
			}
		}

		private void buttonColor_Click(object sender, EventArgs i_EventArgs)
		{
			m_ColorPicked = (sender as Button).BackColor;
			//UpdatePossibleColors(m_ColorPicked);
			Close();
		}

		public void UpdatePossibleColors(Color i_colorPicked)
		{
			switch (i_colorPicked.Name)
			{
				case "Pink":
					m_ButtonPink.Enabled = false;
					break;
				case "Red":
					m_ButtonRed.Enabled = false;
					break;
				case "LimeGreen":
					m_ButtonLimeGreen.Enabled = false;
					break;
				case "Cyan":
					m_ButtonCyan.Enabled = false;
					break;
				case "Blue":
					m_ButtonBlue.Enabled = false;
					break;
				case "Yellow":
					m_ButtonYellow.Enabled = false;
					break;
				case "Saddlebrown":
					m_ButtonSaddleBrown.Enabled = false;
					break;
				case "White":
					m_ButtonWhite.Enabled = false;
					break;
			}
		}

		public Color ColorPicked
		{
			get
			{
				return m_ColorPicked;
			}
		}
	}
}
