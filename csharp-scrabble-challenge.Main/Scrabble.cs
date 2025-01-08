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
        private Dictionary<char, int> _letters;

        public Scrabble(string word)
        {
            _letters = new Dictionary<char, int>();
            this._word = word;

            _letters.Add('A', 1);
            _letters.Add('E', 1);
            _letters.Add('I', 1);
            _letters.Add('O', 1);
            _letters.Add('U', 1);
            _letters.Add('L', 1);
            _letters.Add('N', 1);
            _letters.Add('R', 1);
            _letters.Add('S', 1);
            _letters.Add('T', 1);
            _letters.Add('D', 2);
            _letters.Add('G', 2);
            _letters.Add('B', 3);
            _letters.Add('C', 3);
            _letters.Add('M', 3);
            _letters.Add('P', 3);
            _letters.Add('F', 4);
            _letters.Add('H', 4);
            _letters.Add('V', 4);
            _letters.Add('W', 4);
            _letters.Add('Y', 4);
            _letters.Add('K', 5);
            _letters.Add('J', 8);
            _letters.Add('X', 8);
            _letters.Add('Q', 10);
            _letters.Add('Z', 10);
            _letters.Add('{', 0);
            _letters.Add('}', 0);
            _letters.Add('[', 0);
            _letters.Add(']', 0);


            //TODO: do something with the word variable

            // Note: I made it to a global varaible so that it can be accessed by the score method


        }

        public int score()
        {
            int points = 0;
            int multiplier = 1;

            bool doublepoints = false;
            bool triplepoints = false;

            // Converts the word to a list so it can be iterated over, ToUpper so the lower letter is not a different key
            List<char> wordLetters = _word.ToUpper().ToList();
            Console.WriteLine(wordLetters.ToArray());
            for (int i = 0; i < wordLetters.Count; i++)
            {
                if (wordLetters[i]== '{')
                {
                    multiplier *= 2;
                    doublepoints = true;
                }
                else if (wordLetters[i] == '[')
                {
                    multiplier *= 3;
                    triplepoints = true;
                }

                else if (wordLetters[i] == '}')
                {
                    multiplier /= 2;
                    triplepoints = false;
                }
                else if (wordLetters[i] == ']')
                {
                    multiplier /= 3;
                    triplepoints = false;
                }

                if (_letters.ContainsKey(wordLetters[i]))
                {
                    points += _letters[wordLetters[i]] * multiplier;
                }
                else
                {
                    points = 0;
                    break;
                }
                
            }

            if (multiplier != 1)
            {
                points = 0;
            }

            return points;

        }

        
    }
}
