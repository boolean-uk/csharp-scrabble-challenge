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
        private int _multiplier;
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
            {'{', 200 },
            {'}', -200 },
            {'[', 300 },
            {']', -300 },
        };

        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            _word = word.ToLower();
            _multiplier = 1;
        }

        public int score()
        {
            //TODO: score calculation code goes here
            //char[] letters = _word.ToCharArray();
            //int sum = letters.Where(letter => _values.ContainsKey(letter)).Select(value => _values[value]).Sum();
            //if (letters.Length > 0 && letters[0].Equals('{')) sum = sum * 2;
            //else if (letters.Length > 0 && letters[0].Equals('[')) sum = sum * 3;
            //return sum;


            char[] letters = _word.ToCharArray();
            int[] scores = letters.Where(letter => _values.ContainsKey(letter)).Select(value => _values[value]).ToArray();
            int sum = 0;

            foreach (int score in scores)
            {
                if (score == 200) _multiplier *= 2;
                else if (score == -200) _multiplier /= 2;
                else if (score == 300) _multiplier *= 3;
                else if (score == -300) _multiplier /= 3;
                else sum += score * _multiplier;
            }

            return sum;
        }
    }
}
