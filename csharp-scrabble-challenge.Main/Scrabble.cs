using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        //Fields
        private Dictionary<char, int> _pointLookup = new Dictionary<char, int>();
        private string _word;
        private char[] _letters;

        //Constructor
        public Scrabble(string word)
        {
            Word = word.ToUpper();
            Letters = Word.Trim().ToCharArray();
            populateDictionary();
            score();
        }

        //Setters and Getters
        public string Word { get { return _word; } set { _word = value; } }
        public char[] Letters { get { return _letters; } set { _letters = value; } }
        public Dictionary<char, int> PointLookup { get { return _pointLookup; } set { _pointLookup = value; } }


        public int score()
        {
            //awful code to check in case doubles and trips are opened and not closed
            int bracketCount = 0;
            int squareCount = 0;
            foreach (char c in Letters)
            {
                if (c == '[')
                {
                    squareCount++;
                }
                if (c == ']')
                {
                    squareCount--;
                }
                if (c == '{')
                {
                    bracketCount++;
                }
                if (c == '}')
                {
                    bracketCount--;
                }
            }
            if (bracketCount != 0 || squareCount != 0)
            {
                return 0;
            }

            return calculatePoints(Letters);

        }

        public int calculatePoints(char[] letters)
        {
            int points = 0;
            int multiplier = 1;

            foreach (char ch in letters)
            {
                //Very relative. This option decides that the multipliers themselves are multiplied with each other (2*3=6).
                //Another option is that multipliers are merely added together (2+3=5). I went with multiply, as the tests made by people on discord used this.
                if (ch == '{')
                {
                    multiplier *= 2;
                }
                if (ch == '[')
                {
                    multiplier *= 3;
                }
                if (ch == '}')
                {
                    multiplier /= 2;
                }
                if (ch == ']')
                {
                    multiplier /= 3;
                }


                if (PointLookup.ContainsKey(ch))
                {
                    points += PointLookup.GetValueOrDefault(ch) * multiplier;
                }
            }
            return points;
        }

        public void populateDictionary()
        {
            PointLookup.Add('A', 1);
            PointLookup.Add('B', 3);
            PointLookup.Add('C', 3);
            PointLookup.Add('D', 2);
            PointLookup.Add('E', 1);
            PointLookup.Add('F', 4);
            PointLookup.Add('G', 2);
            PointLookup.Add('H', 4);
            PointLookup.Add('I', 1);
            PointLookup.Add('J', 8);
            PointLookup.Add('K', 5);
            PointLookup.Add('L', 1);
            PointLookup.Add('M', 3);
            PointLookup.Add('N', 1);
            PointLookup.Add('O', 1);
            PointLookup.Add('P', 3);
            PointLookup.Add('Q', 10);
            PointLookup.Add('R', 1);
            PointLookup.Add('S', 1);
            PointLookup.Add('T', 1);
            PointLookup.Add('U', 1);
            PointLookup.Add('V', 4);
            PointLookup.Add('W', 4);
            PointLookup.Add('X', 8);
            PointLookup.Add('Y', 4);
            PointLookup.Add('Z', 10);
        }
    }
}
