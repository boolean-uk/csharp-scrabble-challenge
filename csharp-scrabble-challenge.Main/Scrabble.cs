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
        Dictionary<char, int> letterScores = new Dictionary<char, int>
            {
                { 'A', 1 },
                { 'E', 1 },
                { 'I', 1 },
                { 'O', 1 },
                { 'U', 1 },
                { 'L', 1 },
                { 'N', 1 },
                { 'R', 1 },
                { 'S', 1 },
                { 'T', 1 },
                { 'D', 2 },
                { 'G', 2 },
                { 'B', 3 },
                { 'C', 3 },
                { 'M', 3 },
                { 'P', 3 },
                { 'F', 4 },
                { 'H', 4 },
                { 'V', 4 },
                { 'W', 4 },
                { 'Y', 4 },
                { 'K', 5 },
                { 'J', 8 },
                { 'X', 8 },
                { 'Q', 10 },
                { 'Z', 10 }, };

        string word;
        public Scrabble(string word)
        {
            //TODO: do something with the word variable

            /*                        | Letter | Value |
                        | ----                          | ----  |
                        | A, E, I, O, U, L, N, R, S, T | 1 |
                        | D, G | 2 |
                        | B, C, M, P | 3 |
                        | F, H, V, W, Y | 4 |
                        | K | 5 |
                        | J, X | 8 |
                        | Q, Z | 10 |*/

            this.word = word;

        }

            public int score()
                {
                    //TODO: score calculation code goes here
                 //TODO: Remove this line when the code has been writtenint


                int sum = 0;
                int wordMultiplier = 1;
                int charMultiplier = 1;


                if(word.StartsWith("{") || word.StartsWith("["))
                {
                    if(word.StartsWith("{")){ wordMultiplier = 2; }
                    if(word.StartsWith("[")){ wordMultiplier = 3; }

                word = word.Substring(1, word.Length - 2);

                }  

                string upperWord = this.word.Trim().Replace("\b", "").ToUpper();

                foreach (char letter in upperWord) { 

                    if (letter == '{') { charMultiplier = 2;continue; }
                    if (letter == '}') { charMultiplier = 1; continue; }
                    if (letter == '[') { charMultiplier = 3; continue; }
                    if (letter == ']') { charMultiplier = 1; continue; }


                int charScore = letterScores[letter] * charMultiplier;
                    sum += charScore;
                    }


                  return sum * wordMultiplier;
                }
            }
        }
    
