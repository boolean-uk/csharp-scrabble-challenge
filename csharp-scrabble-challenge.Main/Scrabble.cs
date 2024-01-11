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
        private string _word;
        public Dictionary<char, int> letterValues = new Dictionary<char, int>()
            {
                {'A', 1}, {'E', 1}, {'I', 1}, {'O', 1}, {'U', 1}, {'L', 1}, {'N', 1}, {'R', 1}, {'S', 1}, {'T', 1},{'D', 2}, {'G', 2},
                {'B', 3}, {'C', 3}, {'M', 3}, {'P', 3}, {'F', 4}, {'H', 4}, {'V', 4}, {'W', 4}, {'Y', 4}, {'K', 5},{'J', 8}, {'X', 8},
                {'Q', 10}, {'Z', 10}

            };
        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            //Initialize the word when an instance is created

            _word = word;
        }
        //public int Word { get => word; set => word = value; }

        public int score()
        {
            //TODO: score calculation code goes here
            //throw new NotImplementedException(); //TODO: Remove this line when the code has been written

            int score = 0; // Initialize the total score to 0
            int multiplier = 1; // Initialize the multiplier to 1

            //Iterate through each letter in the word
            foreach (char letter in _word.ToUpper())
            {
                if (letterValues.ContainsKey(letter))
                {
                    score += letterValues[letter] * multiplier;
                }
                else if (letter == '{')
                    multiplier = 2;
                else if (letter == '[')
                    multiplier = 3;
                else if (letter == '}')
                    multiplier = 1;
                else if (letter == ']')
                    multiplier = 2;
            }
            return score;


        }
    }
}
