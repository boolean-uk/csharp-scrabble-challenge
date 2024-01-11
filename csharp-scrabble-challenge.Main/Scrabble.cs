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
        public Dictionary<char, int> LetterValues { get; set; } = new Dictionary<char, int>()
        {
            { 'a', 1 },
            { 'b', 3 },
            { 'c', 3 },
            { 'd', 2 },
            { 'e', 1 },
            { 'f', 4 },
            { 'g', 2 },
            { 'h', 4 },
            { 'i', 1 },
            { 'j', 8 },
            { 'k', 5 },
            { 'l', 1 },
            { 'm', 3 },
            { 'n', 1 },
            { 'o', 1 },
            { 'p', 3 },
            { 'q', 10 },
            { 'r', 1 },
            { 's', 1 },
            { 't', 1 },
            { 'u', 1 },
            { 'v', 4 },
            { 'w', 4 },
            { 'x', 8 },
            { 'y', 4 },
            { 'z', 10 }

        };

        public string Word { get; set; }
        public int Multiplier { get; set; } = 1;

        public Scrabble(string word)
        {            
            //TODO: do something with the word variable

            Word = word.ToLower();

        }

        public int score()
        {
            //TODO: score calculation code goes here

            int score = 0;

            for (int i = 0; i < Word.Length; i++)
            {
                switch (Word[i])
                {
                    case ('{'):
                        if (Word[i] == '{') Multiplier *= 2;

                        break;
                    case ('['):
                        if (Word[i] == '[') Multiplier *= 3;

                        break;
                    case ('}'):
                        if (Word[i] == '}') Multiplier /= 2;

                        break;
                    case (']'):
                        if (Word[i] == ']') Multiplier /= 3;

                        break;
                    default:
                        if (LetterValues.ContainsKey(Word[i]))
                        {
                            score += LetterValues.GetValueOrDefault(Word[i]) * Multiplier;
                        }
                        else
                        {
                            Multiplier = 999;
                        }
                        break;
                }
            }

            return Multiplier == 1 ? score : -1;
        }
    }
}
