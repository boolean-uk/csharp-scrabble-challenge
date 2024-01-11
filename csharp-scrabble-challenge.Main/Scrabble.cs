using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {

        public string _word;
        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            _word = word;
        }

        public string word { get { return _word; } }


        public int score()
        {
            //TODO: score calculation code goes here
            int score = 0;

            Dictionary<char, int> scrabble = new Dictionary<char, int>()
        {
            {'A', 1},
            {'B', 3},
            {'C', 3},
            {'D', 2},
            {'E', 1},
            {'F', 4},
            {'G', 2},
            {'H', 4},
            {'I', 1},
            {'J', 4},
            {'K', 5},
            {'L', 1},
            {'M', 3},
            {'N', 1},
            {'O', 1},
            {'P', 3},
            {'Q', 10},
            {'R', 1},
            {'S', 1},
            {'T', 1},
            {'U', 1},
            {'V', 4},
            {'W', 4},
            {'X', 8},
            {'Y', 4},
            {'Z', 10}
        };
            _word = word.ToUpper(); // char and keys are case sensitive
            foreach (char c in _word)
            {
                foreach (KeyValuePair<char, int> kvp in scrabble)
                {
                    if (kvp.Key == c)
                    {
                        score += kvp.Value;
                        
                    }
                }
            }
            if (_word.Contains("[") && _word.Contains("]")) 
            {
                score = score * 3; //extension triple word score
            }
            else if (_word.Contains("{") && _word.Contains("}"))
            { 
                score = score * 2; //extension double word score
            }

            return score;
                
            //throw new NotImplementedException(); //TODO: Remove this line when the code has been written
        }
    }
}
