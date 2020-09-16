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
	public partial class GameBoard : Form
	{
		private const int k_NumberOfColorsToGuess = 4;
		private readonly Board r_GameBoard;
		private readonly GameGuess r_GameGuess;
		private readonly Colors r_OptionalColors;
		private const string k_FormText = "Bool Pgia";
		private const string k_WinningMessage = "You won!";
		private const string k_GameOverMsg = "No more guesses allowed. You Lost!";
		private Button m_BlackButton1;
		private Button m_BlackButton2;
		private Button m_BlackButton3;
		private Button m_BlackButton4;
		internal readonly List<GameButton> r_GameButtons;
		internal int m_CurrentGuessNumber;
		private readonly int r_NumOfChances;
		private const int k_GuessButtonSize = 50;
		private readonly List<GameButton> r_FeedbackButtons;
		private const int k_FeedbackButtonSize = 20;
		private readonly List<GameButton> r_ArrowsButtons;
		private const string k_ArrowsButtonsText = "-->>";
		private PickColor m_PickColorForm;

		public GameBoard(int i_NumOfChances)
		{
			r_NumOfChances = i_NumOfChances;
			Text = k_FormText;
			r_GameBoard = new Board(i_NumOfChances);
			r_GameGuess = new GameGuess(i_NumOfChances);
			r_OptionalColors = new Colors();
			r_GameButtons = new List<GameButton>();
			r_FeedbackButtons = new List<GameButton>();
			r_ArrowsButtons = new List<GameButton>();
			initBoardSize(i_NumOfChances);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			StartPosition = FormStartPosition.CenterScreen;
			m_CurrentGuessNumber = 0;
			m_PickColorForm = new PickColor();
		}

		private void initBoardSize(int i_NumOfChances)
		{
			Size = new Size(380, 60 * i_NumOfChances + 150);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			initButtonsControls();
			initBoard();
		}

		private void initButtonsControls()
		{
			m_BlackButton1 = new Button();
			m_BlackButton1.BackColor = Color.Black;
			m_BlackButton1.Location = new Point(15, 15);
			m_BlackButton1.Height = k_GuessButtonSize;
			m_BlackButton1.Width = k_GuessButtonSize;

			m_BlackButton2 = new Button();
			m_BlackButton2.BackColor = Color.Black;
			m_BlackButton2.Location = new Point(m_BlackButton1.Right + 10, 15);
			m_BlackButton2.Height = k_GuessButtonSize;
			m_BlackButton2.Width = k_GuessButtonSize;

			m_BlackButton3 = new Button();
			m_BlackButton3.BackColor = Color.Black;
			m_BlackButton3.Location = new Point(m_BlackButton2.Right + 10, 15);
			m_BlackButton3.Height = k_GuessButtonSize;
			m_BlackButton3.Width = k_GuessButtonSize;

			m_BlackButton4 = new Button();
			m_BlackButton4.BackColor = Color.Black;
			m_BlackButton4.Location = new Point(m_BlackButton3.Right + 10, 15);
			m_BlackButton4.Height = k_GuessButtonSize;
			m_BlackButton4.Width = k_GuessButtonSize;
			Controls.AddRange(new Control[] { m_BlackButton1, m_BlackButton2, m_BlackButton3, m_BlackButton4 });
		}

		private void initBoard()
		{
			int height = m_BlackButton1.Bottom;
			int numberOfGuesses = r_GameBoard.GetNumberOfGuesses();
			int guessLineIndex = 0;
			while (numberOfGuesses > guessLineIndex)
			{
				initBoardGuessLine(guessLineIndex, height + 30);
				height += 60;
				guessLineIndex++;
			}
		}

		private void initBoardGuessLine(int i_GuessLineIndex, int i_Height)
		{
			GameButton GuessButton1 = new GameButton(i_GuessLineIndex);
			GuessButton1.Location = new Point(15, i_Height + 10);
			GuessButton1.Height = k_GuessButtonSize;
			GuessButton1.Width = k_GuessButtonSize;
			GuessButton1.Enabled = false;
			r_GameButtons.Add(GuessButton1);

			GameButton GuessButton2 = new GameButton(i_GuessLineIndex);
			GuessButton2.Location = new Point(GuessButton1.Right + 10, i_Height + 10);
			GuessButton2.Height = k_GuessButtonSize;
			GuessButton2.Width = k_GuessButtonSize;
			GuessButton2.Enabled = false;
			r_GameButtons.Add(GuessButton2);

			GameButton GuessButton3 = new GameButton(i_GuessLineIndex);
			GuessButton3.Location = new Point(GuessButton2.Right + 10, i_Height + 10);
			GuessButton3.Height = k_GuessButtonSize;
			GuessButton3.Width = k_GuessButtonSize;
			GuessButton3.Enabled = false;
			r_GameButtons.Add(GuessButton3);

			GameButton GuessButton4 = new GameButton(i_GuessLineIndex);
			GuessButton4.Location = new Point(GuessButton3.Right + 10, i_Height + 10);
			GuessButton4.Height = k_GuessButtonSize;
			GuessButton4.Width = k_GuessButtonSize;
			GuessButton4.Enabled = false;
			r_GameButtons.Add(GuessButton4);

			if (i_GuessLineIndex == 0)
			{
				GuessButton1.Enabled = true;
				GuessButton2.Enabled = true;
				GuessButton3.Enabled = true;
				GuessButton4.Enabled = true;
			}

			GameButton arrowButton = new GameButton(i_GuessLineIndex);
			arrowButton.Text = k_ArrowsButtonsText;
			arrowButton.Enabled = false;
			arrowButton.Location = new Point(GuessButton4.Right + 5, GuessButton4.Top + 10);
			arrowButton.Height = 25;
			arrowButton.Width = k_GuessButtonSize;
			r_ArrowsButtons.Add(arrowButton);

			GameButton feedbackButton1 = new GameButton(i_GuessLineIndex);
			feedbackButton1.Location = new Point(arrowButton.Right + 10, GuessButton4.Top + 5);
			feedbackButton1.Height = k_FeedbackButtonSize;
			feedbackButton1.Width = k_FeedbackButtonSize;
			feedbackButton1.Enabled = false;
			r_FeedbackButtons.Add(feedbackButton1);

			GameButton feedbackButton2 = new GameButton(i_GuessLineIndex);
			feedbackButton2.Location = new Point(feedbackButton1.Right + 10, feedbackButton1.Top);
			feedbackButton2.Height = k_FeedbackButtonSize;
			feedbackButton2.Width = k_FeedbackButtonSize;
			feedbackButton2.Enabled = false;
			r_FeedbackButtons.Add(feedbackButton2);

			GameButton feedbackButton3 = new GameButton(i_GuessLineIndex);
			feedbackButton3.Location = new Point(arrowButton.Right + 10, feedbackButton1.Bottom + 5);
			feedbackButton3.Height = k_FeedbackButtonSize;
			feedbackButton3.Width = k_FeedbackButtonSize;
			feedbackButton3.Enabled = false;
			r_FeedbackButtons.Add(feedbackButton3);

			GameButton feedbackButton4 = new GameButton(i_GuessLineIndex);
			feedbackButton4.Location = new Point(feedbackButton3.Right + 10, feedbackButton3.Top);
			feedbackButton4.Height = k_FeedbackButtonSize;
			feedbackButton4.Width = k_FeedbackButtonSize;
			feedbackButton4.Enabled = false;
			r_FeedbackButtons.Add(feedbackButton4);

			arrowButton.Click += arrowButton_Click;
			GuessButton1.Click += guessButton_Click;
			GuessButton2.Click += guessButton_Click;
			GuessButton3.Click += guessButton_Click;
			GuessButton4.Click += guessButton_Click;
			Controls.AddRange(new Control[] { GuessButton1, GuessButton2, GuessButton3, GuessButton4, arrowButton, feedbackButton1, feedbackButton2, feedbackButton3, feedbackButton4 });
		}

		private void guessButton_Click(object sender, EventArgs i_EventArgs)
		{
			m_PickColorForm.ShowDialog();
			if (isColorAlreadyExist(m_PickColorForm.ColorPicked))
			{
				MessageBox.Show(
						"This color exists, Try again",
						"Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
			}
			else
			{
				(sender as Button).BackColor = m_PickColorForm.ColorPicked;
				checkIfGuessCompleted((sender as GameButton).GuessLineIndex);
			}


		}

		private bool isColorAlreadyExist(Color i_UserColorToCheck)
		{
			bool isColorExist = false;

			for (int i =0; i<k_NumberOfColorsToGuess; i++)
			{
				if (r_GameButtons[i+m_CurrentGuessNumber * k_NumberOfColorsToGuess].BackColor == i_UserColorToCheck)
				{
					isColorExist = true;
					break;
				}
			}

			return isColorExist;
		}

		private void arrowButton_Click(object sender, EventArgs i_EventArgs)
		{
			List<GameButton> guessButtons = getGuessLineButtons(r_GameButtons, (sender as GameButton).GuessLineIndex);
			List<GameButton> feedbackButtons = getGuessLineButtons(r_FeedbackButtons, (sender as GameButton).GuessLineIndex);
			(sender as GameButton).Enabled = false;
			paintFeedbackButtons(guessButtons, feedbackButtons);
			if (r_GameGuess.UserWin)
			{
				paintBlackButtons();
				QuitGame quitGameForm = new QuitGame(k_WinningMessage);
				quitGameForm.ShowDialog();
			}
			else if (r_GameGuess.IsGameOver())
			{
				paintBlackButtons();
				QuitGame quitGameForm = new QuitGame(k_GameOverMsg);
				quitGameForm.ShowDialog();
			}

			m_CurrentGuessNumber++;
			int counterGameButtons = 0;
			foreach (GameButton gameButton in r_GameButtons)
			{
				if (counterGameButtons >= m_CurrentGuessNumber * 4 && counterGameButtons < m_CurrentGuessNumber * 8)
				{
					gameButton.Enabled = true;
				}
				else
				{
					gameButton.Enabled = false;
				}

				counterGameButtons++;
			}
			m_PickColorForm = new PickColor();
		}


		private void paintFeedbackButtons(List<GameButton> i_GuessButtons, List<GameButton> i_FeedbackButtons)
		{
			Guess guessedletters = new Guess(0, r_OptionalColors.CreateUserGuess(i_GuessButtons));
			int[] feedbackArray = guessedletters.GetFeedback(r_GameGuess.SequenceOfRandomLetters);
			int numOfYellowsFeedback = feedbackArray[1];
			int numOfBlacksFeedback = feedbackArray[0];
			for (int i = 0; i < numOfBlacksFeedback; i++)
			{
				i_FeedbackButtons[i].BackColor = Color.Black;
			}
			for (int i = 0; i < numOfYellowsFeedback; i++)
			{
				i_FeedbackButtons[i + numOfBlacksFeedback].BackColor = Color.Yellow;
			}
			if (numOfBlacksFeedback == k_NumberOfColorsToGuess)
			{
				r_GameGuess.UserWin = true;
			}
		}

		private void paintBlackButtons()
		{
			List<Color> GameGuessColors = r_OptionalColors.GetColorsList(r_GameGuess);
			m_BlackButton1.BackColor = GameGuessColors[0];
			m_BlackButton2.BackColor = GameGuessColors[1];
			m_BlackButton3.BackColor = GameGuessColors[2];
			m_BlackButton4.BackColor = GameGuessColors[3];
			foreach (GameButton guessButton in r_GameButtons)
			{
				guessButton.Enabled = false;
			}
		}

		private List<GameButton> getGuessLineButtons(List<GameButton> i_ButtonsList, int i_GuessLineIndex)
		{
			List<GameButton> guessLineButtons = new List<GameButton>();
			foreach (GameButton guessButton in i_ButtonsList)
			{
				if (guessButton.GuessLineIndex == i_GuessLineIndex)
				{
					guessLineButtons.Add(guessButton);
				}
			}
			return guessLineButtons;
		}

		private void checkIfGuessCompleted(int i_LineGuessIndex)
		{
			bool isGuessCompleted = true;
			List<GameButton> colorButtons = getGuessLineButtons(r_GameButtons, i_LineGuessIndex);
			foreach (GameButton colorButton in colorButtons)
			{
				if (DefaultBackColor == colorButton.BackColor)
				{
					isGuessCompleted = false;
				}
			}
			if (isGuessCompleted)
			{
				r_ArrowsButtons[i_LineGuessIndex].Enabled = true;
			}
		}
	}
}
