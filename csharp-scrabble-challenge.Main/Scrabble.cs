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
        public string _word { get; set; }
        public Scrabble(string word)
        {
            //TODO: do something with the word
            this._word = word;
        }

        public int score()
        {
            //TODO: score calculation code goes here
            Dictionary<char, int> points = new Dictionary<char, int>()
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
                { 'Z', 10},
            };

            string wordToUpperCase = _word.ToUpper();
            int wordScore = 0;
            bool doublePoints = false;
            bool tripplePoints = false;

            foreach (char c in wordToUpperCase)
            {
                switch (c)
                {
                    case '{':
                        doublePoints = true;
                        continue;
                    case '}':
                        doublePoints = false;
                        continue;
                    case '[':
                        tripplePoints = true;
                        continue;
                    case ']':
                        tripplePoints = false;
                        continue;
                }

                if (points.ContainsKey(c))
                {
                    int multiplier = 1;
                    multiplier = tripplePoints ? 3 : doublePoints ? 2 : 1;
                    wordScore += points[c] * multiplier;
                }
            }

            return wordScore;
        }
    }
}