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
            //TODO: do something with the word variable
        }

        public int score()
        {
            //TODO: score calculation code goes here
            //throw new NotImplementedException(); //TODO: Remove this line when the code has been written
            int sum = 0;
            int scoreMultiplier = 1;
            for (int i = 0; i < _word.Length; i++)
            {
                if (_word[i] == '{')
                {
                    scoreMultiplier = 2;
                }
                else if (_word[i] == '[')
                {
                    scoreMultiplier = 3;
                }
                else if (_word[i] == '}' || _word[i] == ']')
                {
                    scoreMultiplier = 1;
                }

                foreach (var characters in _alphabetScores)
                {
                    if (characters.Key.Contains(_word[i]))
                    {
                        sum += (characters.Value * scoreMultiplier);
                    }
                }
            }
            return sum;
        }
    }
}
