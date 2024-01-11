using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string _word;
        private Dictionary<char, int> transform;
        private int multiplier = 1;

        // number of letters
/*        char[] letters = Enumerable.Range('A', 26).Select(x => (char) x).ToArray();
        int[] scores = { 
            1, 3, 3, 2, 1,
            4, 2, 4, 1, 8, 
            5, 1, 3, 1, 1, 
            3, 10, 1, 1, 1, 
            1, 4, 4, 8, 4, 10 
        };*/
        Dictionary<char, int> letterToScore = new Dictionary<char, int>
        {
            {'A', 1}, {'E', 1}, {'I', 1}, {'O', 1}, {'U', 1}, {'L', 1}, {'N', 1}, {'R', 1}, {'S', 1}, {'T', 1},
            {'D', 2}, {'G', 2},
            {'B', 3}, {'C', 3}, {'M', 3}, {'P', 3},
            {'F', 4}, {'H', 4}, {'V', 4}, {'W', 4}, {'Y', 4},
            {'K', 5},
            {'J', 8}, {'X', 8},
            {'Q', 10}, {'Z', 10}
        };

        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            _word = word.ToUpper().Trim();

            /*
            for ( int i = 0; i < letterToScore.Count; i++ )
            {
                letterToScore.Add(letters[i], scores[i]);
            }
            */
        }

        public int score()
        {
            //TODO: score calculation code goes here

            int total = 0;

            foreach ( char letter in _word )
            {
                try
                {
                    total += letterToScore[letter] * multiplier;
                }
                catch
                {
                    switch (letter)
                    {
                        case '{':
                            multiplier = 2;
                            break;
                        case '}':
                            multiplier = 1;
                            break;
                        case '[':
                            multiplier = 3;
                            break;
                        case ']':
                            multiplier = 1;
                            break;
                        default:
                            return 0;
                    }
                }
            }
            

            return total;
        }
    }
}
