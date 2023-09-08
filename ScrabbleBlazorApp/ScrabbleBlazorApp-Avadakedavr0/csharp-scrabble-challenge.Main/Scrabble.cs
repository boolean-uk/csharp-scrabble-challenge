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
        private string _originalWord = string.Empty; // to store seperate
        private WordList _wordList; //using the wordlist
        public string ErrorMessage { get; private set; } //erorr message

        //--------------setting op dictionary first-------------------
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

        public Scrabble(string word, WordList wordList)
        {
            this._wordList = wordList;
            _originalWord = word?.Trim() ?? string.Empty;
            _word = StripMultipliers(_originalWord).ToUpper();

            if (!_wordList.IsItAValidWord(_word))
            {
                ErrorMessage = $"ERROR!!! {_originalWord} is not a valid Scrabble word!"; //setting error message
                _originalWord = string.Empty;
            }
        }

        //setting up to strip the word/letters for validating if word exists
        private string StripMultipliers(string word)
        {
            //first remove the double and triple multipliers from word
            if (word.StartsWith("{") && word.EndsWith("}"))
            {
                word = word.Substring(1, word.Length - 2);
            }
            else if (word.StartsWith("[") && word.EndsWith("]"))
            {
                word = word.Substring(1, word.Length - 2);
            }

            // then remove any doible/tripple letter multipliers in word
            while (word.Contains("{") || word.Contains("["))
            {
                int startIndex = word.IndexOf('{');
                if (startIndex == -1 || (word.IndexOf('[') != -1 && word.IndexOf('[') < startIndex))
                {
                    startIndex = word.IndexOf('[');
                }

                if (startIndex != -1 && startIndex < word.Length - 2)
                {
                    char endMultiplier = word[startIndex] == '{' ? '}' : ']';
                    if (word[startIndex + 2] == endMultiplier)
                    {
                        word = word.Remove(startIndex, 1);
                        word = word.Remove(startIndex + 1, 1);
                    }
                }
            }

            return word;
        }

        public int score() //method for returning the score with the extended critiria
        {
            string wordToScore = _originalWord;
            if (string.IsNullOrEmpty(wordToScore)) return 0; //if its empty, send back 0

            int score = 0; //setting initials score to 0

            //------------------word multipliers ------------------------------

            int multiplierOfWord = 1; //setting initial multiplier of word to 1

            //used folowing documentation:
            //https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/startsWith
            //https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/endsWith
            //https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/substring

            //double word
            if (wordToScore.StartsWith("{") && wordToScore.EndsWith("}"))
            {
                multiplierOfWord = 2;
                wordToScore = wordToScore.Substring(1, wordToScore.Length - 2);
            }

            //tripple word
            else if (wordToScore.StartsWith("[") && wordToScore.EndsWith("]"))
            {
                multiplierOfWord = 3;
                wordToScore = wordToScore.Substring(1, wordToScore.Length - 2);
            }

            //------------------letter multipliers ------------------------------
            for (int i = 0; i < wordToScore.Length; i++)  // looping trough word
            {
                char character = char.ToUpper(wordToScore[i]);
                int multiplierOfLetter = 1; // standard multiplier of 1 if letter is not "special"

                //double letter
                if (character == '{')
                {
                    multiplierOfLetter = 2;
                    i++;
                    character = char.ToUpper(wordToScore[i]);
                }
                //tripple letter
                else if (character == '[')
                {
                    multiplierOfLetter = 3;
                    i++;
                    character = char.ToUpper(wordToScore[i]);
                }
                //calculating for current character
                if (_valueOfLetters.ContainsKey(character))
                {
                    score += _valueOfLetters[character] * multiplierOfLetter;
                }
                if ((i < wordToScore.Length - 1) && (wordToScore[i + 1] == '}' || wordToScore[i + 1] == ']'))
                {
                    i++;
                }
            }
            //returning the total score multiplied by the multiplier of the word (2 with double and 3 with tripple word)
            return score * multiplierOfWord;
        }

        // for getting the word to display in Program
        public string GetWord()
        {
            return _originalWord;

        }
    }
}