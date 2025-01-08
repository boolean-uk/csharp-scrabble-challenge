using System;
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

        public string? word;

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
            Regex reg = new Regex("^[a-zA-Z]+$");

            if (reg.IsMatch(word))
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
            return letterscore[Char.ToLower(c)];
        }

        public int score()
        {
            if (this.word == null)
            {
                return 0;
            }

            int score = 0;
            foreach (char ch in word)
            {
                int num = getLetterScore(ch);
                score += num;
            }
            //TODO: score calculation code goes here
            return score; //TODO: Remove this line when the code has been written
        }
    }
}
