using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameLogic
{
    public class Guess
    {
        private int m_GuessNum;
        private char[] m_LettersGuess;

        public Guess(int i_guessNum, string i_lettersGuess)
        {
            this.m_GuessNum = i_guessNum;
            this.m_LettersGuess = i_lettersGuess.ToCharArray(0, i_lettersGuess.Length); 
        }
             
        public bool IsLegalGuess()
        {
            bool isLegalGuess = true;
            for (int i = 0; i < this.m_LettersGuess.Length; i++)
            {
                if (m_LettersGuess[i] < 65 || m_LettersGuess[i] > 72)
                    {
                        isLegalGuess = false;
                        return isLegalGuess;
                    }
                for (int j = i+1; j < this.m_LettersGuess.Length; j++)
                {
                    if (m_LettersGuess[i] == m_LettersGuess[j])
                    {
                        isLegalGuess = false;
                        break;
                    }
                }
            }
            return isLegalGuess;
        }

        public char[] GetLettersGuess()
        {
            return this.m_LettersGuess;
        }

        public int GetGuessNum()
        {
            return this.m_GuessNum;
        }

        public int[] GetFeedback(char[] i_SequenceOfRandomLetters)
        {
            StringBuilder feedback = new StringBuilder();
            int XCounter = 0;
            int VCounter = 0;

            for (int i = 0; i < m_LettersGuess.Length; i++)
            {
                if (m_LettersGuess[i] == i_SequenceOfRandomLetters[i])
                {
                    VCounter++;
                }
                else if (isContainsLetter(i_SequenceOfRandomLetters,m_LettersGuess[i]))
                {
                    XCounter++;
                }
            }
            
            int[] feedbackArray = new int[2]{ VCounter, XCounter };
            return feedbackArray;
        }

		private bool isContainsLetter (char[] i_Chars, char i_Char)
		{
			bool isContainsLetter = false;
			foreach (char tempChar in i_Chars)
			{
				if (tempChar == i_Char)
				{
					isContainsLetter = true;
				}
			}
			return isContainsLetter;
		}
        public bool IsWin(char[] i_SequenceOfRandomLetters)
        {
            for (int i = 0; i < m_LettersGuess.Length; i++)
            {
                if (m_LettersGuess[i] != i_SequenceOfRandomLetters[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
