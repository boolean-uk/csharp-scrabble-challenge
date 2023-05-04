using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble

    {
        private string _word;
        private Dictionary<List<string>, int> _dictionary;

        public string word { get { return _word; } }

        /// <summary>
        /// initiating the dictionray 
        /// </summary>
        /// <param name="word"></param>
        public Scrabble(string word)
        {
            _word = word;
            _dictionary = new Dictionary<List<string>, int>();
            _dictionary.Add(new List<string>{"A", "E", "I", "O", "U", "L", "N", "R", "S", "T"}, 1);
            _dictionary.Add(new List<string> { "D", "G" }, 2);
            _dictionary.Add(new List<string> { "B", "C", "M", "P" }, 3);
            _dictionary.Add(new List<string> { "F", "H", "V", "W", "Y" }, 4);
            _dictionary.Add(new List<string> { "K" }, 5);
            _dictionary.Add(new List<string> { "J", "X" }, 8);
            _dictionary.Add(new List<string> { "Q", "Z" }, 10);


            






            //TODO: do something with the word variable
        }
        /// <summary>
        /// calculates the score of the given word looping through every letter and in every key of the dict that is a list of strings and when the letter found takes the value of the current 
        /// key and places it to the result variable
        /// </summary>
        /// <returns></returns>

        public int score()
        {
            int result =0;

            if(_word == " " || _word == "") {
                return result;
            
            }
            foreach(char c in _word.ToUpper())
            {
               foreach(List<string> list in _dictionary.Keys)
                {
                    if (list.Contains(c.ToString()))
                    {
                        result += _dictionary[list];
                        break;
                    }
                }
            }

            if (_word.ElementAt(0) == '{' && _word.ElementAt(_word.Count() -1) == '}') {

                result = result * 2;
            }
           else if (_word.ElementAt(0) == '[' && _word.ElementAt(_word.Count() - 1) == ']')
            {
                result = result * 3;

            }

            return result;
            //TODO: score calculation code goes here
           // throw new NotImplementedException(); //TODO: Remove this line when the code has been written


        }

       
    }
}
