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
        // Create a string which contains all letters of the alphabet
        public string letters { get; set; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        // Create a dict that have the letters as values, and points as keys
        public Dictionary<int, string> pointsDict { get; set; } = new Dictionary<int, string>()
        {
            { 1, "AIOULNRSTE" },
            { 2, "DG" },
            { 3, "BCMP" },
            { 4, "FHVWY" },
            { 5, "K" },
            { 8, "JX" },
            { 10, "QZ" }
        };

        // list to store all characters of the string passed in constructor
        private List<char> chars = new List<char>();

        
        public Scrabble(string word)
        {
            // Add all characters in the word to the list chars
            foreach (char c in word) 
            {
                chars.Add(char.ToUpper(c));
            }
            
            //TODO: do something with the word variable
        }
        


        public int score()
        {   
            //list where all the points are stored
            List<int> scoreList = new List<int>();

            // loop through every char and att points to scorelist
            foreach (char c in chars)
            {
                
                foreach (var kvp in pointsDict) 
                {
                    if (kvp.Value.Contains(c)) 
                    {
                        scoreList.Add(kvp.Key);
                    }
                }
            }
            // Sum up all points to total score
            return scoreList.Sum();
            //TODO: score calculation code goes here
            //throw new NotImplementedException(); //TODO: Remove this line when the code has been written
        }
    }
}
