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
        private char[] _word;
        
        public Scrabble(string word)
        {
            _word = word.ToUpper().ToCharArray();
        }

        public int score()
        {
            Dictionary<string, int> values = new Dictionary<string, int>();
            // char instead of string
            //{
            //    {'A', 1},

            //};
            values.Add("A", 1);
            values.Add("E", 1);
            values.Add("I", 1);
            values.Add("O", 1);
            values.Add("U", 1);
            values.Add("L", 1);
            values.Add("N", 1);
            values.Add("R", 1);
            values.Add("S", 1);
            values.Add("T", 1);
            values.Add("D", 2);
            values.Add("G", 2);
            values.Add("B", 3);
            values.Add("C", 3);
            values.Add("M", 3);
            values.Add("P", 3);
            values.Add("F", 4);
            values.Add("H", 4);
            values.Add("V", 4);
            values.Add("W", 4);
            values.Add("Y", 4);
            values.Add("J", 8);
            values.Add("X", 8);
            values.Add("K", 5);
            values.Add("Q", 10);
            values.Add("Z", 10);
            int result = 0;
            if (_word.Length == 0)
            {
                return result;
            }

            for (int i =0; i<_word.Length;i++)
            { 
                if (Char.IsAsciiLetter(_word[i]))
                {
                    if (values.ContainsKey(_word[i].ToString()))
                        { 
                            result +=  values[_word[i].ToString()]; 
                       } 
                    //result += values[_word[i].ToString()];
                    //for (int j = 0; j< values.Count; j++)
                    //{ 
                    //    if (values.ContainsKey(_word[i].ToString()))
                    //    { 
                    //        result +=  values[_word[i].ToString()]; 
                    //    } 

                }
                else 
                {
                    result = result;
                }
            }
            if (_word.First() == '{' && _word.Last() == '}')
            {
                result *= 2;
            }
            if (_word.First() == '[' && _word.Last() == ']')
            //(_word.ToString().StartsWith("[") && _word.ToString().EndsWith("]"))
            {
                result *= 3;
            }

            // validity checks - return 0
            // turn word into char array
            // iterate array
            // loopup char in score array? > dict?
            // increment variabel with score
            // Char.

            //TODO: score calculation code goes here
            return result;
        }
    }
}
