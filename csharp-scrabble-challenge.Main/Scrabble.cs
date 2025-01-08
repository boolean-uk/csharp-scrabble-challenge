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

        // 
        Dictionary<char, int> letterValues = new Dictionary<char, int>
            {
                {'A', 1}, {'E', 1}, {'I', 1}, {'O', 1}, {'U', 1},
                {'L', 1}, {'N', 1}, {'R', 1}, {'S', 1}, {'T', 1},
                {'D', 2}, {'G', 2},
                {'B', 3}, {'C', 3}, {'M', 3}, {'P', 3},
                {'F', 4}, {'H', 4}, {'V', 4}, {'W', 4}, {'Y', 4},
                {'K', 5},
                {'J', 8}, {'X', 8},
                {'Q', 10}, {'Z', 10},
                {'{', 0}, {'}', 0}, {'[', 0}, {']', 0}
            };

        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            _word = word.ToUpper();
        }

        public int score()
        {
            int score = 0;
            int multiplier = 1;
            bool doubleBracket = false;
            bool tripleBracket = false;

            if (_word.Length == 0) {
                return score;
            }

            foreach (char letter in _word)
            {
                // check for invalid character
                if (!letterValues.ContainsKey(letter))
                {
                    return score = 0;
                }

                // if bracket is opening, add multiplier
                if (letter == '{' && doubleBracket == false) { 
                    multiplier *= 2;
                    doubleBracket = true;
                }
                if (letter == '[' && tripleBracket == false) {
                    multiplier *= 3;
                    tripleBracket = true;

                }

                //if bracket is closed, remove multiplier

                if (letter == '}')
                {
                    if (!doubleBracket)
                    {
                        score = 0;
                        return score;
                    }
                    multiplier /= 2;
                    doubleBracket = false;
                }
                if (letter == ']')
                {
                    if (!tripleBracket)
                    {
                        return score = 0;
                    }
                    multiplier /= 3;
                    tripleBracket = false;
                }

                score += (letterValues[letter] * multiplier);

            }

            return score;
        }



    }
}
