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
        private Dictionary<char, int> _characterValueDictionary = new Dictionary<char, int>
        {
            {'a', 1}, {'b', 3}, {'c', 3},
            {'d', 2}, {'e', 1}, {'f', 4},
            {'g', 2}, {'h', 4}, {'i', 1},
            {'j', 8}, {'k', 5}, {'l', 1},
            {'m', 3}, {'n', 1}, {'o', 1},
            {'p', 3}, {'q', 10}, {'r', 1},
            {'s', 1}, {'t', 1}, {'u', 1},
            {'v', 4}, {'w', 4}, {'x', 8},
            {'y', 4}, {'z', 10}
        };
        private string _word;

        public Scrabble(string word)
        {
            Word = word.ToLower();
        }

        public string Word { get { return _word; } set { _word = value.ToLower(); } }

        public int Score()
        {
            if (Word.Length == 0)
            {
                return 0;
            }
            return AddScore(Word);
        }

        public int CharacterScore(char c)
        {
            if (_characterValueDictionary.ContainsKey(c))
            {
                return _characterValueDictionary[c];
            }
            return 0;
        }

        private int AddScore(string str, int multiplier = 1)
        {
            int score = 0;
            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case '{':
                        return score + AddScore(str.Substring(i + 1), multiplier * 2);
                    case '[':
                        return score + AddScore(str.Substring(i + 1), multiplier * 3);
                    case '}':
                        return score + AddScore(str.Substring(i + 1), multiplier / 2);
                    case ']':
                        return score + AddScore(str.Substring(i + 1), multiplier / 3);
                    default:
                        score += CharacterScore(str[i]) * multiplier;
                        break;
                }
            }
            return score;
        }
    }
}
