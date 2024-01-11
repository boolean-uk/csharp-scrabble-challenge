using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        public string Word { get; set; }
        public Scrabble(string word)
        {            
            Word = word;
        }

        public int score()
        {
            //TODO: score calculation code goes here
            int score = 0;
            int multiplier = 1;

            foreach (char c in Word) 
            {
                switch (Char.ToUpper(c))
                {
                    case '{':
                        multiplier = 2;
                        break;
                    case '}':
                        multiplier = 1;
                        break;
                    case '[':
                        multiplier = 3;
                        break;
                    case ']':
                        multiplier = 1;
                        break;
                    case 'A':
                    case 'E':
                    case 'I':
                    case 'O':
                    case 'U':
                    case 'L':
                    case 'N':
                    case 'R':
                    case 'S':
                    case 'T':
                        score += 1 * multiplier;
                        break;
                    case 'D':
                    case 'G':
                        score += 2 * multiplier;
                        break;
                    case 'B':
                    case 'C':
                    case 'M':
                    case 'P':
                        score += 3 * multiplier;
                        break;
                    case 'F':
                    case 'H':
                    case 'V':
                    case 'W':
                    case 'Y':
                        score += 4 * multiplier;
                        break;
                    case 'K':
                        score += 5 * multiplier;
                        break;
                    case 'J':
                    case 'X':
                        score += 8 * multiplier;
                        break;
                    case 'Q':
                    case 'Z':
                        score += 10 * multiplier;
                        break;
                    default:
                        break;
                }
            }
            return score;
        }
    }
}
