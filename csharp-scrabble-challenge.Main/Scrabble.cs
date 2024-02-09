using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        //private char[] _word;
        public string word;
        public Dictionary<string, int> letterValue = new Dictionary<string, int>()
        {
            {"AEIOULNRST", 1 },
            {"DG" , 2 },
            {"BCMP" , 3 },
            { "FHVWY" , 4 },
            { "K" , 5 },
            { "JX" , 8 },
            { "QZ" , 10 }
        };

            public Scrabble(string inputWord)
        {
            //TODO: do something with the word variable
            inputWord = inputWord.Trim();
            //inputWord = "quirky";
            word = inputWord.ToUpper();
        }

        public int score()
            //TODO: score calculation code goes here
        {
        // set the default value to 0   
            int score = 0;
            //int multiplier = 1;
            // create a char array of the input word, so you can calculate each value of the letters in the input word
            char[] charLetterArray = word.ToCharArray();

            // because "\t\n is no string it will be score 0
            // if array of charLetterArray = not empty  run code
            if(charLetterArray.Length != 0)
            {
                // for each character of the charLetterArray find the letter value
                foreach (char character in charLetterArray) {

              
                    // for each letter in letterValue check if value of the key value pair
                    foreach (var letter in letterValue) {

                        // check of the letter contains the character in charLetterArray
                        if (letter.Key.Contains(character))
                        {
                            // add the letter value to the score
                            score += letter.Value; 
                        } 
                    }
                }
            
                // outside of foreach because it is its own program
                // you dont need to loop through string 'word' because it already takes the first and last character! 
                if (word.First() == '{' && word.Last() == '}')
                { 
                    // an also be without the return.
                   return score *= 2;
                } 
                else if (word.First() == '[' && word.Last() == ']')
                {
                    return score *= 3;
                }

            }
            return score;
        }
    }
}
