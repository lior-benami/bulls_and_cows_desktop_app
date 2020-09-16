using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    public class Board
    {
        private readonly int r_NumOfGuesses;
        private const int k_NumOfColumns = 8;
        private char[,] m_Board;

        public Board(int i_NumOfGuesses)
        {
            this.r_NumOfGuesses = i_NumOfGuesses;
            this.m_Board = new char[i_NumOfGuesses, k_NumOfColumns];
            this.initializeBoard();

        }

        private void initializeBoard()
        {
            for (int i = 0; i < r_NumOfGuesses; i++)
            {
                for (int j = 0; j < k_NumOfColumns; j++)
                {
                    m_Board[i, j] = ' ';
                }
            }
        }

        public int GetNumberOfGuesses()
        {
            return this.r_NumOfGuesses;
        }

        public int GetNumberOfColumns()
        {
            return k_NumOfColumns;
        }

        public char GetCellOfBoard(int i_Row, int i_Column)
        {
            return m_Board[i_Row, i_Column];
        }

        public void InsertGuess(Guess i_guess)
        {
            char[] lettersGuess = i_guess.GetLettersGuess();
            int guessNum = i_guess.GetGuessNum();

            for (int i = 0; i < lettersGuess.Length; i++)
            {
                this.m_Board[guessNum,i] = lettersGuess[i];
            }
        }
        
        public void InsertFeedback(char[] i_feedback, int i_guessNum)
        {
            for (int i = 0; i < i_feedback.Length; i++)
            {
                this.m_Board[i_guessNum,i + 4] = i_feedback[i];
            }
        }

        public void StartNewGame()
        {
            this.initializeBoard();
        }
    }
}
