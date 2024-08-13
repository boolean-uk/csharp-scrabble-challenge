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
        private Dictionary<char[], int> _alphabetScores = new Dictionary<char[], int>()
        {
            { ['a', 'e', 'i', 'o', 'u', 'l', 'n', 'r', 's', 't'], 1 },
            { ['d', 'g'], 2 },
            { ['b', 'c', 'm', 'p'], 3 },
            { ['f', 'h', 'v', 'w', 'y'], 4 },
            { ['k'], 5 },
            { ['j', 'x'], 8 },
            { ['z', 'q'], 10 },
        };

        public Scrabble(string word)
        {
            _word = word.Trim().ToLower();
        }

        public int score()
        {
            if (_word == null) return 0;
            if (_word.Length == 0) return 0;
            string word = _word;
            int wordScoreMultiplier = 1;
            
            if ((word.Count(x => x == '{') + word.Count(x => x == '}')) % 2 != 0) return 0;
            if ((word.Count(x => x == '[') + word.Count(x => x == ']')) % 2 != 0) return 0;
            
            if (word[0] == '[' && word[word.Length - 1] == ']' && word[2] != ']')
            {
                word = word.Substring(word.IndexOf('[') + 1, word.LastIndexOf(']') - 1);
                wordScoreMultiplier = 3;
            }
            else if (word[0] == '{' && word[word.Length - 1] == '}' && word[2] != '}')
            {
                word = word.Substring(word.IndexOf('{') + 1, word.LastIndexOf('}') - 1);
                wordScoreMultiplier = 2;
            }
            
            int sum = 0;
            int letterScoreMultiplier = 1;
            foreach (char character in word)
            {
                if (character == '{')
                {
                    letterScoreMultiplier += 1;
                }
                else if (character == '[')
                {
                    letterScoreMultiplier += 2;
                }
                else if (character == '}')
                {
                    letterScoreMultiplier -= 1;
                }
                else if (character == ']')
                {
                    letterScoreMultiplier -= 2;
                }
                else if (character >= 'a' && character <= 'z')
                {
                    foreach (var characters in _alphabetScores)
                    {
                        if (characters.Key.Contains(character))
                        {
                            sum += (characters.Value * letterScoreMultiplier);
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
            return sum * wordScoreMultiplier;
        }
    }
}
