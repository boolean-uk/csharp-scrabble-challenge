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
        //Create a wordMap that keeps track of the letters found in the word and the amount of those letters that exist.
        public Dictionary<char, int> wordMap = new Dictionary<char, int>();
        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            //Make sure it is lower case
            word = word.ToLower();

            //Multiplier variable to handle double / triple points
            int doubleMultiplier = 1;
            int tripleMultiplier = 1;

            //Illegal bool to check if the multiplier is illegal
            bool illegal = false;

            //1. Loop through every letter in the word
            foreach (char c in word) {
                //2. Check if the current letter means double/triple points have started/ended
                switch(c)
                {
                    case '{':
                        doubleMultiplier *= 2; break;
                    case '}':
                        if (doubleMultiplier == 1) illegal = true;
                        doubleMultiplier /= 2; break;
                    case '[':
                        tripleMultiplier *= 3; break;
                    case ']':
                        if (tripleMultiplier == 1) illegal = true;
                        tripleMultiplier /= 3; break;
                }

                //If the word is illegal, clear the list and let the score calculate it as 0.
                if(illegal)
                {
                    wordMap.Clear();
                    return;
                }
                
                //3a. Check if wordMap already contains the letter
                if (wordMap.ContainsKey(c))
                {
                    wordMap[c] += 1 * doubleMultiplier * tripleMultiplier;
                }
                else //3b. Add the new letter to the word map
                {
                    wordMap.Add(c, 1 * doubleMultiplier * tripleMultiplier);
                }
            }
        }

        public int score()
        {
            //TODO: score calculation code goes here

            //1. Create a list of acceptable letters and their respective scores
            Dictionary<char, int> letterScores = new Dictionary<char, int>()
            {
                {'a', 1 },
                {'b', 3 },
                {'c', 3 },
                {'d', 2 },
                {'e', 1 },
                {'f', 4 },
                {'g', 2 },
                {'h', 4 },
                {'i', 1 },
                {'j', 8 },
                {'k', 5 },
                {'l', 1 },
                {'m', 3 },
                {'n', 1 },
                {'o', 1 },
                {'p', 3 },
                {'q', 10 },
                {'r', 1 },
                {'s', 1 },
                {'t', 1 },
                {'u', 1 },
                {'v', 4 },
                {'w', 4 },
                {'x', 8 },
                {'y', 4 },
                {'z', 10 },
                {'{', 0 }, //Legal Letter
                {'}', 0 }, //Legal Letter
                {'[', 0 }, //Legal Letter
                {']', 0 } //Legal Letter
            };

            //2. Initialize result as 0
            int result = 0;

            //3. Variable checking if illegal letters are being used
            bool illegal = false;

            //3. Loop through each letter in the wordMap
            foreach (char c in wordMap.Keys) 
            {
                //4. Check if the current letter is legal
                if(letterScores.ContainsKey(c))
                {
                    //5. Add the total score gained from that letter
                    result += letterScores[c] * wordMap[c];
                }
                else //Illegal letter found
                {
                    illegal = true;
                }

            }

            //6. Return the results or 0 if illegal.
            if(illegal)
            {
                return 0;
            }
            return result;

        }
    }
}
