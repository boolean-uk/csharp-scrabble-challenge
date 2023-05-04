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

        // store word in private member
        private string _word;

        // store the values with a dictionary/lists
        private Dictionary<char, int> letterValue = new Dictionary<char, int>()
            {
                { 'A', 1 }, { 'E', 1 }, { 'I', 1 }, { 'O', 1 }, { 'U', 1 }, { 'L', 1 }, { 'N', 1 }, { 'R', 1 }, { 'S', 1 }, { 'T', 1 },
                { 'D', 2 }, { 'G', 2 },
                { 'B', 3 }, { 'C', 3 }, { 'M', 3 }, { 'P', 3 },
                { 'F', 4 }, { 'H', 4 }, { 'V', 4 }, { 'W', 4 }, { 'Y', 4 },
                { 'K', 5 },
                { 'J', 8 }, { 'X', 8 },
                { 'Q', 10 }, { 'Z', 10 }
            };


        public Scrabble(string word)
        {
            // convert to UpperCase
            _word = word.ToUpper();
        }


        public int score()
        {
            int score = 0;
            // validation
 
            if (string.IsNullOrEmpty(_word) || _word.Contains(" "))
            {
                return score;
            }

            // iterate through each character in the word
            foreach (char c in _word)
            {
                // get character value from the dictionary
                if (letterValue.ContainsKey(c))
                {
                    score += letterValue[c];
                }
            }


            return score;

        }

    }

}
