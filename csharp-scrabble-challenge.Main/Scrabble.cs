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
        private Dictionary<char, int> _letterscores = new Dictionary<char, int>();
        private string _word;
        private List<int> _multipliers = new List<int>();
        private List<char> _dataChars = ['[', ']', '{', '}'];
        private bool _validWord = true;
        public Scrabble(string word)
        {
            List<char> onePointers = ['a', 'e', 'i', 'o', 'u', 'l', 'n', 'r', 's', 't'];
            List<char> twoPointers = ['d', 'g'];
            List<char> threePointers = ['b', 'c', 'm', 'p'];
            List<char> fourPointers = ['f', 'h', 'v', 'w', 'y'];
            List<char> eightPointers = ['j', 'x'];
            List<char> tenPointers = ['q', 'z'];

            onePointers.ForEach((letter) => this._letterscores.Add(letter, 1));
            twoPointers.ForEach((letter) => this._letterscores.Add(letter, 2));
            threePointers.ForEach((letter) => this._letterscores.Add(letter, 3));
            fourPointers.ForEach((letter) => this._letterscores.Add(letter, 4));
            this._letterscores.Add('k', 5);
            eightPointers.ForEach((letter) => this._letterscores.Add(letter, 8));
            tenPointers.ForEach((letter) => this._letterscores.Add(letter, 10));

            this._word = word.ToLower();
            var hasIllegalChars = this._word.ToArray()
                .Where((character) => !this._letterscores.ContainsKey(character) && !this._dataChars.Contains(character))
                .Any();
            if (hasIllegalChars)
            {
                this._validWord = false;
            }
            try
            {
                this._multipliers = calculateMultipliers();
            } catch (Exception)
            {
                this._validWord = false;
            }
        }

        private List<int> calculateMultipliers()
        {
            List<int> multipliers = new List<int>();
            Stack<char> modifiers = new Stack<char>();
            int multiplier = 1;
            foreach (char character in this._word.ToArray())
            {
                if (character == '[')
                {
                    multiplier *= 3;
                    modifiers.Push('[');
                }
                else if (character == ']')
                {
                    if (modifiers.Pop() != '[')
                    {
                        throw new Exception("invalid modifier");
                    }
                    multiplier /= 3;
                }
                else if (character == '{')
                {
                    multiplier *= 2;
                    modifiers.Push('{');
                }
                else if (character == '}')
                {
                    if (modifiers.Pop() != '{')
                    {
                        throw new Exception("invalid modifier");
                    }
                    multiplier /= 2;
                }
                else
                {
                    multipliers.Add(multiplier);
                }
            }
            if (modifiers.Count != 0) {
                throw new Exception("unclosed modifier");
            }
            return multipliers;
        }

        public int scoreLetter(char character)
        {
            return this._letterscores.GetValueOrDefault(character, 0);
        }

        public int score()
        {
            if (!this._validWord)
            {
                return 0;
            }
            return this._word.ToArray()
                .Where((letter) => !this._dataChars.Contains(letter))
                .Select(this.scoreLetter)
                .Zip(this._multipliers)
                .Select(a => a.First * a.Second)
                .Sum();
        }
    }
}
