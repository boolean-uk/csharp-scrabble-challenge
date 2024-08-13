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
            _word = word;
        }


        private int _getletterscore(char a)
        {
            int score = 0;
            List<char> _1_point_chars = new List<char>()
            {
            'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R' , 'S', 'T'
            };
            List<char> _2_point_chars = new List<char>()
            {
            'D', 'G'
            };

            List<char> _3_point_chars = new List<char>()
            {
            'B', 'C', 'M', 'P'
            };
            List<char> _4_point_chars = new List<char>()
            {
            'F', 'H', 'V', 'M', 'Y'
            };
            List<char> _5_point_chars = new List<char>()
            {
            'K',
            };
            List<char> _8_point_chars = new List<char>()
            {
            'J','X'
            };
            List<char> _10_point_chars = new List<char>()
            {
            'Q','Z'
            };

            if (_1_point_chars.Contains(a)) { score += 1; }
            else if (_2_point_chars.Contains(a)) { score += 2; }
            else if (_3_point_chars.Contains(a)) { score += 3; }
            else if (_4_point_chars.Contains(a)) { score += 4; }
            else if (_5_point_chars.Contains(a)) { score += 5; }
            else if (_8_point_chars.Contains(a)) { score += 8; }
            else if (_10_point_chars.Contains(a)) { score += 10; }

            return score;


        }
        public int score()
        {
            string word = _word.ToUpper();
            bool wrapped_in_curlies = false;
            bool wrapped_in_squares = false;
            if (word.StartsWith('{') && word.EndsWith('}'))
            {
                wrapped_in_curlies = true;
                word = word.Substring(1, word.Length - 2);
            }

            if (word.StartsWith('[') && word.EndsWith(']'))
            {
                wrapped_in_squares = true;
                word = word.Substring(1, word.Length - 2);
            }
            int total_Score = 0;
            int i = 0;
            while (i < word.Length)
            {
                char letter = word[i];
                int get_letter_score = _getletterscore(letter);
                if (letter == '{' && i + 2 < word.Length && word[i + 2] == '}')
                {
                    letter = word[i + 1];
                    get_letter_score = _getletterscore(letter) * 2;
                    i += 3;
                }
                else if (letter == '[' && i + 2 < word.Length && word[i + 2] == ']')
                {
                    letter = word[i + 1];
                    get_letter_score = (letter) * 3;
                    i += 3;
                }
                else
                {
                    i++;
                }
                total_Score += get_letter_score;
            }
            if (wrapped_in_curlies)
            {
                total_Score = total_Score * 2;
            }
            if (wrapped_in_squares)
            {

                total_Score = total_Score * 3;
            }
            return total_Score;

        }
    }
}
        
    
            
        
