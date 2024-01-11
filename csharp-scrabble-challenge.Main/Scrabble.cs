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
        private string word;

        public Scrabble(string word)
        {
            this.word = word;//TODO: do something with the word variable
        }

        public int score()
        {

            //TODO: score calculation code goes here
            //TODO: Remove this line when the code has been written
            if (string.IsNullOrEmpty(word))
            {
                // Return 0 if the word is null or empty
                return 0;
            }

            // Convert the word to uppercase for case-insensitive scoring
            string upperCaseWord = word.ToUpper();    

            // Define the point values for each letter
            Dictionary<char, int> letterPoints = new Dictionary<char, int>
        {
            {'A', 1}, {'E', 1}, {'I', 1}, {'O', 1}, {'U', 1}, {'L', 1}, {'N', 1}, {'R', 1}, {'S', 1}, {'T', 1},
            {'D', 2}, {'G', 2},
            {'B', 3}, {'C', 3}, {'M', 3}, {'P', 3},
            {'F', 4}, {'H', 4}, {'V', 4}, {'W', 4}, {'Y', 4},
            {'K', 5},
            {'J', 8}, {'X', 8},
            {'Q', 10}, {'Z', 10}
        };

            // Calculate the score by summing up the points for each letter in the word
            int totalScore = 0;
            foreach (char i in upperCaseWord)
            {
                // Check if the letter is in the dictionary
                if (letterPoints.ContainsKey(i))
                {
                    // Add the points for the letter to the total score
                    totalScore += letterPoints[i];
                }     
            }     

            return totalScore;                                   
    }
    }
}
                                                                                                                                                                                                               