using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string _word = "";

        // Contains all accepted characters
        Dictionary<char, int> letters = new Dictionary<char, int> {
            {'A', 1},
            {'E', 1},
            {'I', 1},
            {'O', 1},
            {'U', 1},
            {'L', 1},
            {'N', 1},
            {'R', 1},
            {'S', 1},
            {'T', 1},
            {'D', 2},
            {'G', 2},
            {'B', 3},
            {'C', 3},
            {'M', 3},
            {'P', 3},
            {'F', 4},
            {'H', 4},
            {'V', 4},
            {'W', 4},
            {'Y', 4},
            {'K', 5},
            {'J', 8},
            {'X', 8},
            {'Q', 10},
            {'Z', 10},
            // used as multipliers
            {'{', 2},
            {'}', 2},
            {'[', 3},
            {']', 3},

        };
        public Scrabble(string word)
        {
            this._word = word.ToUpper();
        }

        public int score()
        {
            int score = 0;
            int multiplier = 1;
            // Using stack to keep track of the order of the multipliers
            Stack<Char> multiStack = new Stack<Char>();
                foreach(char c in this._word)
                {
                    if(letters.ContainsKey(c))
                    {
                    if (c == '{' || c == '[')
                    {
                        multiStack.Push(c);
                        multiplier *= (c == '{') ? 2 : 3;
                    } else if (c == '}')
                    {
                        // if multiplier opened and was the last to be opened
                        if (multiStack.Count == 0 || multiStack.Peek() != '{')
                        {
                            score = 0; break;
                        } else
                        {
                            multiStack.Pop();
                            multiplier /= 2;
                        }
                    } else if (c == ']')
                    {
                        // if multiplier opened and was the last to be opened
                        if (multiStack.Count == 0 || multiStack.Peek() != '[')
                        {
                            score = 0; break;
                        }
                        else
                        {
                            multiStack.Pop();
                            multiplier /= 3;
                        }
                    } else if (c != '{' || c != '}' || c != '[' || c != ']') {
                        score += letters[c] * multiplier;
                    }
                    } else 
                {
                    score = 0; break;
                }
                }
            // Checks if all multipliers are closed
            if(multiStack.Count != 0)
            {
                score = 0;
            }
            return score;
        }
    }
}
