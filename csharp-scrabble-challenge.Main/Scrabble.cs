using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private int sum { get; set; }

        private static Dictionary<char, int> letterScore = new Dictionary<char, int>()
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

            int multiplier = 1;
        
            if (word == null) throw new ArgumentNullException();
            
            foreach (char ch in word.ToUpper())
            {
                switch (ch)
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
                        if (letterScore.ContainsKey(ch)) { this.sum += letterScore[ch] * multiplier; }
                        break;
                }
            };
        }

            

        public int score()
        {
            //TODO: score calculation code goes here
            //throw new NotImplementedException(); //TODO: Remove this line when the code has been written
            return this.sum;
        }

    }
}
