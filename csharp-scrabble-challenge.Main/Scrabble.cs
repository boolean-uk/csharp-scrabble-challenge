using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string _word;

        private Dictionary<char, int> _letterValues;
        public Scrabble(string word)
        {
            _word = word;
            _letterValues = GenerateScoreTable();
        }

        public int score()
        {
            int score = 0;
            if (!Regex.IsMatch(_word.ToUpper(), "[A-Z]"))
            {
                return 0;
            }

            score += CalculateWordScore(_word);
            return score;
        }

        private int CalculateWordScore(string word)
        {
            int score = 0;
            int multiplier = 1;
            foreach (char c in word.ToUpper())
            {
                if(c.Equals('{'))
                {
                    multiplier = 2;
                    continue;
                } else if (c.Equals('['))
                {
                    multiplier = 3;
                    continue;
                } else if (c.Equals(']') || c.Equals('}'))
                {
                    multiplier = 1;
                    continue;
                }
                score += _letterValues[c] * multiplier;
            }
            return score;
        }

        private Dictionary<char, int> GenerateScoreTable()
        {
            Dictionary<char, int> scoreTable = new Dictionary<char, int>();

            Dictionary<string, int> chars = new()
            {
                { "AEIOULNRST", 1 },
                { "DG", 2 },
                { "BCMP", 3 },
                { "FHVWY", 4 },
                { "K", 5 },
                { "JX", 8 },
                { "QZ", 10 },
            };

            int i = 0;
            foreach (string line in chars.Keys)
            {
                foreach (char c in line)
                {
                    scoreTable.Add(c, chars[line]);
                }
                i++;
            }
            return scoreTable;
        }

        public string Word
        {
            get { return _word; }
            set { _word = value; }
        }
    }
}
