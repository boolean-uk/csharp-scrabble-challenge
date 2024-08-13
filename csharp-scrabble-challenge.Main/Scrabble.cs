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
        public char[] wrd;
        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            if (word == null) throw new ArgumentNullException("no word");
            //turn string into list of chars
            char[] chars = word.ToUpper().ToCharArray();
            wrd = chars;
        }

        public int score()
        {
            //TODO: score calculation code goes here

            int score = 0;
            Dictionary<char[], int> point = new Dictionary<char[], int>();
            point.Add(['A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T'], 1);
            point.Add(['D', 'G'], 2);
            point.Add(['B', 'C', 'M', 'P'], 3);
            point.Add(['F', 'H', 'V', 'W', 'Y'], 4);
            point.Add(['K'], 5);
            point.Add(['J', 'X'], 8);
            point.Add(['Q', 'Z'], 10);


            int pos = 0;

            if(wrd.Length == 0)
            {
                return 0;
            }

            foreach (var character in wrd)
            {
                foreach (var row in point.Keys)
                {
                    foreach (var element in row)
                    {
                        if(character == element)
                        {
                            int nr = point[row];
                            if (pos > 0)
                            {
                                if ((wrd[pos - 1] == '{') && (wrd[pos + 1] == '}'))
                                {
                                    score += (2 * nr);
                                }
                                if ((wrd[pos - 1] == '[') && (wrd[pos + 1] == ']'))
                                {
                                    score += (3 * nr);
                                }
                                else
                                {
                                    score += nr;
                                }
                            }
                            else
                            {
                                score += nr;
                            }
                            
                        }
                    }
                }
                pos += 1;
            }
            if ((wrd.First() == '{') && (wrd.Last() == '}')){
                score += score;
            }
            if ((wrd.First() == '[') && (wrd.Last() == ']')){
                score += (2 *score);
            }

            return score;
            //throw new NotImplementedException(); //TODO: Remove this line when the code has been written
        }
    }
}
