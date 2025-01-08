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

        private static Dictionary<char, int> letterScores = new Dictionary<char, int>
        {
                {'A', 1}, {'E', 1}, {'I', 1}, {'O', 1}, {'U', 1}, {'L', 1}, {'N', 1}, {'R', 1}, {'S', 1}, {'T', 1},
                {'D', 2}, {'G', 2},
                {'B', 3}, {'C', 3}, {'M', 3}, {'P', 3},
                {'F', 4}, {'H', 4}, {'V', 4}, {'W', 4}, {'Y', 4},
                {'K', 5},
                {'J', 8}, {'X', 8},
                {'Q', 10}, {'Z', 10}
        };

        private string _wordUpperCase;

        public Scrabble(string word)
        {
            _wordUpperCase = word.ToUpper();
        }

        public int score()
        {
            int scoreMultiply = 1;
            // Multiply total score if double or triple word + trim away beginning and end if multiplied
            if (_wordUpperCase.StartsWith('{') && _wordUpperCase.EndsWith('}')
                && _wordUpperCase[2] != '}' && _wordUpperCase[_wordUpperCase.Length - 2] != '{')
            {
                scoreMultiply = 2;
                _wordUpperCase = _wordUpperCase[1..(_wordUpperCase.Length - 1)];
            }
            if (_wordUpperCase.StartsWith('[') && _wordUpperCase.EndsWith(']')
                && _wordUpperCase[2] != ']' && _wordUpperCase[_wordUpperCase.Length - 2] != '[')
            {
                scoreMultiply = 3;
                _wordUpperCase = _wordUpperCase[1..(_wordUpperCase.Length - 1)];
            }


            // Calculate score of a word by converting every letter to its value and add up
            // Letters inside "{}" and "[]" will have their score doubled and tripled, respectively
            int totalScore = 0;

            for(int i = 0; i < _wordUpperCase.Length; i++)
            {
                if (_wordUpperCase[i] == '{' && _wordUpperCase[i + 2] == '}')
                {
                    totalScore += letterScores[_wordUpperCase[i+1]] * 2;
                    i += 2;
                    continue;
                }
                    
                else if (_wordUpperCase[i] == '[' && _wordUpperCase[i + 2] == ']')
                {
                    totalScore += letterScores[_wordUpperCase[i+1]] * 2;
                    i += 2;
                    continue;
                }

                if (letterScores.ContainsKey(_wordUpperCase[i]))
                {
                    totalScore += letterScores[_wordUpperCase[i]];
                }
                else
                    return 0;
            }

            return totalScore * scoreMultiply;
        }
    }
}
