using System;   
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string _word;
        Dictionary<char, int> _wordPoint = new Dictionary<char, int>()
        {
            {'A', 1}, {'B', 3}, {'C', 3}, {'D', 2}, {'E', 1}, {'F', 4}, {'G', 2},
            {'H', 4}, {'I', 1}, {'J', 8}, {'K', 5}, {'L', 1}, {'M', 3}, {'N', 1},
            {'O', 1}, {'P', 3}, {'Q', 10}, {'R', 1}, {'S', 1}, {'T', 1}, {'U', 1},
            {'V', 4}, {'W', 4}, {'X', 8}, {'Y', 4}, {'Z', 10}
        };

        public Scrabble(string word)
        {            
            //TODO: do something with the word variable
            _word = word.ToUpper();
        }

        public int score()
        {
            //TODO: score calculation code goes here
            int score = 0;
            int multiplier = 1;
            foreach (char item in _word)
            {
                if (_wordPoint.ContainsKey(item))
                {
                    score += _wordPoint[item] * multiplier;
                }
                else if (item == '{')
                    multiplier *= 2;
                else if (item == '[')
                    multiplier *= 3;
                else if (item == '}')
                    multiplier /= 2;
                else if (item == ']')
                    multiplier /= 3;
            }
            return score;
            //throw new NotImplementedException(); //TODO: Remove this line when the code has been written
        }

    }
}
