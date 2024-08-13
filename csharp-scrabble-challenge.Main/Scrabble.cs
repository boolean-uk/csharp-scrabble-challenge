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
        Dictionary<char, int> letterValue = new Dictionary<char, int>()
        {
            { 'A', 1},
            { 'E', 1},
            { 'I', 1},
            { 'O', 1},
            { 'U', 1},
            { 'L', 1},
            { 'N', 1},
            { 'R', 1},
            { 'S', 1},
            { 'T', 1},
            { 'D', 2},
            { 'G', 2},
            { 'B', 3},
            { 'C', 3},
            { 'M', 3},
            { 'P', 3},
            { 'F', 4},
            { 'H', 4},
            { 'V', 4},
            { 'W', 4},
            { 'Y', 4},
            { 'K', 5},
            { 'J', 8},
            { 'X', 8},
            { 'Q', 10},
            { 'Z', 10}
        };

        private string _word;
        
        public Scrabble(string word)
        {
            _word = word;
        }

        public int score()
        {
            int wordscore = 0;
            bool doubleWord = false;

            if (_word == " ")
            {
                return 0;
            }

            else
            {
                string uppercase = _word.ToUpper();
                char[] chars = uppercase.ToCharArray();
                int targetIndex = 0;

                foreach (var ch in chars)
                {
                    if (letterValue.ContainsKey(ch))
                    {
                        if (targetIndex > 0)
                        {
                            if ((chars[targetIndex - 1]) == '{' && (chars[targetIndex +1] == '}'))
                            {
                                wordscore += (letterValue[ch] * 2);
                            }
                            else if ((chars[targetIndex - 1]) == '[' && (chars[targetIndex + 1] == ']'))
                            {
                                wordscore += (letterValue[ch] * 3);
                            }
                            else
                            {
                                wordscore += letterValue[ch];
                            }
                        }
                        else
                        {
                            wordscore += letterValue[ch];
                        }

                    }
                        
                    targetIndex++;
                }
                //Doubleword true - ok this is a cheesy solve lmao xD
                string check = new string(chars);
                if (check.Length > 1)
                {
                    if ((check.StartsWith("{")) && (check.EndsWith("}")))
                    {

                        if (chars[check.Length - 3] == '{')
                        {

                        }
                        else
                        {
                            wordscore = wordscore * 2;
                        }

                    }
                    int curlies = 0;
                    foreach (var ch in chars)
                    {
                        if ((ch == '}') || (ch == '{'))
                        {
                            curlies++;
                        }
                    }
                    if (curlies % 2 != 0)
                    {
                        wordscore = 0;
                    }

                    //Tripleword true
                    if ((check.StartsWith(']')) || (check.StartsWith('[')))
                    {
                        wordscore = wordscore * 3;
                        int brackets = 0;
                        foreach (var ch in chars)
                        {
                            if ((ch == ']') || (ch == '['))
                            {
                                brackets++;
                            }
                        }
                        if (brackets % 2 != 0)
                        {
                            wordscore = 0;
                        }

                    }
                }

                char [] numerals = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
                foreach (var num in numerals)
                {
                    if (chars.Contains(num))
                    {
                        wordscore = 0;
                    }
                }


                    return wordscore;
            }
        }
    }
}
