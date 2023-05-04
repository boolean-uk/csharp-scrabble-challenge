using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Tracing;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string _word;
        public Scrabble(string word)
        {
            _word = word;

            // store word in private member
            //TODO: do something with the word variable
         
            

        }
            
        public int score()
        {
            // validty check
            // word to lowwer case
            // turn word into char array
            // itterate array
            // lookup char in score array
            // increment variable with score array
            Dictionary<char, int> letterValues = new Dictionary<char, int>()
            {
               {'a', 1},
               {'b', 3},
               {'c', 3},
               {'d', 2},
               {'e', 1},
               {'f', 4},
               {'g', 2},
               {'h', 4},
               {'i', 1},
               {'j', 8},
               {'k', 5},
               {'l', 1},
               {'m', 3},
               {'n', 1},
               {'o', 1},
               {'p', 3},
               {'q', 10},
               {'r', 1},
               {'s', 1},
               {'t', 1},
               {'u', 1},
               {'v', 4},
               {'w', 4},
               {'x', 8},
               {'y', 4},
               {'z', 10}
                
            };
            
            char[] charrArray = _word.ToLower().ToCharArray();
            int letterScore = 0;
          

            for(int i = 0; i < charrArray.Length; i++) 
            {
                if (Char.IsAsciiLetter(charrArray[i]))
                {
                    foreach (KeyValuePair<char, int> kvp in letterValues)
                        if (kvp.Key == charrArray[i])
                        {
                            letterScore += kvp.Value;
                        }
                }  else if ( charrArray[i].Equals("{") && charrArray[i + 2].Equals("}") )
                {
                    foreach (KeyValuePair<char, int> kvp in letterValues)
                        if (kvp.Key == charrArray[i+1])
                        {
                            letterScore += kvp.Value * 2;
                        }
                    i += 2;
                    break;
                }
                else if (charrArray[i].Equals("[") && charrArray[i + 2].Equals("]"))
                {
                    foreach (KeyValuePair<char, int> kvp in letterValues)
                        if (kvp.Key == charrArray[i]+1)
                        {
                            letterScore += kvp.Value * 3;
                        }
                    i += 2;
                    break;
                }



            }

            if (charrArray[0].Equals('{') && charrArray[charrArray.Length - 1].Equals('}'))
            {
                letterScore *= 2;
            }

           if (charrArray[0].Equals('[') && charrArray[charrArray.Length - 1].Equals(']'))
            {
                letterScore *= 3;
            }
            return letterScore;
           
                       
        }
    }
}
