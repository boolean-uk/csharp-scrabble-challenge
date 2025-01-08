using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private int _score = 0;
        public Scrabble(string word)
        {
            // seperating defining of word and class allows for change of word later...
            setWord(word);
        }

        private void findAndCalc_doubleLetters(string word, ref int tempScore, ref string stripMultiplierWord)
        {
            // regex looks for a single letter with braces around it
            var doubleLetters = Regex.Matches(word, $"{{[a-z]}}", RegexOptions.IgnoreCase);
            foreach (Match d in doubleLetters)
            {
                stripMultiplierWord = stripMultiplierWord.Replace(d.Value, "");
                tempScore += this.calc_score(d.Value) * 2;
            }
        }

        private void findAndCalc_trippleLetters(string word, ref int tempScore, ref string stripMultiplierWord)
        {
            // regex looks for a single letter with brackets around it
            var trippleLetters = Regex.Matches(word, $"\\[[a-z]\\]", RegexOptions.IgnoreCase);
            foreach (Match t in trippleLetters)
            {
                stripMultiplierWord = stripMultiplierWord.Replace(t.Value, "");
                tempScore += this.calc_score(t.Value) * 3;
            }
        }

        private static string _checkWordMultiplier(string word, out int trippleWord, out int doubleWord)
        {
            trippleWord = Regex.Count(word, $"^\\[[a-z{{}}\\]\\[]+\\]$", RegexOptions.IgnoreCase);
            doubleWord = Regex.Count(word, $"^{{[a-z{{}}\\[\\]]+}}$", RegexOptions.IgnoreCase);
            if (doubleWord != 0 || trippleWord != 0)
            {
                // If word has a multiplier, remove braces/bracets at edges
                word = word[1..(word.Length - 1)];
            }
            // return word without braces/brackets...
            return word;
        }

        private int calc_score(string word)
        {
            var score_1_matchCount = Regex.Count(word, "(A|E|I|O|U|L|N|R|S|T)", RegexOptions.IgnoreCase);
            var score_2_matchCount = Regex.Count(word, "(D|G)", RegexOptions.IgnoreCase);
            var score_3_matchCount = Regex.Count(word, "(B|C|M|P)", RegexOptions.IgnoreCase);
            var score_4_matchCount = Regex.Count(word, "(F|H|V|W|Y)", RegexOptions.IgnoreCase);
            var score_5_matchCount = Regex.Count(word, "(K)", RegexOptions.IgnoreCase);
            var score_8_matchCount = Regex.Count(word, "(J|X)", RegexOptions.IgnoreCase);
            var score_10_matchCount = Regex.Count(word, "(Q|Z)", RegexOptions.IgnoreCase);

            return score_1_matchCount * 1 +
                score_2_matchCount * 2 +
                score_3_matchCount * 3 +
                score_4_matchCount * 4 +
                score_5_matchCount * 5 +
                score_8_matchCount * 8 +
                score_10_matchCount * 10;
        }
        public void setWord(string word)
        {
            // Set default value, expect failure as default
            this._score = 0;

            // Handle edgecase
            if (word.Length == 0)
                return;

            

            int tempScore = 0;
            string stripMultiplierWord = word;

            // identify trippleLetters, doubleletters, remove occurances from stripMultiplierWord then sum to tempScore
            findAndCalc_trippleLetters(word, ref tempScore, ref stripMultiplierWord);
            findAndCalc_doubleLetters(word, ref tempScore, ref stripMultiplierWord);

            int trippleWord, doubleWord;
            //word = _checkWordMultiplier(word, out trippleWord, out doubleWord);
            word = _checkWordMultiplier(stripMultiplierWord, out trippleWord, out doubleWord);

            // if stripMultiplierWord contains anything but letters, then the input word was invalid
            var invalidInputCount = Regex.Count(word, "([^a-z])", RegexOptions.IgnoreCase);
            if (invalidInputCount != 0)
                return;

            // calculate score for the remaining letters and add to tempScore
            tempScore += calc_score(word);


            // Finally add any word multipliers
            if (doubleWord != 0)
                tempScore *= 2;
            else if (trippleWord != 0)
                tempScore *= 3;
            

            // Apply score
            this._score = tempScore;
        }
        public int score()
        {
            //TODO: score calculation code goes here
            // ^ Score is now calculated when Scrabble instance is created
            return this._score;

        }
    }
}
