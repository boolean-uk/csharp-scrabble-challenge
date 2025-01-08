using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        string word;
        int scoreCounter;
        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            this.word = word.ToUpper();
            this.scoreCounter = 0;
        }

        public int score()
        {
            foreach (char letter in word.ToCharArray())
            {

                switch (letter) // Ensure case insensitivity
                {
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
                        scoreCounter += 1;
                        break;
                    case 'D':
                    case 'G':
                        scoreCounter += 2;
                        break;
                    case 'B':
                    case 'C':
                    case 'M':
                    case 'P':
                        scoreCounter += 3;
                        break;
                    case 'F':
                    case 'H':
                    case 'V':
                    case 'W':
                    case 'Y':
                        scoreCounter += 4;
                        break;
                    case 'K':
                        scoreCounter += 5;
                        break;
                    case 'J':
                    case 'X':
                        scoreCounter += 8;
                        break;
                    case 'Q':
                    case 'Z':
                        scoreCounter +=10;
                        break;
                    default:
                        scoreCounter = 0; // Default value for invalid input
                        break;
                }
            }
            //TODO: score calculation code goes here
            return scoreCounter;
        }
    }
}
