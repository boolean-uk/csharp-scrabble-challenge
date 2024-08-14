using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private readonly char[] chars;

        public Scrabble(string word)
        {            
            //TODO: do something with the word variable

            if (word == null) throw new ArgumentNullException("No word!");

            // create a list of char of the word
            chars = word.ToUpper().ToCharArray();

        }

        public int score()
        {
            //TODO: score calculation code goes here

            // Calculate value of each letter in a dictionary
            Dictionary<char, int> scores = new Dictionary<char, int>();
            scores.Add('A', 1);
            scores.Add('E', 1);
            scores.Add('I', 1);
            scores.Add('O', 1);
            scores.Add('U', 1);
            scores.Add('L', 1);
            scores.Add('N', 1);
            scores.Add('R', 1);
            scores.Add('S', 1);
            scores.Add('T', 1);
            
            scores.Add('D', 2);
            scores.Add('G', 2);

            scores.Add('B', 3);
            scores.Add('C', 3);
            scores.Add('M', 3);
            scores.Add('P', 3);

            scores.Add('F', 4);
            scores.Add('H', 4);
            scores.Add('V', 4);
            scores.Add('W', 4);
            scores.Add('Y', 4);

            scores.Add('K', 5);

            scores.Add('J', 8);
            scores.Add('X', 8);

            scores.Add('Q', 10);
            scores.Add('Z', 10);

            if (chars.Length < 0)
            {
                return 0;
            }

            int points = 0;
            int pos = 0;


            foreach (var c in chars) {
                foreach (var letter in scores)
                {

                    if (pos > 0 && c == letter.Key)
                    {
                        if (chars[pos - 1] == '{' && chars[pos + 1] == '}')
                        {
                            points += letter.Value * 2;
                        }
                        else if (chars[pos - 1] == '[' && chars[pos + 1] == ']')
                        {
                            points += letter.Value * 3;
                        }
                    }
                    else
                    {
                        points += letter.Value;
                    }
                }
                pos += 1;
            }


                if (chars.First() == '{' && chars.Last() == '}')
                {
                    points += points;
                }
                if (chars.First() == '[' && chars.Last() == ']')
                {
                    points += points*2;
                }
    

            return points;
        }
    }
}
