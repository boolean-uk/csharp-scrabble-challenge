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
        private string _word;
        Dictionary<char, int> letters = new Dictionary<char, int>()
        {
            { 'a', 1 },
            { 'b', 3 },
            { 'c', 3 },
            { 'd', 2 },
            { 'e', 1 },
            { 'f', 4 },
            { 'g', 2 },
            { 'h', 4 },
            { 'i', 1 },
            { 'j', 8 },
            { 'k', 5 },
            { 'l', 1 },
            { 'm', 3 },
            { 'n', 1 },
            { 'o', 1 },
            { 'p', 3 },
            { 'q', 10 },
            { 'r', 1 },
            { 's', 1 },
            { 't', 1 },
            { 'u', 1 },
            { 'v', 4 },
            { 'w', 4 },
            { 'x', 8 },
            { 'y', 4 },
            { 'z', 10 },
        };
        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            _word = word.ToLower();
        }

        public int score()
        {
            //TODO: score calculation code goes here

            //Create integers to track progress and current multiplier
            int finalScore = 0;
            int multiplier = 1;
            foreach(char letter in _word) 
            {
                switch (letter)
                {
                    case '{': 
                        multiplier *= 2; 
                        break;
                    case '[':
                        multiplier *= 3;
                        break;
                    case '}':
                        multiplier /= 2;
                        break;
                    case ']':
                        multiplier /= 3;
                        break;

                    default:
                        //If we find the char in our directory, add its score, if not throw error.
                        if (letters.ContainsKey(letter)) { finalScore += letters[letter] * multiplier; }
                        else { return 0; }
                        break;
                        
                }

            }
            //If the multiplier isnt 1 at the end, there is a parentheses missing, so throw an error
            if (multiplier != 1) { return 0; }


            return finalScore;     
               
        }
    }
}
