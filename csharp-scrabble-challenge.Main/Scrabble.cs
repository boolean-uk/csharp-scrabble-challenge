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
        private string word;
        private Dictionary<char, int> letterValue = new Dictionary<char, int>
        {
            ['a'] = 1 ,
            ['e'] = 1 ,
            ['i'] = 1 ,
            ['o'] = 1 ,
            ['s'] = 1 ,
            ['u'] = 1 ,
            ['l'] = 1 ,
            ['n'] = 1 ,
            ['r'] = 1 ,
            ['t'] = 1 ,
            ['d'] = 2 ,
            ['g'] = 2 ,
            ['b'] = 3 ,
            ['c'] = 3 ,
            ['m'] = 3 ,
            ['p'] = 3 ,
            ['f'] = 4 ,
            ['h'] = 4 ,
            ['v'] = 4 ,
            ['w']   = 4 ,
            ['y'] = 4 ,
            ['k'] = 5 ,
            ['j'] = 8 ,
            ['x'] = 8 ,
            ['q'] = 10,
            ['z'] = 10

        };
        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            this.word = word.ToLower();
        }

        public int score()
        {
           
            //TODO: score calculation code goes here

            int score = 0;
            int wordLength = word.Length;
            bool doubleWord = false;
            bool tripleWord = false;


            int i = 0;
            while (i < wordLength) {

                if (word[i] == '{')
                {
                    if (word[i + 2] == '}' && letterValue.ContainsKey(word[i + 1]))
                    {
                        score += letterValue[word[i + 1]] * 2;
                        i = i + 3;
                    }
                    else if (i == 0 && word[^1] == '}')
                    {
                        doubleWord = true;
                        wordLength--;
                        i++;
                    }
                    else return 0;

                }

                else if (word[i] == '[')
                {
                    if (word[i + 2] == ']' && letterValue.ContainsKey(word[i + 1]))
                    {
                        score += letterValue[word[i + 1]] * 3;
                        i = i + 3;
                    }
                    else if (i == 0 && word[^1] == ']')
                    {
                        tripleWord = true;
                        wordLength--;
                        i++;
                    }
                    else return 0;

                }

                else if (letterValue.ContainsKey(word[i]))
                {
                    score += letterValue[word[i]];
                    i++;
                }
                else return 0;
            }
  
            if (doubleWord)
            {
                return score * 2;
            }
            if (tripleWord)
            {
                return score * 3;
            }
            return score;
            
        }
    }
}
