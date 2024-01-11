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
        private Dictionary<char, int> letterScore = new Dictionary<char, int>();
        public Scrabble(string word)
        {
            _word = word.ToLower() ;
            FillLetterScores();
            //TODO: do something with the word variable
        }

        private void FillLetterScores()
        {
            int score = 0;
            string Alphabet = "abcdefghijklmnopqrstuvwxyz";
            foreach (char letter in Alphabet)
            {
                if ("aeioulnrst".Contains(letter)) score = 1;
                else if ("dg".Contains(letter)) score = 2;
                else if ("bcmp".Contains(letter)) score = 3;
                else if ("fhvwy".Contains(letter)) score = 4;
                else if ("k".Contains(letter)) score = 5;
                else if ("jx".Contains(letter)) score = 8;
                else if ("qz".Contains(letter)) score = 10;
                letterScore.Add(letter, score);
            }
        }

        public int score()
        {
            int result = 0;
            int modifier = 1;
            foreach (char letter in _word)
            {
                if (letterScore.ContainsKey(letter))
                {
                    result += letterScore[letter] * modifier;
                }
                else
                {
                    switch (letter)
                    {
                        case '{':
                            modifier *= 2;
                            break;
                        case '}':
                            modifier /= 2;
                            break;
                        case '[':
                            modifier *= 3;
                            break;
                        case ']':
                            modifier /= 3;
                            break;
                        default:
                            Console.WriteLine($"{letter} is not a valid input");
                            return 0;
                    }

                }
            }
            return result;
            //TODO: score calculation code goes here
        }
    }
}
