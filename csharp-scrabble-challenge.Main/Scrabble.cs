using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string _word;
        private Dictionary<char, int> wordScore = new Dictionary<char, int>();
        

        public Scrabble(string word)
        {
            wordScore.Add('a', 1);
            wordScore.Add('e', 1);
            wordScore.Add('i', 1);
            wordScore.Add('o', 1);
            wordScore.Add('u', 1);
            wordScore.Add('l', 1);
            wordScore.Add('n', 1);
            wordScore.Add('r', 1);
            wordScore.Add('s', 1);
            wordScore.Add('t', 1);
            wordScore.Add('d', 2);
            wordScore.Add('g', 2);
            wordScore.Add('b', 3);
            wordScore.Add('c', 3);
            wordScore.Add('m', 3);
            wordScore.Add('p', 3);
            wordScore.Add('f', 4);
            wordScore.Add('h', 4);
            wordScore.Add('v', 4);
            wordScore.Add('w', 4);
            wordScore.Add('y', 4);
            wordScore.Add('k', 5);
            wordScore.Add('j', 8);
            wordScore.Add('x', 8);
            wordScore.Add('q', 10);
            wordScore.Add('z', 10);

            Regex rgx = new Regex(@"\[\^a\-zA\-Z~\[\]{} \-\]");
            word = rgx.Replace(word, "");
            _word = word.ToLower();
            

        }

        public int score()
        {
            int score = 0;
            if (_word.Contains('{') && _word.Contains('}'))
            {
                return dubbleScore();
            } else if (_word.Contains('[') && _word.Contains(']'))
            {
                return trippleScore(); 
            }

            
            //TODO: score calculation code goes here

            foreach (char letter in _word)
            {
                wordScore.TryGetValue(letter, out int value);

                score += value;
            }

            return score;
        }

        private int dubbleScore()
        {
            bool dubble = false;
            int score = 0;
            foreach (char letter in _word) { 
                if (dubble && (letter != '}') && (letter != '{'))
                {
                    wordScore.TryGetValue(letter, out int value);
                    score += (value*2);
                } else if (letter == '{')
                {
                    dubble = true;
                } else if (letter == '}') 
                { 
                    dubble = false;
                } else
                {
                    wordScore.TryGetValue(letter, out int value);
                    score += value;
                }
            }
            return score;
        }

        private int trippleScore()
        {
            bool tripple = false;
            int score = 0;
            foreach (char letter in _word)
            {
                if (tripple && (letter != ']') && (letter != '['))
                {
                    wordScore.TryGetValue(letter, out int value);
                    score += (value * 3);
                }
                else if (letter == '[')
                {
                    tripple = true;
                }
                else if (letter == ']')
                {
                    tripple = false;
                }
                else
                {
                    wordScore.TryGetValue(letter, out int value);
                    score += value;
                }
            }
            return score;
        }
    }


}
