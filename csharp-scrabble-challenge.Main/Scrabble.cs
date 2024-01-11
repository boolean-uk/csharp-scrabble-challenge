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
        public Dictionary<char, int> scrabbleLetterValues = new Dictionary<char, int>()
            {
                {'A', 1}, {'B', 3}, {'C', 3}, {'D', 2}, {'E', 1}, {'F', 4}, {'G', 2},
                {'H', 4}, {'I', 1}, {'J', 8}, {'K', 5}, {'L', 1}, {'M', 3}, {'N', 1},
                {'O', 1}, {'P', 3}, {'Q', 10},{'R', 1}, {'S', 1}, {'T', 1}, {'U', 1},
                {'V', 4}, {'W', 4}, {'X', 8}, {'Y', 4}, {'Z', 10}
            };
        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            _word = word;

        }

        public int score()
        {
            //TODO: score calculation code goes here
            return Convert.ToInt32(points(_word));


        }

        private double points (string remainingWord)
        {
            if (remainingWord.Length == 0) return 0;
            //Take first character of string
            char letter = remainingWord.First();
            //Check if special symbol
            switch (letter)
            {
                // Opening brackets
                case '[':
                    return points(remainingWord[1..])*3; //Add a 3x multiplier to remaining word
                case '{':
                    return points(remainingWord[1..])*2; //Add a 2x multiplier to remaining word
                // Closing brackets
                case ']':
                    return points(remainingWord[1..])/3; //Remove a 3x multiplier to remaining word
                case '}':
                    return points(remainingWord[1..])/2; //Remove a 2x multiplier to remaining word
                // Not a special symbol
                default:
                    //Else calculate letter value and continue
                    return calculateLetterValue(letter) + points(remainingWord[1..]);
            }
        }

        private int calculateLetterValue(char letter)
        {
            if (scrabbleLetterValues.TryGetValue(char.ToUpper(letter), out _)) 
            {   
                return scrabbleLetterValues[char.ToUpper(letter)]; 
            }
            else
            {
                return 0;
            }
        } 
    }
}
