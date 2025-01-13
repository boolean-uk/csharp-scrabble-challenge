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
           _word = word.ToUpper();  
                
        }

        public int LetterValue(char letter)
        {
            int value = letter switch
            {
                'A' or 'E' or 'I' or 'O' or 'U' or 'L' or 'N' or 'R' or 'S' or 'T' => 1,
                'D' or 'G' => 2,
                'B' or 'C' or 'M' or 'P' => 3,
                'F' or 'H' or 'V' or 'W' or 'Y' => 4,
                'K' => 5,
                'J' or 'X' => 8,
                'Q' or 'Z' => 10,
                '{' or '}' or '[' or ']' => 0,
                _ => 0
            };
            return value;
        }

        public int score()
        {

            bool doublePoint = false;
            bool triplePoint = false;
            
            int score = 0;
            if (_word.Length == 0 || !IsValid(_word))
            {
                return score;
            }

            foreach (char c in _word)
            {

                if (c == '{')
                {
                    doublePoint = true;
                }
                else if (c == '[')
                {
                    triplePoint = true;
                }

                score += LetterValue(c);
            }
            if (doublePoint) { score = score * 2; }
            else if (triplePoint) { score = score * 3; }

            return score;
        }

        public bool IsValid(string word)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(word, @"^[a-zA-Z\[\]{}]+$");
        }
    }
}
