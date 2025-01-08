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

        string _word;
        int _score;
        char _lastBracket;
        public Scrabble(string word)
        {            
            //TODO: do something with the word variable
            _word = word.ToUpper();
        }

        public int score()
        {
            _score = 0;
            int multiplier = 1;
            //TODO: score calculation code goes here
            foreach (var item in _word)
            {
                multiplier = setMultiplier(multiplier, item);
                if (letterScores.ContainsKey(item))
                {
                    _score += letterScores[item] * multiplier;
                }
                else if (!isBracket(item))
                {
                    return 0;
                }
                else if (isBracket(item)) {
                    if (validateBracket(_lastBracket, item))
                    {
                        _lastBracket = item;
                    }
                    else {
                        return 0;
                    }
                    
                }
            }
            return _score;
        }

        private int setMultiplier(int multiplier, char item) { 
            if(item == '{')
            {
                return 2 * multiplier;
            }else if ( item == '[')
            {
                return 3 * multiplier;
            }
            else if( item == ']')
            {
                return multiplier / 3;
            }else if(item == '}'){
                return multiplier / 2;
            }
            else
            {
                return multiplier;
            }
        }

        private bool isBracket(char c) { 
        return (c == '[' || c == ']' || c == '{' || c =='}');
        }

        private bool validateBracket(char lastBracket, char bracket)
        {
            if (lastBracket == '[')
            {
                return bracket == ']' || bracket == '{';
            }
            else if (lastBracket == '{') {
                return bracket == '}' || bracket == '['; }
            return true;

        }


        Dictionary<char, int> letterScores = new Dictionary<char, int> {
            {'A', 1},
            {'B', 3 },
            {'C', 3},
            {'D', 2},
            {'E', 1},
            {'F', 4},
            {'G', 2},
            {'H', 4},
            {'I', 1},
            {'J', 8 },
            {'K', 5 },
            {'L', 1},
            {'M', 3},
            {'N', 1},
            {'O', 1},
            {'P', 3},
            {'Q', 10},
            {'R', 1},
            {'S', 1},
            {'T', 1},
            {'U', 1},
            {'V', 4},
            {'W', 4},
            {'X', 8},
            {'Y', 4},
            {'Z', 10},
        };
    }
}
