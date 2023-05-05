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
        private Dictionary<String, int> _letters = new Dictionary<String, int>();
        public Scrabble(string word)
        {            
            _word = word.ToUpper();
        }

        public int score()
        {
            int score = 0;
           
            _letters.Add("AEIOULNRST", 1) ;
            _letters.Add("DG", 2);
            _letters.Add("BCMP", 3);
            _letters.Add("FHVWY", 4);
            _letters.Add("K", 5);
            _letters.Add("JX", 8);
            _letters.Add("QZ", 10);
            

            if (_word.Length == 0)
            {
                return score;
            }

            for (int i = 0; i < _word.Length; i++)
            {
                if (Char.IsWhiteSpace(_word[i]))
                {
                    return score;
                }

                if (_word[i] == '{' && _word[i + 2] == '}')
                {
                    foreach (KeyValuePair<String, int> kvp in _letters)
                    {
                        if (kvp.Key.Contains(_word[i + 1]))
                        {
                            score += kvp.Value * 2;
                        }
                        i += 2;
                        break;
                    }
                }

                if (_word[i] == '[' && _word[i + 2] == ']')
                {
                    foreach (KeyValuePair<String, int> kvp in _letters)
                    {
                        if (kvp.Key.Contains(_word[i + 1]))
                        {
                            score += kvp.Value * 3;
                        }
                        i += 2;
                        break;
                    }
                }

                if (Char.IsAsciiLetter(_word[i]))
                {
                    foreach (KeyValuePair<String, int> kvp in _letters)
                    {
                        if (kvp.Key.Contains(_word[i]))
                        {
                            score += kvp.Value;
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
