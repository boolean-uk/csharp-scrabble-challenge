using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{

    /// <summary>
    /// For my scrabble implementation I will be storing all the letters and their score 
    /// as a key value pair in a map. Please see _scoreMap
    /// Letter	Value
    ///A, E, I, O, U, L, N, R, S, T	1
    ///D, G	2
    ///B, C, M, P	3
    ///F, H, V, W, Y	4
    ///K	5
    ///J, X	8
    ///Q, Z	10
    /// </summary>
    public class Scrabble
    {
        private Dictionary<char, int> _scoreMap = new Dictionary<char, int>
        {
            {'A', 1},
            {'E', 1},
            {'I', 1},
            {'O', 1},
            {'U', 1},
            {'L', 1},
            {'N', 1},
            {'R', 1},
            {'S', 1},
            {'T', 1},
            {'D', 2},
            {'G', 2},
            {'B', 3},
            {'C', 3},
            {'M', 3},
            {'P', 3},
            {'F', 4},
            {'H', 4},
            {'V', 4},
            {'W', 4},
            {'Y', 4},
            {'K', 5},
            {'J', 8},
            {'X', 8},
            {'Q', 10},
            {'Z', 10}
        };

        private int _score;
        private string _word;
        public Scrabble(string word)
        {            
            //TODO: do something with the word variable
            _word = word.ToUpper();
        }

        public int score()
        {
            int score = 0;
            int doubleValue = 0;
            int trippleValue = 0;
            List<char> chars = ['{', '}', '[', ']'];
            //TODO: score calculation code goes here
            foreach(char c in _word)
            {
                if (char.IsNumber(c)) return 0;
                if (c == '{') doubleValue += 1;
                if(c == '}') doubleValue -= 1;
                if(c == '[') trippleValue += 1;
                if(c ==  ']') trippleValue -= 1;
                if (chars.Contains(c)) continue;
                if(_scoreMap.TryGetValue(c, out int value))
                    {
                        
                    if (doubleValue > 0) value *= 2;
                    if (trippleValue > 0) value *= 3;
                    score += value;
                };
            }
            if (doubleValue != 0 || trippleValue != 0) return 0;
            return score;
        }
    }
}
