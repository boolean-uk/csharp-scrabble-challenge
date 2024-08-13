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
        public Dictionary<string, int> letterValues = new Dictionary<string, int>()
        {
            {"AEIOULNRST", 1 },
            {"DG" , 2 },
            {"BCMP" , 3 },
            { "FHVWY" , 4 },
            { "K" , 5 },
            { "JX" , 8 },
            { "QZ" , 10 }
        };

        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            string wordInUpper = word.ToUpper();
            _word = wordInUpper;
            
        }

        public int score()
        {
            //TODO: score calculation code goes here
            int score = 0;

            if (_word == "")
            {
                return score;
            }

            foreach (char c in _word)
            {
                foreach (string word in letterValues.Keys) 
                {
                    if (word.Contains(c))
                    {
                        score += letterValues[word];
                    }
                }
            }

            if (_word.First() == '{' & _word.Last() == '}') 
            {
                score *= 2;
            } else if (_word.First() == '[' & _word.Last() == ']') 
            {
                score *= 3;
            }

            return score;
        }

        /*
        public int getValueByChar(char character)
        {
            int value = 0;

            foreach (string word in letterValues.Keys)
            {
                if (word.Contains(character))
                {
                    value = letterValues[word];
                    return value;
                }
            }
            
            return value;
        }
        */
    }
}
