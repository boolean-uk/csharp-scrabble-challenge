using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string _word;
        private Dictionary<char[], int> _letters = new Dictionary<char[], int>();
        public Scrabble(string word)
        {            
            _word = word.ToUpper();
        }

        public int score()
        {
            int score = 0;
           
            _letters.Add(new char[] { 'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T' }, 1) ;
            _letters.Add(new char[] { 'D', 'G' }, 2);
            _letters.Add(new char[] { 'B', 'C', 'M', 'P' }, 3);
            _letters.Add(new char[] { 'F', 'H', 'V', 'W', 'Y' }, 4);
            _letters.Add(new char[] { 'K' }, 5);
            _letters.Add(new char[] { 'J', 'X' }, 8);
            _letters.Add(new char[] { 'Q', 'Z' }, 10);
            
            char[] charArr = _word.ToCharArray();

            if (charArr.Length == 0)
            {
                return score;
            }

            foreach (char c in charArr)
            {
                if (Char.IsWhiteSpace(c))
                {
                    return score;
                }

                if(Char.IsAsciiLetter(c))
                {
                    foreach (KeyValuePair<char[], int> kvp in _letters)
                    {
                        foreach (char c2 in kvp.Key)
                        {
                            if (c2 == c)
                            {
                                score += kvp.Value;
                            }
                        }
                    }
                }
            }

            if (_word.First() == '{' && _word.Last() == '}')
            {
                score *= 2;
            }

            if (_word.First() == '[' && _word.Last() == ']')
            {
                score *= 3;
            }
            return score;
        }
    }
}
