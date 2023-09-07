using System;
using System.Collections.Generic;
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

        public int score() //method for returning the score
        {
            //TODO: score calculation code goes here
            if (string.IsNullOrEmpty(_word)) return 0; //if its empty, send back 0

            int score = 0; //setting initials score to 0

            //calculating score
            foreach(char character in _word)
            {
                if (_valueOfLetters.ContainsKey(character))
                {
                    score += _valueOfLetters[character];
                }
            }
            return score; //return score
        }
    }
}
