using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string word;
        private Dictionary<char, int> letterValues;

        public Scrabble(string word)
        {
            this.word = word.ToUpper(); 
            InitializeLetterValues();
        }


       public int score()
       {
            // throw new NotImplementedException();

            int totalScore = 0;
            int wordMultiplier = 1;

            for (int i = 0; i < word.Length; i++)
            {
                char currentChar = word[i];

                if (i < word.Length - 1 && word[i + 1] == '{')
                {
                    totalScore += 2 * letterValues[currentChar];
                    i++; 
                }
                else if (i < word.Length - 1 && word[i + 1] == '[')
                {
                    totalScore += 3 * letterValues[currentChar];
                    i++; 
                }
                else
                {
                    if (letterValues.ContainsKey(currentChar))
                    {
                        totalScore += letterValues[currentChar];
                    }
                }
            }

            if (word.StartsWith("{") && word.EndsWith("}"))
            {
                wordMultiplier = 2;
            }
            else if (word.StartsWith("[") && word.EndsWith("]"))
            {
                wordMultiplier = 3;
            }

            return totalScore * wordMultiplier;
        }


        private void InitializeLetterValues()
        {
            letterValues = new Dictionary<char, int>
            {
                { 'A', 1 }, { 'E', 1 }, { 'I', 1 }, { 'O', 1 }, { 'U', 1 }, { 'L', 1 }, { 'N', 1 }, { 'R', 1 }, { 'S', 1 }, { 'T', 1 },
                { 'D', 2 }, { 'G', 2 },
                { 'B', 3 }, { 'C', 3 }, { 'M', 3 }, { 'P', 3 },
                { 'F', 4 }, { 'H', 4 }, { 'V', 4 }, { 'W', 4 }, { 'Y', 4 },
                { 'K', 5 },
                { 'J', 8 }, { 'X', 8 },
                { 'Q', 10 }, { 'Z', 10 }
            };
        }
    }
}        