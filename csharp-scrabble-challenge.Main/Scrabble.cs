using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
            private string _word; //setting private so cant be accessed outside the class
             //setting op dictionary first
            private Dictionary<char, int> _valueOfLetters = new Dictionary<char, int>
            {
                {'A', 1}, {'E', 1}, {'I', 1}, {'O', 1}, {'U', 1}, {'L', 1}, {'N', 1}, {'R', 1}, {'S', 1}, {'T', 1},
                {'D', 2}, {'G', 2},
                {'B', 3}, {'C', 3}, {'M', 3}, {'P', 3},
                {'F', 4}, {'H', 4}, {'V', 4}, {'W', 4}, {'Y', 4},
                {'K', 5},
                {'J', 8}, {'X', 8},
                {'Q', 10}, {'Z', 10}
            };
          
        public Scrabble(string word)
        {
            _word = word?.Trim().ToUpper();
            //word? for if word is null then the rest dont get executed
            // trim for removing whitspace chars, spaces, tabs, newline..
            //toUpper for for converting string to uppercase
        }

        public int score() //method for returning the score with the extended critiria
        {
            if (string.IsNullOrEmpty(_word)) return 0; //if its empty, send back 0

            int score = 0; //setting initials score to 0
            int multiplierOfWord = 1; //setting initial multiplier of word to 1

        //used folowing documentation:
        //https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/startsWith
        //https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/endsWith
        //https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/substring

            //------------------word multipliers ------------------------------
            //double word
            if (_word.StartsWith("{") && _word.EndsWith("}"))
            {
                multiplierOfWord = 2;
                _word = _word.Substring(1, _word.Length - 2);
            }

            //tripple word
            else if (_word.StartsWith("[") && _word.EndsWith("]"))
            {
                multiplierOfWord = 3;
                _word = _word.Substring(1, _word.Length - 2);
            }

        }
    }
}
