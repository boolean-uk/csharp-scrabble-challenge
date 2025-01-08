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

        private static Dictionary<char, int> charValues = new()
        {
                {'A', 1}, {'E', 1}, {'I', 1}, {'O', 1}, {'U', 1}, {'L', 1}, {'N', 1}, {'R', 1}, {'S', 1}, {'T', 1},
                {'D', 2}, {'G', 2},
                {'B', 3}, {'C', 3}, {'M', 3}, {'P', 3},
                {'F', 4}, {'H', 4}, {'V', 4}, {'W', 4}, {'Y', 4},
                {'K', 5},
                {'J', 8}, {'X', 8},
                {'Q', 10}, {'Z', 10}
        };
        private static Dictionary<char, int> multiplier = new()
        {
            {'[', 3 },
            {'{', 2 }
        };

        private string _word;
        private int _wordMult = 1;
        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            _word = word.ToUpper();
            if (word.Length > 0)
            {
                if (multiplier.ContainsKey(word[0]))
                { 
                    _wordMult = multiplier[word[0]];
                    _word = _word.Substring(1);
                }
            }
        }

        public int score()
        {
            int result = 0;
            int charMultiplier = 1;
            foreach (char c in _word)
            {
                if (multiplier.ContainsKey(c)) 
                {  
                    charMultiplier = multiplier[c];
                    continue; 
                }
                int charValue = charValues.GetValueOrDefault(c, 0);
                result += charValue * charMultiplier;
                charMultiplier = 1;
            }
            return result * _wordMult;
        }


    }
}
