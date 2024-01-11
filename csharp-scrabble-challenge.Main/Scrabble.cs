using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{


    public class Scrabble
    {
        private string word;
        public Scrabble(string word)
        {
            this.word = word.ToLower();
        }
        //TODO: do something with the word variable

        public int score()
        {
            //TODO: score calculation code goes here

            Dictionary<char, int> scrabbleScore = new Dictionary<char, int>()
            {
                {'a', 1}, {'e', 1}, {'i', 1}, {'o', 1}, {'u', 1},
                {'l', 1}, {'n', 1}, {'r', 1}, {'s', 1}, {'t', 1},
                {'d', 2}, {'g', 2}, {'b', 3}, {'c', 3}, {'m', 3},
                {'p', 3}, {'f', 4}, {'h', 4}, {'v', 4}, {'w', 4},
                {'y', 4}, {'k', 5}, {'j', 8}, {'x', 8}, {'q', 10}, {'z', 10}
            };

            int totalScore = 0;
            int wordMultiplier = 1;

            string doubleLetter = @"\{(.+?)\}";
            string trippleLetter = @"\[(.+?)\]";
            string doubleWord = @"\{(.+?)\}";
            string trippleWord = @"\[(.+?)\]";

            foreach (char letter in word)
            {
                int letterScore = 0;

                if (Regex.IsMatch(letter.ToString(), doubleLetter))
                {
                    char unmodifiedLetter = letter.ToString()[1];
                    if (scrabbleScore.ContainsKey(unmodifiedLetter))
                    {
                        letterScore = 2 * scrabbleScore[unmodifiedLetter];
                    }
                }
                else if (Regex.IsMatch(letter.ToString(), trippleLetter))
                {
                    char unmodifiedLetter = letter.ToString()[1];
                    if (scrabbleScore.ContainsKey(unmodifiedLetter))
                    {
                        letterScore = 3 * scrabbleScore[unmodifiedLetter];
                    }
                }
                else if (scrabbleScore.ContainsKey(letter))
                {
                    letterScore = scrabbleScore[letter];
                }

                if (Regex.IsMatch (letter.ToString(), doubleWord))
                {
                    wordMultiplier *= 2;
                }
                else if (Regex.IsMatch(letter.ToString (), trippleWord))
                {
                    wordMultiplier *= 3;
                }

                totalScore += letterScore;
                               
                //throw new NotImplementedException(); //TODO: Remove this line when the code has been written
            }
            totalScore *= wordMultiplier;

            return totalScore;
        }
    }
}

