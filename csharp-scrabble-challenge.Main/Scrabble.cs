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
        private Dictionary<char, int> letterScores = new Dictionary<char, int>
            {
                { 'A', 1 }, { 'E', 1 }, { 'I', 1 }, { 'O', 1 }, { 'U', 1 }, { 'L', 1 }, { 'N', 1 }, { 'R', 1 }, { 'S', 1 }, { 'T', 1 },
                { 'D', 2 }, { 'G', 2 },
                { 'B', 3 }, { 'C', 3 }, { 'M', 3 }, { 'P', 3 },
                { 'F', 4 }, { 'H', 4 }, { 'V', 4 }, { 'W', 4 }, { 'Y', 4 },
                { 'K', 5 },
                { 'J', 8 }, { 'X', 8 },
                { 'Q', 10 }, { 'Z', 10 },
                { '{', 0 }, { '[', 0 }
            };

        char[] wordarray;
        int scorecount = 0;


        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            wordarray = word.ToUpper().ToCharArray();

        }

        public int score()
        {
            //TODO: score calculation code goes here
            foreach (char c in wordarray)
            {
                if (letterScores.ContainsKey(c))
                {
                    scorecount = scorecount + letterScores[c];
                }
            }
            foreach (char c in wordarray)
            {
                if (c.ToString() == "{")
                {
                    scorecount = scorecount * 2;
                }
                if (c.ToString() == "[")
                {
                    scorecount = scorecount * 3;
                }
            }
            Console.WriteLine(scorecount);
            return scorecount;
        }
    }
}
