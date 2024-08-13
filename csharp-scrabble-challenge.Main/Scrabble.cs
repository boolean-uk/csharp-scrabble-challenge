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
            
            string str = word.Trim();
            _word = str.ToUpper();
            
        }

        public int score()
        {
            int score = 0;


            //TODO: score calculation code goes here

            if (_word.Equals(""))
            {
                return 0;
            }
            foreach (char w in _word)
            { 
                

                foreach (var s in letterValues.Keys)
                {
                    if (s.Contains(w))
                    {
                        score += letterValues[s];
                    }
                  

                }
          
            }

            if (_word.First() == '{' && _word.Last() == '}')
            {
                score *= 2;
            }else if (_word.First() == '[' && _word.Last() == ']')
            {
                score *= 3;
            }


          return score;
            
        }
    }
}
