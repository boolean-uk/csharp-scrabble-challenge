using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private int _final = 0;
        private string _word;
        private int _multiplier = 1;
        private bool _bracketCheck;
        private bool _bracketCheck2;
        public Scrabble(string word)
        {            
            //TODO: do something with the word variable
            _word = word.ToLower();
        }

        public int score()
        {
            //TODO: score calculation code goes here
            Dictionary<char, int> letters = new Dictionary<char, int>
            {
                {'a', 1},
                {'b', 3},
                {'c', 3},
                {'d', 2},
                {'e', 1},
                {'f', 4},
                {'g', 2},
                {'h', 4},
                {'i', 1},
                {'j', 8},
                {'k', 5},
                {'l', 1},
                {'m', 3},
                {'n', 1},
                {'o', 1},
                {'p', 3},
                {'q', 10},
                {'r', 1},
                {'s', 1},
                {'t', 1},
                {'u', 1},
                {'v', 4},
                {'w', 4},
                {'x', 8},
                {'y', 4},
                {'z', 10},
                {'{', 0},
                {'}', 0},
                {'[', 0},
                {']', 0},
            };

            foreach (char single in _word)
            {
                if (single == '{')
                {
                    _multiplier = _multiplier * 2;
                    _bracketCheck = true;
                }
                if (single == '[')
                {
                    _multiplier = _multiplier * 3;
                    _bracketCheck2 = true;
                }
                if (single == '}')
                {
                    if (!_bracketCheck)
                    {
                        return 0;
                    }
                    _multiplier = _multiplier / 2;
                    _bracketCheck = false;
                }
                if (single == ']')
                {
                    if (!_bracketCheck2)
                    {
                        return 0;
                    }
                    _multiplier = _multiplier / 3;
                    _bracketCheck2 = false;
                }

                if (letters.ContainsKey(single))
                {
                    _final += letters[single] * _multiplier;
                } else
                {
                    return 0;
                }
            }
            if (_bracketCheck)
            {
                return 0;
            }
            if (_bracketCheck)
            {
                return 0;
            }
            return _final;
        }
    }
}
