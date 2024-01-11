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

        private string _word = ""; 
        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            _word = word.ToUpper();
            
        }

        public int score()
        {
            //TODO: score calculation code goes here
            //TODO: Remove this line when the code has been written

            char[] onePoint = ['A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T'];
            char[] twoPoints = ['D', 'G'];
            char[] threePoints = ['B', 'C', 'M', 'P'];
            char[] fourPoints = ['F', 'H', 'V', 'W', 'Y'];
            char[] fivePoints = ['K'];
            char[] eightPoints = ['J', 'X'];
            char[] tenPoints = ['Q', 'Z'];

            int sum = 0;
            bool doublePoints = false;
            bool trippleWord = false;

            foreach (char letter in _word)
            {
                int letterScore = 0;

                if (letter == '{')
                {
                    doublePoints = true;
                    continue;
                } 
                else if (letter == '}')
                {
                    doublePoints = false;
                    continue;
                }

                if (letter == '[')
                {
                    trippleWord = true;
                    continue;
                }
                else if (letter == ']')
                    continue;

                if (onePoint.Contains(letter))
                    letterScore += 1;
                else if (twoPoints.Contains(letter))
                    letterScore += 2;
                else if (threePoints.Contains(letter))
                    letterScore += 3;
                else if (fourPoints.Contains(letter))
                    letterScore += 4;
                else if (fivePoints.Contains(letter))
                    letterScore += 5;
                else if (eightPoints.Contains(letter))
                    letterScore += 8;
                else if (tenPoints.Contains(letter))
                    letterScore += 10;

                if (doublePoints)
                    letterScore *= 2;

                sum += letterScore;
            }

            if (trippleWord)
            {
                sum *= 3;
            }
            return sum;

            
        }
    }
}
