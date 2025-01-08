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
        string _word { get; set; }
        Dictionary<List<char>, int> _letterScore { get; set; }
        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            _word = word;

            List<char> group1 = new List<char>
            {
                'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T',
            };

            List<char> group2 = new List<char>
            {
                'D', 'G'
            };

            List<char> group3 = new List<char>
            {
                'B', 'C', 'M', 'P'
            };

            List<char> group4 = new List<char>
            {
                'F', 'H', 'V', 'W', 'Y'
            };

            List<char> group5 = new List<char>
            {
                'K'
            };

            List<char> group6 = new List<char>
            {
                'J', 'X'
            };

            List<char> group7 = new List<char>
            {
                'Q', 'Z'
            };


            _letterScore = new Dictionary<List<char>, int>
            {
                {group1, 1}, {group2, 2 }, {group3, 3 }, {group4, 4}, {group5, 5 }, {group6, 8 }, {group7, 10}
            };
        }

        public int score()
        {
            if (_word.Length == 0)
            {
                return 0;
            }
            int totalScore = 0;
            int nextLetterScore = 0;

            //init wordscaling
            int wordscaling = 1;
            if (_word.First() == '{' && _word.Last() == '}')
            {
                wordscaling = 2;
                _word = _word.Substring(0, _word.Length - 2);
            }

            else if (_word.First() == '[' && _word.Last() == ']')
            {
                wordscaling = 3;
                _word = _word.Substring(0, _word.Length - 2);

            }
            

            for (int i = 0; i < _word.Length; i++)
            {
                nextLetterScore = 0;
                char bigC = char.ToUpper(_word[i]);


                if (char.IsLetter(bigC))
                {
                    nextLetterScore = _letterScore.Where(x => x.Key.Contains(bigC)).FirstOrDefault().Value;
                }
                else if (bigC == '{') 
                {
                 if ((_word.Length > i + 2))
                    {
                        if (_word[i+2] == '}')
                        {
                            bigC = char.ToUpper(_word[i+1]);
                            nextLetterScore = _letterScore.Where(x => x.Key.Contains(bigC)).FirstOrDefault().Value * 2;
                        }
                    }
 
                }

                else if (bigC == '[')
                {
                    if ((_word.Length > i + 2))
                    {
                        if (_word[i + 2] == ']')
                        {
                            bigC = char.ToUpper(_word[i + 1]);
                            nextLetterScore = _letterScore.Where(x => x.Key.Contains(bigC)).FirstOrDefault().Value * 3;
                        }
                    }
                }

                else
                {
                    return 0;
                }
                
                totalScore += nextLetterScore;
            }

            return totalScore * wordscaling;
        }




    }


}
