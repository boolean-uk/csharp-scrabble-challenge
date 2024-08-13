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

        public Dictionary<char, int> wordMap = new Dictionary<char, int>(); // char is which character and int is the occurance of the character
        public Scrabble(string word)
        {            
            word = word.ToLower();
            int wordMultiply = 1;
            bool first = true;
            
            int letterMultiplier = 1; //to keep track on if next letter is double or triple points
       

            foreach (char character in word)
            {
                if (word[0] == '{' && first) //this is double word
                {
                    wordMultiply = 2;
                    first = false;
                    continue;
                }
                else if (word[0] == '[' && first) // this is triple word
                {
                    wordMultiply = 3;
                    first = false;
                    continue;
                }
                else if (first)
                {
                    first = false;
                }

                if (!first && character == '{') // to find double letter
                {
                    letterMultiplier = 2;
                    continue;
                }
                else if(!first && character == '[') //to find triple letter
                {
                    letterMultiplier = 3;
                    continue;
                }
                else
                {
                    letterMultiplier = 1; // normal
                }
                

               
                if(character == '{' || character == '}' || character == '[' || character == ']')
                {
                    continue; // skip this char
                }

                if (wordMap.ContainsKey(character)) // is there already
                {
                    wordMap[character] += 1 * letterMultiplier * wordMultiply;
                }
                else
                {
                    wordMap.Add(character, 1 * letterMultiplier * wordMultiply);
                }
            }
        }

        public int score()
        {
            int score = 0;
            Dictionary<char, int> scoreSheet = new Dictionary<char, int>()
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
                {'z', 10 }
            };

            foreach (var item in wordMap)
            {
                char character = item.Key;
                int occurance = item.Value;

                foreach (var letter in scoreSheet)
                {
                    if(letter.Key == character)
                    {
                        score += letter.Value * occurance;
                    }
                }
            }
            return score;
        }
    }
}
