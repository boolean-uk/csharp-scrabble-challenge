using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        //public Dictionary<char[], int> letterValues = new Dictionary<char[], int>() {
        //    {['A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T'], 1 },
        //    {['D', 'G'], 2 },
        //    {['B', 'C', 'M', 'P'], 3 },
        //    {['F', 'H', 'V', 'W', 'Y'], 4 },
        //    {['K'], 5 },
        //    {['J', 'X'], 8 },
        //    {['Q', 'Z'], 10 },

        //};
        public Dictionary<string, int> letterValues = new Dictionary<string, int>() {
            {"AEIOULNRST", 1 },
            {"DG", 2 },
            {"BCMP", 3 },
            {"FHVWY", 4 },
            {"K", 5 },
            {"JX", 8 },
            {"QZ", 10 },

        };
        public string word;
        public Scrabble(string Word)
        {
            word = Word.ToUpper();
            //TODO: do something with the word variable

        }

        public int score()
        {
            bool multiplyByTwo = false;
            bool multiplyByThree = false;
            int score = 0;
            char[] wordAsArray = word.ToCharArray();
            foreach (char c in wordAsArray)
            {
                if(c =='{')
                {
                    multiplyByTwo = true;
                    multiplyByThree = false;
                }
                else if(c == '[')
                {
                    multiplyByThree = true;
                    multiplyByTwo = false;
                }
                foreach (var item in letterValues)
                {
                    if (item.Key.Contains(c))
                    {
                        score += item.Value;
                    }
                }
            }
            //TODO: score calculation code goes here
            if(multiplyByTwo)
            {
                return score * 2;
            }
            else if (multiplyByThree)
            {
                return score * 3;
            }
            return score;
        }
    }
}
