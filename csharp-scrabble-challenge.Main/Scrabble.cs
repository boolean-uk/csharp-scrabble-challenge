using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {

        private string _word { get; set; }
        private Dictionary<char, int> _scores = new Dictionary<char, int>()
{
    {'a', 1 },
    {'e', 1 },
    {'i', 1 },
    {'o', 1 },
    {'u', 1 },
    {'l', 1 },
    {'n', 1 },
    {'r', 1 },
    {'s', 1 },
    {'t', 1 },
    {'d', 2 },
    {'g', 2 },
    {'b', 3 },
    {'c', 3 },
    {'m', 3 },
    {'p', 3 },
    {'f', 4 },
    {'h', 4 },
    {'v', 4 },
    {'w', 4 },
    {'y', 4 },
    {'k', 5 },
    {'j', 8 },
    {'x', 8 },
    {'q', 10 },
    {'z', 10 },
};

        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            this._word = word;
            Dictionary<char, int> scores = new Dictionary<char, int>();



        }

        public int score()
        {
            //TODO: score calculation code goes here


            string wordLower = _word.ToLower();
            char[] wordToChar = wordLower.ToCharArray();
            int sum = 0;
            int charmultiplier = 1;
            int wordmultiplier = 1;

            int numberOfCurly = wordToChar.Where(x => x == '{' || x == '}').Count();
            int numberOfBrackets = wordToChar.Where(x => x == '[' || x == ']').Count();


            if (wordToChar.Length == 0)
            {
                return 0;
            }

            for(int i = 0; i < wordToChar.Length; i++)
            {
                char c = wordToChar[i];
           
                if (char.IsDigit(c))
                {
                    return 0;
                }
                if (char.IsLetter(c) || c == '{' || c == '}' || c == '[' || c == ']')
                {
                    if (_scores.GetValueOrDefault(c) == -1)
                    {


                        if (c == '{')
                        {
                            charmultiplier = 2;
                        }
                        else if (c == '[')
                        {
                            charmultiplier = 3;
                        }
                        else if (c == '}' || c == ']')
                        {
                            charmultiplier = 1;
                        }
                        else if (wordToChar[i - 1] == '{' && wordToChar[i + 1] == '}')
                        {
                            charmultiplier = 2;
                        }
                        else if (_scores.ContainsKey(c))
                        {
                            charmultiplier = 1;
                        }
                    }

                    if (_scores.ContainsKey(c))
                    {

                        sum += (_scores.GetValueOrDefault(c)) * charmultiplier;

                    }
                }
            }


            if (wordToChar[0] == '{' || wordToChar[0] == '[' && wordToChar[wordToChar.Length -1 ] == '}' || wordToChar[wordToChar.Length - 1] == ']')
            {
                if (numberOfCurly == 2)
                {
                    wordmultiplier = 2;
                }
                else if (numberOfBrackets == 2)
                {
                    wordmultiplier = 3;

                }

         

                if (numberOfCurly % 2 == 1 || numberOfBrackets % 2 == 1)
                {
                    sum = 0;
                }

                
            }
            return sum * wordmultiplier;
        }
    }
}

