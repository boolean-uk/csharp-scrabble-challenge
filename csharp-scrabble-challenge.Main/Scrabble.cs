using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string wordToBeChecked;
        private char[] lettersValue1 = { 'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T' };
        private char[] lettersValue2 = { 'D', 'G' };
        private char[] lettersValue3 = { 'B', 'C', 'M', 'P' };
        private char[] lettersValue4 = { 'F', 'H', 'V', 'W', 'Y' };
        private char[] lettersValue5 = { 'K' };
        private char[] lettersValue8 = { 'J', 'X' };
        private char[] lettersValue10 = { 'Q', 'Z' };

        public Scrabble(string word)
        {
            wordToBeChecked = word.Trim().ToUpper();
        }

        public int score()
        {
            int score = 0;
            int multiplier = 1; 

            foreach (char c in wordToBeChecked)
            {
                if (c == '{') 
                {
                    multiplier = 2;
                }
                else if (c == '[') 
                {
                    multiplier = 3;
                }
                else if (c == '}')
                {
                    multiplier = 1; 
                }
                else if (c == ']')
                {
                    multiplier = 1; 
                }
                else
                {
                    int letterScore = CalculateLScore(c);
                    score += letterScore * multiplier;
                }
            }

            return score;
        }

        private int CalculateLScore(char c)
        {
            if (lettersValue1.Contains(c))
            {
                return 1;
            }
            else if (lettersValue2.Contains(c))
            {
                return 2;
            }
            else if (lettersValue3.Contains(c))
            {
                return 3;
            }
            else if (lettersValue4.Contains(c))
            {
                return 4;
            }
            else if (lettersValue5.Contains(c))
            {
                return 5;
            }
            else if (lettersValue8.Contains(c))
            {
                return 8;
            }
            else if (lettersValue10.Contains(c))
            {
                return 10;
            }

            return 0; 
        }
    }
}
