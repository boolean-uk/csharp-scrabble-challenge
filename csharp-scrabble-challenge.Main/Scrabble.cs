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
                //If the character is a starting bracket, the multiplier is increased
                if (letter == '{') { multiplier *= 2; }
                if (letter == '[') { multiplier *= 3; }

                //If the character is a closing bracket, the multiplier is decreased
                if (letter == '}') { multiplier /= 2; }
                if (letter == ']') { multiplier /= 3; }
                //Is the letter in our Letter dictionary?
                if (letters.ContainsKey(letter))
                {
                    //Add the points associated with the letter to our score, with our multiplier
                    finalScore += letters[letter] *multiplier;
                }
            }
            
            return finalScore;     
               
        }
    }
}
