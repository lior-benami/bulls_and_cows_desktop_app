using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    public class GameGuess
    {
        private readonly char[] r_SequenceOfRandomLetters;
        private int m_NumOfChances;
        private bool m_UserWin;
        private readonly Random r_RandomGenerator = new Random();

        public GameGuess(int i_NumOfChances)
        {
            r_SequenceOfRandomLetters = CreateRandomSequenceLetters();
            m_NumOfChances = i_NumOfChances;
            m_UserWin = false;
        }

        public bool UserWin
        {
            get
            {
                return m_UserWin;
            }
            set
            {
                m_UserWin = value;
            }
        }
        public char[] SequenceOfRandomLetters
        {
            get
            {
                return r_SequenceOfRandomLetters;
            }
        }

        public bool IsGameOver()
        {
            bool isGameOver = false;
            m_NumOfChances--;
            if (m_NumOfChances == 0)
            {
                isGameOver = true;
            }

            return isGameOver;
        }

        public char[] CreateRandomSequenceLetters()
        {
            List<char> lettersArray = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            char[] randomSequenceLetters = new char[4];
            for (int i = 0; i < 4; i++)
            {
                int randomizedLetterIndex = r_RandomGenerator.Next(0, lettersArray.Count);
                randomSequenceLetters[i] = lettersArray[randomizedLetterIndex];
                lettersArray.RemoveAt(randomizedLetterIndex);
            }
            return randomSequenceLetters;
        }
    }
}
