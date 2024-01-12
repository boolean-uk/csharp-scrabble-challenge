using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        Dictionary<char, int> _letterValues = new Dictionary<char, int>()
        {
            {'A', 1}, {'B', 3}, {'C', 3}, {'D', 2}, {'E', 1}, {'F', 4}, {'G', 2},
            {'H', 4}, {'I', 1}, {'J', 8}, {'K', 5}, {'L', 1}, {'M', 3}, {'N', 1},
            {'O', 1}, {'P', 3}, {'Q', 10}, {'R', 1}, {'S', 1}, {'T', 1}, {'U', 1},
            {'V', 4}, {'W', 4}, {'X', 8}, {'Y', 4}, {'Z', 10}
        };
        private string _word;
        public Scrabble(string Word)
        {
            //TODO: do something with the word variable
            _word = Word.ToUpper();
            
            
        }

        public int score()
        {
            //TODO: score calculation code goes here 
            int score = 0;
            int multiplier = 1;
            
            foreach (char letter in _word)
            {
                if (_letterValues.ContainsKey(letter))
                {
                    score += _letterValues[letter] * multiplier;
                }
                else if(letter == ('{'))
                {
                    multiplier *= 2;
                }
                else if (letter == ('}'))
                {
                    multiplier *= 2;
                }
                else if (letter == ('['))
                {
                    multiplier *= 3;
                }
                else if (letter == (']'))
                {
                    multiplier *= 3;
                }

            }
            
            return score;
        }

        

        public Dictionary<char, int> letterValues { get { return _letterValues; } }
        public string word {  get { return _word; } }
    }
}
