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
        string _word = "";
        public Scrabble(string word)
        {            
            _word = word;
            //TODO: do something with the word variable
        }

        public int score()
        {
            int score = 0;
            int mult = 1;
            //TODO: score calculation code goes here

            for(int i = 0; i < _word.Length; i++)
            {
                switch (char.ToLower(_word[i]))
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                    case 'l':
                    case 'n':
                    case 'r':
                    case 's':
                    case 't':
                        score += (mult * 1);
                        break;
                    case 'd':
                    case 'g':
                        score += (mult * 2);
                        break;
                    case 'b':
                    case 'c':
                    case 'm':
                    case 'p':
                        score += (mult * 3);
                        break;
                    case 'f':
                    case 'h':
                    case 'v':
                    case 'w':
                    case 'y':
                        score += (mult * 4);
                        break;
                    case 'k':
                        score += (mult * 5);
                        break;
                    case 'j':
                    case 'x':
                        score += (mult * 8);
                        break;
                    case 'q':
                    case 'z':
                        score += (mult * 10);
                        break;
                    case '{':
                        mult = 2;
                        break;
                    case '}':
                        mult = 1;
                        break;
                    case '[':
                        mult = 3;
                        break;
                    case ']':
                        mult = 1;
                        break;
                }
            }
            return score; 
        }
    }
}
