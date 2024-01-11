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

        public Scrabble(string word)
        {            
            //TODO: do something with the word variable
            this.word = word;
        }

        public int score()
        {
            int totalScore = 0;
            int multiplier = 1;
            this.word = this.word.ToLower();

            for (int i = 0; i < word.Length; i++)
            {
                // Core assignment
                if (word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u' || word[i] == 'l' || word[i] == 'n'
                    || word[i] == 'r' || word[i] == 's' || word[i] == 't')
                    totalScore += 1 * multiplier;
                else if (word[i] == 'd' || word[i] == 'g')
                    totalScore += 2 * multiplier;
                else if (word[i] == 'b' || word[i] == 'c' || word[i] == 'm' || word[i] == 'p')
                    totalScore += 3 * multiplier;
                else if (word[i] == 'f' || word[i] == 'h' || word[i] == 'v' || word[i] == 'w' || word[i] == 'y')
                    totalScore += 4 * multiplier;
                else if (word[i] == 'k')
                    totalScore += 5 * multiplier;
                else if (word[i] == 'j' || word[i] == 'x')
                    totalScore += 8 * multiplier;
                else if (word[i] == 'q' || word[i] == 'z')
                    totalScore += 10 * multiplier;

                // Extension assignment
                else if (word[i] == '{')
                    multiplier *= 2;
                else if (word[i] == '}')
                    multiplier /= 2;
                else if (word[i] == '[')
                    multiplier *= 3;
                else if (word[i] == ']')
                    multiplier /= 3;
            }

            return totalScore;
        }
    }
}
