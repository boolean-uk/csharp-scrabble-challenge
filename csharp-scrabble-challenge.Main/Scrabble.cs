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

        string[] _illegalWords = { "\a", "\b" , "\n" , "\r" , "\f", "\t", "\v"};
        int _letterMultiplier = 1;

        private string _inputWordBuffer = "";

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
            for (int i = 0; i < _illegalWords.Length; i++)
            {
                word.Replace(_illegalWords[i], "");
            }
            return word;
        }

        private int MultiplierValue(char c)
        {
            switch (c)
            {
                case '[':
                    _letterMultiplier *= 3;
                    break;
                case '{':
                    _letterMultiplier *= 2;
                    break;

                case ']':
                    _letterMultiplier /= 3;
                    break;
                case '}':
                    _letterMultiplier /= 2;
                    break;
                default:
                    break;
            }

            if (_letterMultiplier < 1)
                return _letterMultiplier = 1;
            return _letterMultiplier;
        }

        public int score()
        {
            int result = 0;

            // Check for bracket errors
            char[] bracketTypes = new char[3] { '(', '{', '[' };
            char[] bracketTypesReverse = new char[3] { ')', '}', ']' };

            for (int i = 0; i < bracketTypes.Length; i++)
                if (_inputWordBuffer.Count(c => c == bracketTypes[i]) !=
                    _inputWordBuffer.Count(c => c == bracketTypesReverse[i]) &&
                    _inputWordBuffer.Count(c => c == bracketTypesReverse[i]) != 0
                     )
                {
                    return -1;
                }

            // Check for numbers
            if (_inputWordBuffer.Any(char.IsDigit))
                return 0;

            // Calculate score
            foreach (char c in _inputWordBuffer)
            {
                // Calc multiplier
                MultiplierValue(c);

                // Check if letter has a value, if so: add to score
                if (_letterValue.ContainsKey(c))
                {
                    _letterValue.TryGetValue(c, out int value);
                    result += value * _letterMultiplier;
                }
            }

            return result;
        }
    }
}
