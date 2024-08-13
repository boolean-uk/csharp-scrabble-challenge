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
        Dictionary<char, int> letterValue = new Dictionary<char, int>()
        {
            { 'A', 1},
            { 'E', 1},
            { 'I', 1},
            { 'O', 1},
            { 'U', 1},
            { 'L', 1},
            { 'N', 1},
            { 'R', 1},
            { 'S', 1},
            { 'T', 1},
            { 'D', 2},
            { 'G', 2},
            { 'B', 3},
            { 'C', 3},
            { 'M', 3},
            { 'P', 3},
            { 'F', 4},
            { 'H', 4},
            { 'V', 4},
            { 'W', 4},
            { 'Y', 4},
            { 'K', 5},
            { 'J', 8},
            { 'X', 8},
            { 'Q', 10},
            { 'Z', 10 }
        };

        private string _word;
        
        public Scrabble(string word)
        {
            _word = word;
        }

        public int score()
        {
            int wordscore = 0;
            bool doubleWord = false;

            if (_word == " ")
            {
                return 0;
            } 
            else
            {
                string uppercase = _word.ToUpper();
                char[] chars = uppercase.ToCharArray();
                
                foreach (var ch in chars)
                {
                    if (letterValue.ContainsKey(ch))
                    {
                        wordscore += letterValue[ch];
                    }                   
                }
                //Doubleword true - ok this is a cheesy solve lmao xD
                if (chars.Contains('}'))
                {
                    wordscore = wordscore * 2;
                }

                //Tripleword true
                if (chars.Contains(']'))
                {
                    wordscore = wordscore * 3;
                }
                return wordscore;
            }
        }
    }
}
