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
        private int _mult;

        private static Dictionary<char, int> charToScore = new Dictionary<char, int>(){
            {'A', 1}, {'E', 1}, {'I', 1}, {'O', 1}, {'U', 1},
            {'L', 1}, {'N', 1}, {'R', 1}, {'S', 1}, {'T', 1},
            {'D', 2}, {'G', 2},
            {'B', 3}, {'C', 3}, {'M', 3}, {'P', 3},
            {'F', 4}, {'H', 4}, {'V', 4}, {'W', 4}, {'Y', 4},
            {'K', 5},
            {'J', 8}, {'X', 8},
            {'Q', 10}, {'Z', 10},
    };
        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            _word = word.ToUpper();
            _mult = 1;
        }

        public int score()
        {
            //TODO: score calculation code goes here
            //TODO: Remove this line when the code has been written
            Boolean tripleActive = false;
            Boolean doubleActive = false;


            int points = 0;
            foreach (char c in _word)
            {
                switch (c)
                {
                    case '{':
                        _mult *= 2;
                        break;
                    case '}':
                        _mult /= 2;
                        break;
                    case '[':
                        _mult *= 3;
                        break;
                    case ']':
                        _mult /= 3;
                        break;
                    case var expression when !Char.IsLetter(c):
                            return 0;
                    default:
                        break;
                }
                points += _mult * charToScore.GetValueOrDefault(c, 0);
                
            }
            if (_mult == 1) {
                return points;
            } else {
                return 0;
            }
        }
    }
}
