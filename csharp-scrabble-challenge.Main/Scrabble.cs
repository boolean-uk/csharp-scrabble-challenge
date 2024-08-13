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
        string _word;

        Dictionary<char, int> _scoreValues = new Dictionary<char, int>();
        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            _word = word.ToUpper();

            List<char> one = ['A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T'];
            List<char> two = ['D', 'G'];
            List<char> three = ['B', 'C', 'M', 'P'];
            List<char> four = ['F', 'H', 'V', 'W', 'Y'];
            List<char> five = ['K'];
            List<char> eight = ['J', 'X'];
            List<char> ten = ['Q', 'Z'];

            foreach (var item in one)
            {
                _scoreValues.Add(item, 1);
            }
            foreach (var item in two) 
            {
                _scoreValues.Add(item, 2);
            }
            foreach (var item in three)
            {
                _scoreValues.Add(item, 3);
            }
            foreach (var item in four)
            {
                _scoreValues.Add(item, 4);
            }
            foreach (var item in five)
            {
                _scoreValues.Add(item, 5);
            }
            foreach (var item in eight)
            {
                _scoreValues.Add(item, 8);
            }
            foreach (var item in ten)
            {
                _scoreValues.Add(item, 10);
            }

        }

        public int score()
        {
            //TODO: score calculation code goes here
            int value = 0;
            int multiplier = 1;
            string output = "";

            // Some extremely simple checking of an equal amount of brackets existing on both sides
            // This could easily break if the tests were more evil!
            // Ideally, you would look for a starting bracket, and an ending bracket,
            // and make sure that they are properly encapsulating
            int countCurly1 = _word.Count(f => f == '{');
            int countCurly2 = _word.Count(f => f == '}');
            int countBracket1 = _word.Count(f => f == '[');
            int countBracket2 = _word.Count(f => f == ']');
            if (countCurly1 != countCurly2) return 0;
            if (countBracket1 != countBracket2) return 0;

            for (int i = 0; i < _word.Length; i++)
            {
                // Check if current char is a bracket, if it is,
                // increase the multiplier, continue to next char
                if (_word[i] == '{')
                {
                    multiplier = multiplier * 2;
                    continue;
                }
                else if (_word[i] == '}')
                {
                    multiplier = multiplier / 2;
                    continue;
                }
                else if (_word[i] == '[')
                {
                    multiplier = multiplier * 3;
                    continue;
                }
                else if (_word[i] == ']')
                {
                    multiplier = multiplier / 3;
                    continue;
                }

                // Add character to output, with possible multiplication of the char
                for (int j = 0; j < multiplier; j++)
                {
                    output += _word[i];
                }
            }



            foreach (char c in output)
            {
                if (_scoreValues.ContainsKey(c) == false)
                {
                    return 0;
                }
                value += _scoreValues[c];
            }

            return value;
        }
    }
}
