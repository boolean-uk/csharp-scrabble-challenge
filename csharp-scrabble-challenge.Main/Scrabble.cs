using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private static readonly Dictionary<string, int> LetterScores = new Dictionary<string, int>
        {
            { "a", 1 },{"b",3}, {"c",3} , {"d",2}, {"e",1}, {"f",4},{"g",2}, {"h",4}, {"i",1},{"j",8}, {"k",5}, {"l",1}, {"m",3}, {"n",1},
            {"o",1}, {"p",3}, {"q",10}, {"r",1}, {"s",1}, {"t",1}, {"u",1}, {"v",4}, {"w",4}, {"x",8}, {"y",4}, {"z",10},

        };

        private readonly string word;
        private readonly int multiplier;

        public Scrabble(string word)
        {
            if (string.IsNullOrWhiteSpace(word))

            {
                this.word = string.Empty;


            }

            else
            {
                this.word = word;
                //TODO: do something with the word variable

            }
            
        }

        public int Score()
        {
            if(string.IsNullOrWhiteSpace(word))
                return 0;

            if (!Regex.IsMatch(word, @"^[a-zA-Z\[\]\{\}]*$"))
                return 0;

            int multiplier = 1;

            string multiplierWord = word;

            if (multiplierWord.StartsWith("[") && multiplierWord.EndsWith("]"))

            {
                multiplier = 3;
                multiplierWord = multiplierWord.Substring(1, multiplierWord.Length - 2);


            }

            else if (multiplierWord.StartsWith("{") && multiplierWord.EndsWith("}"))
            {
                multiplier = 2; 
                multiplierWord = multiplierWord.Substring(1, multiplierWord.Length - 2); 
            }



            int totalScore = 0;

            foreach (char letter in multiplierWord.ToLower())
            {

                string letterStr = letter.ToString();
                if (LetterScores.ContainsKey(letterStr))

                {
                    totalScore += LetterScores[letterStr];

                }

            }
      

            //TODO: score calculation code goes here
             return totalScore * multiplier; //TODO: Remove this line when the code has been written
        }
    }
}

