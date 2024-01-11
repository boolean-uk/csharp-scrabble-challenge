using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string _word;
        private Dictionary<char, int> _letterValues = new Dictionary<char, int>
        {
            {'A', 1}, {'E', 1}, {'I', 1}, {'O', 1}, {'U', 1}, {'L', 1}, {'N', 1}, {'R', 1}, {'S', 1}, {'T', 1},
            {'D', 2}, {'G', 2},
            {'B', 3}, {'C', 3}, {'M', 3}, {'P', 3},
            {'F', 4}, {'H', 4}, {'V', 4}, {'W', 4}, {'Y', 4},
            {'K', 5},
            {'J', 8}, {'X', 8},
            {'Q', 10}, {'Z', 10}
        };

        public Scrabble(string word)
        {            
            _word = word.ToUpper();
        }

        public int score()
        {
            //TODO: score calculation code goes here
            int score = 0;

            foreach (char letter in _word)
            {
                score += _letterValues.GetValueOrDefault(letter, 0);
            }

            string patternDoubleScore = @"\{(.*?)\}";
            string patternTrippleScore = @"\[(.*?)\]";

            Match doubleMatch = Regex.Match(_word, patternDoubleScore);
            Match trippleMatch = Regex.Match(_word, patternTrippleScore);

            if (doubleMatch.Success)
            {
                string doubleScoreString = doubleMatch.Groups[1].Value;

                foreach (char letter in doubleScoreString)
                {
                    score += _letterValues.GetValueOrDefault(letter, 0);
                }
            }

            if (trippleMatch.Success)
            {
                string trippleScoreString = trippleMatch.Groups[1].Value;

                foreach (char letter in trippleScoreString)
                {
                    score += _letterValues.GetValueOrDefault(letter, 0)*2;
                }
            }

            return score;
        }
    }
}
