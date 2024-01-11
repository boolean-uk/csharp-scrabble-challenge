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
        private Dictionary<char, int> _letterValue = new Dictionary<char, int>(){
            { 'A', 1}, { 'B', 3}, { 'C', 3}, { 'D', 2}, { 'E', 1}, { 'F', 4}, { 'G', 2},
            { 'H', 4}, { 'I', 1}, { 'J', 8}, { 'K', 5}, { 'L', 1}, { 'M', 3}, { 'N', 1},
            { 'O', 1}, { 'P', 3}, { 'Q', 10}, { 'R', 1}, { 'S', 1}, { 'T', 1}, { 'U', 1},
            { 'V', 4}, { 'W', 4}, { 'X', 8}, { 'Y', 4}, { 'Z', 10}
        };

        string[] illegalWords = { "\a", "\b" , "\n" , "\r" , "\f", "\t", "\v"};


        private string _inputWordBuffer;

        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            word = word.ToUpper();

            RemoveIllegalWords(word);

            // Calculate Score
            _inputWordBuffer = word;

            score();
        }

        private string RemoveIllegalWords(string word)
        {
            // Remove illegal words
            for (int i = 0; i < illegalWords.Length; i++)
            {
                word.Replace(illegalWords[i], "");
            }
            return word;
        }

        private int MultiplierValue(char c)
        {
            int multiplierVal = 0;

            switch (c)
            {
                case '[':
                    multiplierVal += 2;
                    break;
                case '{':
                    multiplierVal += 1;
                    break;

                case ']':
                    multiplierVal += 2;
                    break;
                case '}':
                    multiplierVal -= 1;
                    break;
                default:
                    break;
            }

            return multiplierVal;
        }

        public int score()
        {
            int result = 0;

            int letterMultiplier = 1;

            foreach (char c in _inputWordBuffer)
            {
                // Calc multiplier
                letterMultiplier += MultiplierValue(c);
                if (MultiplierValue(c) > 0)
                    continue;
                if (letterMultiplier < 1)
                    letterMultiplier = 1;

                // Check if letter has a value, if so: add to score
                if (_letterValue.ContainsKey(c))
                {
                    _letterValue.TryGetValue(c, out int value);
                    result += value * letterMultiplier;
                }
            }

            return result;
        }
    }
}
