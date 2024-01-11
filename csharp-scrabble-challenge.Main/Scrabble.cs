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
            //Create a dictionary with all the letters with their respective scores.
        Dictionary<char, int> _scores = new Dictionary<char, int>()
            {
                {'a', 1}, {'e', 1}, {'i', 1}, {'o', 1}, {'u', 1}, {'l', 1}, {'n', 1},
                {'r', 1}, {'s', 1}, {'t', 1}, {'d', 2}, {'g', 2}, {'b', 3}, {'c', 3},
                {'m', 3}, {'p', 3}, {'f', 4}, {'h', 4}, {'v', 4}, {'w', 4}, {'y', 4},
                {'k', 5}, {'j', 8}, {'x', 8}, {'q', 10}, {'z', 10}
            };
        public Scrabble(string word)
        {
            _word = word.ToLower();

            //TODO: do something with the word variable
        }

        public int score()
        {
            int score = 0;
            int multiplier = 1;
            foreach (char c in _word)
            {
                if (_scores.ContainsKey(c))
                {
                    score += _scores[c] * multiplier;
                }
                else if (c == '{')
                    multiplier = 2;
                else if (c == '[')
                    multiplier = 3;
                else if (c == '}' || c == ']')
                    multiplier = 1;
            }
            return score;

        }
    }
}
