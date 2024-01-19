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
        /*
| Letter                        | Value  |
| ----                          |  ----  |
| A, E, I, O, U, L, N, R, S, T  |     1  |
| D, G                          |     2  |
| B, C, M, P                    |     3  |
| F, H, V, W, Y                 |     4  |
| K                             |     5  |
| J, X                          |     8  |
| Q, Z                          |     10 |
         */
        Dictionary<char, int> letterValues = new Dictionary<char, int>
        {
            { 'A', 1 },{ 'E', 1 },{ 'I', 1 },{ 'O', 1 },{ 'U', 1 },{ 'L', 1 },{ 'N', 1 },{ 'R', 1 },{ 'S', 1 },{ 'T', 1 },
            { 'D', 2 },{ 'G', 2 },
            { 'B', 3 },{ 'C', 3 },{ 'M', 3 },{ 'P', 3 },
            { 'F', 4 },{ 'H', 4 },{ 'V', 4 },{ 'W', 4 },{ 'Y', 4 },
            { 'K', 5 },
            { 'J', 8 },{ 'X', 8 },
            { 'Q', 10 },{ 'Z', 10 }
        };

        string word;

        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            this.word = word.ToUpper();
            
        }

        public int score()
        {
            int score = 0;
            //TODO: score calculation code goes here
            foreach (var letter in this.word)
            {
                if (letterValues.ContainsKey(letter))
                {
                    score += letterValues[letter];
                }
            }
            return score;

            //throw new NotImplementedException(); //TODO: Remove this line when the code has been written
        }

        public int scoreExtension()
        {
            // doubeling and trippeling changes if the current letter is inside of a bracket or square bracket
            int doubling = 1;
            int trippeling = 1;
            int score = 0;
            foreach (var letter in this.word) 
            {
                if (letter.Equals('{')) doubling *= 2;
                else if (letter.Equals('}')) doubling /= 2;
                else if (letter.Equals('[')) trippeling *= 3;
                else if (letter.Equals(']')) trippeling /= 3;
                else if (letterValues.ContainsKey(letter))
                {
                    score += letterValues[letter] * doubling * trippeling;
                }
            }
            return score;
            //throw new NotImplementedException();
        }
    }
}
