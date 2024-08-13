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

        public Dictionary<char, int> scoreSheet = new Dictionary<char, int>()
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
            {'[', 0},
            {']', 0},
            {'{', 0},
            {'}', 0 },
        };

        public Scrabble(string word)
        {            
            word = word.ToLower();
            int wordMultiply = 1;
            bool first = true;
            int counter = 0;
            
            int letterMultiplier = 1; //to keep track on if next letter is double or triple points
            
            bool letterBracketCheck = false;

            foreach (char character in word)
            {
                counter++;
                if(!scoreSheet.Keys.Contains(character)) //number in word, not allowed
                {
                    wordMap.Clear();
                    return; //jumps out of Scrabble()
                }

                if (word[0] == '{' && first && word[2] != '}' && word[word.Length - 1] == '}') //this is double word
                {
                    wordMultiply = 2;
                    first = false;
                    continue;
                }
                else if (word[0] == '[' && first && word[2] != ']' && word[word.Length - 1] == ']') // this is triple word
                {
                    wordMultiply = 3;
                    first = false;
                    continue;
                }
                else if (first)
                {
                    first = false;
                }

                if (character == '{') // to find double letter
                {
                    letterMultiplier = 2;
                    letterBracketCheck = true;
                    continue;
                }
                else if(character == '[') //to find triple letter
                {
                    letterMultiplier = 3;
                    letterBracketCheck = true;
                    continue;
                }
                

                else if(character == '}' && letterBracketCheck)
                {
                    if (letterMultiplier == 2)
                    {
                        letterMultiplier = 1;
                        letterBracketCheck = false;
                        continue;
                    }
                    else if (word.Length != counter)// wrong input, not allowed
                    {
                        wordMap.Clear();
                        return; //jumps out of Scrabble()
                    }
                }
                else if(character == ']' && letterBracketCheck)
                {
                    if (letterMultiplier == 3)
                    {
                        letterBracketCheck = false;
                        letterMultiplier = 1;
                        continue;
                    }
                    else if (word.Length != counter)// wrong input, not allowed
                    {
                        wordMap.Clear();
                        return; //jumps out of Scrabble()
                    }
                }
                else if(letterBracketCheck == false && (character == ']' || character == '}') && counter != word.Length)
                {
                    wordMap.Clear();
                    return; //jumps out of Scrabble()
                }


                if (wordMap.ContainsKey(character)) // is there already
                {
                    wordMap[character] += 1 * letterMultiplier * wordMultiply;
                    letterMultiplier = 1;
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
