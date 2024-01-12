using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string word;
        private int score;

        private static readonly Dictionary<char, int> letterValues = new Dictionary<char, int>
        {
            { 'A', 1 }, { 'B', 3 }, { 'C', 3 }, { 'D', 2 }, { 'E', 1 },
            { 'F', 4 }, { 'G', 2 }, { 'H', 4 }, { 'I', 1 }, { 'J', 8 },
            { 'K', 5 }, { 'L', 1 }, { 'M', 3 }, { 'N', 1 }, { 'O', 1 },
            { 'P', 3 }, { 'Q', 10 }, { 'R', 1 }, { 'S', 1 }, { 'T', 1 },
            { 'U', 1 }, { 'V', 4 }, { 'W', 4 }, { 'X', 8 }, { 'Y', 4 },
            { 'Z', 10 }
        };

        public Scrabble(string inputWord)
        {
            word = inputWord.ToUpper();
            CalculateScrabbleScore();
        }

        private void CalculateScrabbleScore()
        {
            bool isDoubleWord = word.StartsWith("{") && word.EndsWith("}");
            bool isTripleWord = word.StartsWith("[") && word.EndsWith("]");

            foreach (char letter in word)
            {
                if (letter == '{' || letter == '}')
                    continue; // Ignore curly brackets for now

                if (letter == '[' || letter == ']')
                    continue; // Ignore square brackets for now

                if (letterValues.ContainsKey(letter))
                {
                    int letterScore = letterValues[letter];

                    // Apply double or triple letter score
                    if (word.Contains($"{{{letter}}}"))
                        letterScore *= 2;
                    else if (word.Contains($"[{letter}]"))
                        letterScore *= 3;

                    score += letterScore;
                }
            }

            // Apply double or triple word score
            if (isDoubleWord)
                score *= 2;
            else if (isTripleWord)
                score *= 3;
        }

        public int Score()
        {
            return score;
        }
    }
}
