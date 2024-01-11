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

        private Dictionary<char, int> letters;
        private int value;
        public Scrabble(string word)
        {            
            this.letters = initDic();
            value = 0;
            calculateScore(word);
        }

        private void calculateScore(string word) {
            bool doubl = false;
            bool triple = false;
            int val = 0;
            if(word == "")
                word = "&";
            if(String.Equals(word[0].ToString(), "{")) {
                    doubl = true;
                }
            if(String.Equals(word[0].ToString() , "[")) {
                    triple = true;
                }
            foreach (char letter in word.ToUpper())
            {
                if (letters.ContainsKey(letter)) {
                    val += letters[letter];
                }
            }

            if (doubl)

                value = val * 2;
            else if (triple)
            {
                value = val * 3;
            }
            else {
                value = val;
            }
        }

        public int score()
        {
            //TODO: score calculation code goes here
            return value;
        }



        private Dictionary<char,int> initDic() {
             return letters = new Dictionary<char, int>
            {
            {'A', 1}, {'E', 1}, {'I', 1}, {'O', 1}, {'U', 1},
            {'L', 1}, {'N', 1}, {'R', 1}, {'S', 1}, {'T', 1},
            {'D', 2}, {'G', 2},
            {'B', 3}, {'C', 3}, {'M', 3}, {'P', 3},
            {'F', 4}, {'H', 4}, {'V', 4}, {'W', 4}, {'Y', 4},
            {'K', 5},
            {'J', 8}, {'X', 8},
            {'Q', 10}, {'Z', 10},
            };
        }
    }
}
