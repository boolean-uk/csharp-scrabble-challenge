using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        public Scrabble(string word)
        {

            if (word.Contains("{") && word.Contains("}"))
            {
                word = word.Replace("{", "").Replace("}", "");
                double_letter(word);
            }
            else if (word.Contains("[") && word.Contains("]"))
            {
                word = word.Replace("[", "").Replace("]", "");
                triple_letter(word);
            }
            else if (word.Contains("{") && word.Contains("}") && word.Contains("[") && word.Contains("]"))
            {
                
                string[] split = word.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                string double_letters = split[0];
                string triple_letters = split[1];

                double_letters = double_letters.Replace("{", "").Replace("}", "");
                triple_letters = triple_letters.Replace("{", "").Replace("}", "");

                double_letter(double_letters);
                triple_letter(triple_letters);
            }
            else if (word == " " || word.Contains("\t\n") || word.Contains("\n\r\t\b\f") || word == null || word.All(char.IsDigit))
            {
                store.Add(0);
            }
            else
            {
                normal_word(word);
            }
            score();
        }

        public int score()
        {
            int total = 0;
            foreach (int value in store)
            {
                total += value;
            }
            return total;
        }

        public List<int> store = new List<int>();

        public IDictionary<string, int> letter_values = new Dictionary<string, int>()
            {
                {"A", 1},
                {"E", 1},
                {"I", 1},
                {"O", 1},
                {"U", 1},
                {"L", 1},
                {"N", 1},
                {"R", 1},
                {"S", 1},
                {"T", 1},
                {"D", 2},
                {"G", 2},
                {"B", 3},
                {"C", 3},
                {"M", 3},
                {"P", 3},
                {"F", 4},
                {"H", 4},
                {"V", 4},
                {"W", 4},
                {"Y", 4},
                {"K", 5},
                {"J", 8},
                {"X", 8},
                {"Q", 10},
                {"Z", 10}
            };

            private string double_letter(string word)
            {
                foreach (char letter in word)
                {
                    string letter_string = letter.ToString().ToUpper();
                    store.Add(letter_values[letter_string] * 2);
                }
                return word;
            }

           private string triple_letter(string word)
            {
                foreach (char letter in word)
                {
                    string letter_string = letter.ToString().ToUpper();
                    store.Add(letter_values[letter_string] * 3);
                }
                return word;
            }

    private string normal_word(string word)
            {
                foreach (char letter in word)
                {
                    string letter_string = letter.ToString().ToUpper();
                    store.Add(letter_values[letter_string]);
                }
                return word;
            }

    }
}
