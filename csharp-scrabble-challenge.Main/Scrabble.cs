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

        public Scrabble(string word)
        {            
            //TODO: do something with the word variable
            _word = word;
        }

        public int score()
        {
            //TODO: score calculation code goes here
            int wordScore = 0;
            bool isDoubleWord = isDoubleW(_word);
            bool isTripleWord = isTripleW(_word);
            bool isDoubleLetter = false, isTripleLetter = false;
            int start = 0, end = _word.Length;

            // check if word is both double and triple
            if (isDoubleWord)
            {
                isTripleWord = isTripleW(_word.Substring(1, _word.Length-2));
            }
            else if (isTripleWord) {
                isDoubleWord = isDoubleW(_word.Substring(1, _word.Length-2));
            }
            if (isDoubleWord)
            {
                ++start;
                --end;
            }
            if (isTripleWord)
            {
                ++start;
                --end;
            }

            for (int i = start; i < end; i++)
            {
                char letter = _word[i];
                int score = 0;
                // check for invalid characters
                if (letter == ']' || letter == '}')
                    return 0;
                if (letter == '|' && _word[i + 2] == '|')
                    return 0;
                // check for double or tripple letter
                if (letter == '{')
                {
                    if (_word[i + 2] !='}')
                        return 0;
                    // double letter detected
                    isDoubleLetter = true;
                    letter = _word[i + 1];
                }
                else if (letter == '[')
                {
                    if (_word[i + 2] != ']')
                        return 0;
                    // triple letter detected
                    isTripleLetter = true;
                    letter = _word[i + 1];
                }

                score = letterScore(letter);

                if (isDoubleLetter)
                {
                    wordScore += 2 * score;
                    i += 2; // get to the end of double letter notation
                    isDoubleLetter = false;
                }
                else if (isTripleLetter)
                {
                    wordScore += 3 * score;
                    i += 2; // get to the end of triple letter notation
                    isTripleLetter = false;
                }
                else
                {
                    wordScore += score;
                }
            }

            if (isDoubleWord)
                wordScore *= 2;
            if (isTripleWord)
                wordScore *= 3;
            return wordScore;
        }

        private int letterScore(char letter)
        {
            letter = ("" + letter).ToUpper()[0];
            if (letter < 'A' || letter > 'Z')
                return 0;
            
            switch (letter)
            {
                case 'K':
                    return 5;
                case 'D':
                case 'G':
                    return 2;
                case 'J':
                case 'X':
                    return 8;
                case 'Q':
                case 'Z':
                    return 10;
                case 'B':
                case 'C':
                case 'M':
                case 'P':
                    return 3;
                case 'F':
                case 'H':
                case 'V':
                case 'W':
                case 'Y':
                    return 4;
                default:
                    return 1;
            }
        }

        private bool matchBrackets(string word, char leftSymbol, char rightSymbol)
        {
            return word.Length > 2 && word[0] == leftSymbol && word[2] != rightSymbol && word[word.Length - 1] == rightSymbol;
        }

        private bool isDoubleW(string word) => matchBrackets(word, '{', '}');

        private bool isTripleW(string word) => matchBrackets(word, '[', ']');

    }
}
