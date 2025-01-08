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
        public int totalScore = 0;


        Dictionary<char, int> data = new Dictionary<char, int>
        {
            {'A',1 }, {'B',3}, {'C',3}, {'D',2}, {'E',1},
            {'F',4 }, {'G',2}, {'H',4}, {'I',1}, {'J',8},
            {'K',5 }, {'L',1}, {'M',3}, {'N',1}, {'P',3},
            {'O',1 }, {'Q',10}, {'R',1}, {'S',1}, {'T',1},
            {'U',1 }, {'V',4}, {'W',4}, {'X',8}, {'Y',4},
            {'Z',10 }
        };

        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            List<char> letters = word.ToUpper().ToList();
            int curlyCount = 0;
            int brackCount = 0;

            for(int j = 0; j < letters.Count; j++)
            {
                if (letters[j] == '{' || letters[j] == '}')
                {
                    letters.RemoveAt(j);
                    curlyCount++;
                }else if (letters[j] == '[' || letters[j] == ']')
                {
                    letters.RemoveAt(j);
                    brackCount++;
                }
            }

            for (int i = 0; i < letters.Count; i++)
            {
                if (data.ContainsKey(letters[i]))
                {
                    totalScore += data[letters[i]];
                }
            }

            if (brackCount == 2)
            {
                totalScore = totalScore * 3;
            }
            else if (curlyCount == 2)
            {
                totalScore = totalScore * 2;
            }
        }

        public int score()
        {
            return totalScore;
        }
    }
}
