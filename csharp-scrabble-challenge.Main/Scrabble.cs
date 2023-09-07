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
        private string _word = string.Empty; //setting private so cant be accessed outside the class + added default value to fix the warning
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
            _word = word?.Trim().ToUpper() ?? string.Empty; //used ?? to add default value when word is 0, to fix the warning
            //word? for if word is null then the rest dont get executed
            // trim for removing whitspace chars, spaces, tabs, newline..
            //toUpper for for converting string to uppercase
        }

        public int score() //method for returning the score with the extended critiria
        {
            if (string.IsNullOrEmpty(_word)) return 0; //if its empty, send back 0

            int score = 0; //setting initials score to 0

            //------------------word multipliers ------------------------------

            int multiplierOfWord = 1; //setting initial multiplier of word to 1

            //used folowing documentation:
            //https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/startsWith
            //https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/endsWith
            //https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/substring

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

            //------------------letter multipliers ------------------------------

            for (int i = 0; i < _word.Length; i++)  // looping trough word
            {
                char character = _word[i];
                int multiplierOfLetter = 1; // standard multiplier of 1 if letter is not "special"

                //double letter
                if (character == '{' && i < _word.Length - 2 && _word[i + 2] == '}')
                {
                    multiplierOfLetter = 2;
                    character = _word[i + 1];
                    i += 2;
                }
                //tripple letter
                else if (character == '[' && i < _word.Length - 2 && _word[i + 2] == ']')
                {
                    multiplierOfLetter = 3;
                    character = _word[i + 1];
                    i += 2;
                }
                //calculating for current character
                if (_valueOfLetters.ContainsKey(character))
                {
                    score += _valueOfLetters[character] * multiplierOfLetter;
                }
            }
            //returning the total score multiplied by the multiplier of the word (2 with double and 3 with tripple word)
            return score * multiplierOfWord;
        }
    } 
}
