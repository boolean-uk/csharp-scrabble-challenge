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

        private Dictionary<char, int> _values = new Dictionary<char, int>()
        {
            {'a', 1 },
            {'e', 1 },
            {'i', 1 },
            {'o', 1 },
            {'u', 1 },
            {'l', 1 },
            {'n', 1 },
            {'r', 1 },
            {'s', 1 },
            {'t', 1 },
            {'d', 2 },
            {'g', 2 },
            {'b', 3 },
            {'c', 3 },
            {'m', 3 },
            {'p', 3 },
            {'f', 4 },
            {'h', 4 },
            {'v', 4 },
            {'w', 4 },
            {'y', 4 },
            {'k', 5 },
            {'j', 8 },
            {'x', 8 },
            {'q', 10 },
            {'z', 10 },
        };

        public Scrabble(string word)
        {            
            //TODO: do something with the word variable
            this._word = word;
        }

        public int score()
        {

            //TODO: score calculation code goes here
            //throw new NotImplementedException(); //TODO: Remove this line when the code has been written

            //return w.Where(letters => _values.ContainsKey(letters)).Select(value => _values[value]).Sum();

            if (this._word.Any(char.IsDigit))
            {
                return 0;
            }

            char[] w = this._word.ToLower().ToCharArray();
            
            int sum = 0;
            int multiplier = 1;
            
            foreach (char c in w)
            {
                if(c == '{') multiplier = multiplier * 2;
                else if(c == '}') multiplier = multiplier / 2;
                else if(c == '[') multiplier = multiplier * 3;
                else if (c == ']') multiplier = multiplier / 3;

                if (_values.ContainsKey(c))
                {
                    sum += (_values[c] * multiplier);
                }
            }

            return multiplier == 1 ? sum : 0;
            
        }
    }
}
