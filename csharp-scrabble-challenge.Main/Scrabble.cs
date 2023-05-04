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
        private bool _curlyLeftBracket = false;
        private bool _curlyRightBracket = false;
        private bool _squareLeftBracket = false;
        private bool _squareRightBracket = false;
        private char[] _symbols = { '{', '}', '[', ']' };
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

            if (charArr[0] == _symbols[0] && charArr[charArr.Length - 1] == _symbols[1])
            {
                _curlyLeftBracket = true;
                _curlyRightBracket = true;
            }

            if (charArr[0] == _symbols[2] && charArr[charArr.Length - 1] == _symbols[3])
            {
                _squareLeftBracket = true;
                _squareRightBracket = true;
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
                            if (c2 == c && _curlyLeftBracket == true && _curlyRightBracket == true)
                            {
                                score = score + kvp.Value * 2;
                            } else if (c2 == c && _squareLeftBracket == true && _squareRightBracket == true)
                            {
                                score = score + kvp.Value * 3;
                            } else if (c2 == c) {
                                score = score + kvp.Value;
                            }
                        }
                    }
                }
            }
            return score;
        }
    }
}
