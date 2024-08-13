using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private Dictionary<char, int> _wordValuePairs = new Dictionary<char, int>();
        private Dictionary<char, int> _multipliers = new Dictionary<char, int>();
        private string _word;
        
        public Scrabble(string word)
        {
            //TODO: do something with the word variable

            _wordValuePairs.Add('a', 1);
            _wordValuePairs.Add('e', 1);
            _wordValuePairs.Add('i', 1);
            _wordValuePairs.Add('o', 1);
            _wordValuePairs.Add('u', 1);
            _wordValuePairs.Add('l', 1);
            _wordValuePairs.Add('n', 1);
            _wordValuePairs.Add('r', 1);
            _wordValuePairs.Add('s', 1);
            _wordValuePairs.Add('t', 1);
            _wordValuePairs.Add('d', 2);
            _wordValuePairs.Add('g', 2);
            _wordValuePairs.Add('b', 3);
            _wordValuePairs.Add('c', 3);
            _wordValuePairs.Add('m', 3);
            _wordValuePairs.Add('p', 3);
            _wordValuePairs.Add('f', 4);
            _wordValuePairs.Add('h', 4);
            _wordValuePairs.Add('v', 4);
            _wordValuePairs.Add('w', 4);
            _wordValuePairs.Add('y', 4);
            _wordValuePairs.Add('k', 5);
            _wordValuePairs.Add('j', 8);
            _wordValuePairs.Add('x', 8);
            _wordValuePairs.Add('q', 10);
            _wordValuePairs.Add('z', 10);

            _multipliers.Add('}', 1);
            _multipliers.Add(']', 1);
            _multipliers.Add('{', 2);
            _multipliers.Add('[', 3);

            _word = word.ToLower();

        }

        public int score()
        {
            //TODO: score calculation code goes here
            if (_word.Count() == 0) return 0;

            int total = 0;
            int multiplier = 1;
            foreach (var item in _word.ToCharArray())
            {   
                if (_multipliers.ContainsKey(item))
                {
                    multiplier = _multipliers[item];
                }
                if (_wordValuePairs.ContainsKey(item))
                {
                    total += multiplier*_wordValuePairs[item];
                }
            }
            return total;
        }
    }
}
