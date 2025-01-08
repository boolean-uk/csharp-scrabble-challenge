using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string Word;
        private int Score;
        public Scrabble(string word)
        {
            Word = word.ToUpper();
            Score = 0;
        }

        public int score()
        {
            if (!isValidWord())
            {
                return 0;
            }
            Dictionary<char, int> lettersToValues = new Dictionary<char, int>
        {
            { 'A', 1 }, { 'E', 1 }, { 'I', 1 }, { 'O', 1 }, { 'U', 1 }, { 'L', 1 }, { 'N', 1 }, { 'R', 1 }, { 'S', 1 }, { 'T', 1 },
            { 'D', 2 }, { 'G', 2 },
            { 'B', 3 }, { 'C', 3 }, { 'M', 3 }, { 'P', 3 },
            { 'F', 4 }, { 'H', 4 }, { 'V', 4 }, { 'W', 4 }, { 'Y', 4 },
            { 'K', 5 },
            { 'J', 8 }, { 'X', 8 },
            { 'Q', 10 }, { 'Z', 10 }
        };
            int index = 0;
            bool isDoubleWord = false;
            bool isTripleWord = false;
            bool isDoubleLetter = false;
            bool isTripleLetter = false;
            char previousBracket = char.MinValue;
            bool invalid = false;
            foreach (char letter in Word)
            {
                if (index == 0)
                {
                    if (letter == '{')
                    {
                        previousBracket = letter;
                        isDoubleWord = true;
                        if (Word.ToCharArray()[index + 2] == '}')
                        {
                            isDoubleWord = false;
                            isDoubleLetter = true;
                        }
                    }
                    else if (letter == '[')
                    {
                        previousBracket = letter;
                        isTripleWord = true;
                        if (Word.ToCharArray()[index + 2] == ']')
                        {
                            isTripleWord = false;
                            isTripleLetter = true;
                        }
                    }
                }
                else 
                {
                    if (letter == '{')
                    {
                        previousBracket = letter;
                        isDoubleLetter = true;
                    }
                    else if (letter == '[')
                    {
                        previousBracket = letter;
                        isTripleLetter = true;
                    }
                    else if (letter == ']')
                    {
                        if (previousBracket != '[' && previousBracket != char.MinValue)
                        {
                            invalid = true;
                            break;
                        }
                        isTripleLetter = false;
                        previousBracket = char.MinValue;
                    }
                    else if (letter == '}')
                    {
                        if (previousBracket != '{' && previousBracket != char.MinValue)
                        {
                            invalid = true;
                            break;
                        }
                        isDoubleLetter = false;
                        previousBracket = char.MinValue;
                    }
                }
                
                if (lettersToValues.ContainsKey(letter))
                {
                    int value = lettersToValues.FirstOrDefault(x => x.Key == letter).Value;
                    int multiplier = getMultiplier(isDoubleLetter, isTripleLetter);
                    Score += value * multiplier;
                }
                index++;
             }

                
            calculateDoubleAndTripleWord(isDoubleWord, isTripleWord);
            return invalid ? 0 : Score;
        }

        private void calculateDoubleAndTripleWord(bool isDouble, bool isTriple)
        {
            if (isDouble)
            {
                Score = Score * 2;
            }
            else if (isTriple)
            {
                Score = Score * 3;
            }
        }

        private int getMultiplier(bool isDoubleLetter, bool isTripleLetter)
        {
            int multiplier = 1;
            if (isDoubleLetter)
            {
                multiplier = 2;
            }
            else if (isTripleLetter)
            {
                multiplier = 3;
            }
            return multiplier;
        }

        private bool isValidWord()
        {
            string pattern = @"^[a-zA-Z\[\]\{\}]*$";
            return Regex.IsMatch(Word, pattern);
        }
    }
}
