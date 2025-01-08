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
        private Dictionary<Char, int> letterValueDict = new Dictionary<Char, int>(){
            {'A', 1},
            {'E', 1},
            {'I', 1},
            {'O', 1},
            {'U', 1},
            {'L', 1},
            {'N', 1},
            {'R', 1},
            {'S', 1},
            {'T', 1},
            {'D', 2},
            {'G', 2},
            {'B', 3},
            {'C', 3},
            {'M', 3},
            {'P', 3},
            {'F', 4},
            {'H', 4},
            {'V', 4},
            {'W', 4},
            {'Y', 4},
            {'K', 5},
            {'J', 8},
            {'X', 8},
            {'Q', 10},
            {'Z', 10}
        };


        private string word;

        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            this.word = word.Trim().ToUpper();
        }

        public int score()
        {
            int score = 0;
            bool doubleScore = false;
            bool tripleScore = false;

            foreach (char c in this.word.ToCharArray()) { 
                if (c == '[') { 
                    tripleScore = true;
                    continue;
                }
                else if (c == '{') { 
                    doubleScore = true;
                    continue;
                }
                else if (c == ']') {
                    //bracket wrong way
                    if (!tripleScore) return 0;

                    tripleScore = false;
                    continue;
                }
                else if (c == '}') {
                    //bracket wrong way
                    if (!doubleScore) return 0;

                    doubleScore = false;
                    continue;
                }

                int letterValue = 0;
                if (this.letterValueDict.TryGetValue(c, out letterValue))
                {

                    if (tripleScore && doubleScore) { score += letterValue * 6; }
                    else if (tripleScore) { score += letterValue * 3; }
                    else if (doubleScore) { score += letterValue * 2; }
                    else { score += letterValue; }
                }
                else return 0;

            }


            if (doubleScore || tripleScore) return 0;
            return score;
            //return this.word.ToUpper().Aggregate(0, (sum, c) => sum + this.letterValueDict[c]);
        }
    }
}
