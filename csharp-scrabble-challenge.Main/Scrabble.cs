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

        Dictionary<Char, int> letterValues = new Dictionary<Char, int> 
        {
            {'A', 1 },
            {'E', 1 },
            {'I', 1 },
            {'O', 1 },
            {'U', 1 },
            {'L', 1 },
            {'N', 1 },
            {'R', 1 },
            {'S', 1 },
            {'T', 1 },
            {'D', 2 },
            {'G', 2 },
            {'B', 3 },
            {'C', 3 },
            {'M', 3 },
            {'P', 3 },
            {'F', 4 },
            {'H', 4 },
            {'V', 4 },
            {'W', 4 },
            {'Y', 4 },
            {'K', 5 },
            {'J', 8 },
            {'X', 8 },
            {'Q', 10 },
            {'Z', 10 }
        };

        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            this._word = word.Trim().ToUpper();
        }

        public int score()
        {

            var result = 0;
            var doubleScore = false;
            var tripleScore = false;
            Stack<char> bracketStack = new Stack<char>();

            //TODO: score calculation code goes here

            foreach (var letter in _word)
            {

                if (Char.IsNumber(letter))
                {
                    result = 0;
                    break;
                }

                if (letter.Equals('{'))
                {
                    doubleScore = true;
                    bracketStack.Push(letter);
                }

                else if (letter.Equals('}'))
                {
                    doubleScore = false;
                    if (bracketStack.Pop() == '{')
                    {
                        doubleScore = false;
                    }
                    else
                    {
                        result = 0;
                        break;
                    }
                }

                if (letter.Equals('['))
                {
                    tripleScore = true;
                    bracketStack.Push(letter);
                }
                else if (letter.Equals(']'))
                { 
                    tripleScore = false;
                    if (bracketStack.Pop() == '[')
                    {
                        tripleScore = false;
                    }
                    else
                    { 
                        result = 0;
                        break;
                    }
                }
                    
                
                if(letterValues.ContainsKey(letter))
                {
                    if (doubleScore && tripleScore)
                        result += letterValues[letter] * 6;
                    else if (doubleScore)
                        result += letterValues[letter] * 2;
                    else if (tripleScore)
                        result += letterValues[letter] * 3;
                    else
                        result += letterValues[letter]; 
                }

            }

            return result; //TODO: Remove this line when the code has been written
        }
    }
}
