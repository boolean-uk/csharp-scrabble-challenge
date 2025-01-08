using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        public string? word;
        public bool doubleWord = false;
        public bool tripleWord = false;

        public Dictionary<char, int> letterscore = new Dictionary<char, int>(){
            {'a', 1 }, {'e', 1 },{'i', 1 },{'o', 1 },{'u', 1 },{'l', 1 },{'n', 1 },{'r', 1 },{'s', 1 },{'t', 1 },
            {'d', 2 },{'g', 2 },
            {'b', 3 },{'c', 3 },{'m', 3 },{'p', 3},
            {'f', 4 },{'h', 4 },{'v', 4 },{'w', 4 },{'y', 4 },
            {'k', 5 },
            {'j', 8 },{'x', 8 },
            {'q', 10 },{'z', 10 }
        };

        public Scrabble(string word)
        {
            if (word.StartsWith('[') && word.EndsWith(']'))
            {
                tripleWord = true;
            }

            else if (word.StartsWith('{') && word.EndsWith('}'))
            {
                doubleWord = true;
            }


            if (Regex.IsMatch(word, @"^[a-zA-Z]+$") || tripleWord || doubleWord)
            {
                this.word = word;
            }

            else
            {
                this.word = null;
            }

        }

        public int getLetterScore(char c)
        {
            if (c == '[' || c == ']' || c == '{' || c == '}')
            {
                return 0;
            }
            return letterscore[c];
        }

        public int score()
        {
            
            if (word == null)
            {
                return 0;
            }
            int score = 0;
            foreach(char c in word)
            {   
                char j = Char.ToLower(c);
                int num = getLetterScore(j);
                score += num;
            }
            return doubleWord ? score * 2 : tripleWord ? score * 3 : score;
        }
    }
}
