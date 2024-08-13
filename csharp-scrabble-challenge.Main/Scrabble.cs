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

        public Scrabble(string word)
        {
            _word = word;
        }

        public int score()
        {
            _word = _word.ToLower();
            int score = 0;

            for (int i = 0; i < _word.Length; i++)
            {
                char c = _word[i];
                int charscore = ValueofChar(c);
                score += charscore;

            }
            return score;  

            //TODO: score calculation code goes here
            
        }
        private int ValueofChar(char ch)
        {

            Dictionary<char, int> lettervalue = new Dictionary<char, int>

            {
                {'A', 1}, {'E', 1}, {'I', 1}, {'O', 1}, {'U', 1}, {'L', 1}, {'N', 1}, {'R', 1}, {'S', 1}, {'T', 1},
                {'D', 2},  {'G', 2},
                {'B', 3}, {'C', 3}, {'M', 3}, {'P', 3},
                {'F', 4}, {'H', 4}, {'V', 4}, {'W', 4}, {'Y', 4},
                {'K', 5},
                {'J', 8}, {'X', 8},
                {'Q', 10}, {'Z', 10}

            };
            ch = char.ToUpper(ch);

            if (lettervalue.ContainsKey(ch))
            {
                return lettervalue[ch];
            }
            return 0;
        }
    }
}
  
