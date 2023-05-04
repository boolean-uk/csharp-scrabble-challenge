using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string _word;
        private int _doubleScore;
        private int _tripleScore;

        // create dictionary for letter scores
        Dictionary<char, int> letterScore = new Dictionary<char, int>()
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
            { 'Z', 10 }
        };

        public Scrabble(string word)
        {
            // TODO: do something with the word variable
            _word = word;
        }

        public int score()
        {
            // TODO: score calculation code goes here
            int score = 0;

            // Turn word into char array
            char[] charArr = _word.ToUpper().ToCharArray();

            // check if charArr contains nothing, return 0
            if (charArr.Length == 0)
            {
                return score;
            }

            // check if the word has curly brackets
            if (charArr[0] == '{' && charArr[charArr.Length - 1] == '}'  )
            {
                _doubleScore = 2;
            } else
            {
                _doubleScore = 1;
            }

            // check if the word has square brackets
            if (charArr[0] == '[' && charArr[charArr.Length - 1] == ']')
            {
                _tripleScore = 3;
            } else
            {
                _tripleScore = 1;
            }

            // iterate char array
            for (int i = 0; i < charArr.Length; i++)
            {
                // check for spaces, invalid words return 0
                if (Char.IsWhiteSpace(charArr[i]))
                {
                    score = 0;
                }
                else if (Char.IsAsciiLetter(charArr[i])) {
                    // lookup char score dictionary
                    if (letterScore.ContainsKey(charArr[i]))
                    {
                        // increment variable with score
                        score += letterScore[charArr[i]] * _doubleScore * _tripleScore;
                    }
                }
            }
            return score;
        }
    }
}
