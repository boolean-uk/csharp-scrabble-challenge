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


        // TODO: do something with the word variable
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

        // store word in private member
        public Scrabble(string word)
        {
            // convert to UpperCase
            _word = word.ToUpper();
        }


        public int score()
        {
            int score = 0;
            // validity checks- - return 0;
            // check for space? invalid word return 0;
            if (string.IsNullOrEmpty(_word) || _word.Contains(" "))
            {
                return score;
            }

            // turn word into char array
            // iterate array
            // lookup char in score array
            // increment variable with score?
            foreach (char c in _word)
            {
                if(letterValue.ContainsKey(c))
                {
                    score += letterValue[c];
                }
            }




            // TODO: score calculation code goes here
            return score; //TODO: Remove this line when the code has been written
        }
    }
}
