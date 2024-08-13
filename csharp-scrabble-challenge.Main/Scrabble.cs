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
        private string _word { get; set; }

        private Dictionary<char, int> points = new Dictionary<char, int>{
            { 'A', 1}, { 'B', 3}, { 'C', 3}, { 'D', 2}, { 'E', 1}, { 'F', 4}, { 'G', 2}, { 'H', 4},{ 'I', 1}, { 'J', 8}, { 'K', 5}, { 'L', 1}, { 'M', 3}, { 'N', 1}, { 'O', 1}, { 'P', 3}, { 'Q', 10}, { 'R', 1}, { 'S', 1}, { 'T', 1}, { 'U', 1}, { 'V', 4}, { 'W', 4}, { 'X', 8}, { 'Y', 4},{ 'Z', 10}
        };
        public Scrabble(string word)
        {            
            //TODO: do something with the word variable
            _word = word.ToUpper();
        }

        public int score()
        {
            bool wordmult = false;
            bool opencCurlyBrack = false;
            bool opencSquereBrack = false;
            if (_word == "") return 0;
            int score = 0;
            int charmultiplier = 1;
            int wordmultiplier = 1;
            if (this._word[0] == '{' && this._word[_word.Length - 1] == '}')
            {
                wordmultiplier = 2;
                wordmult = true;
                opencCurlyBrack = true;
            }
            else if (this._word[0] == '[' && this._word[_word.Length - 1] == ']')
            {
                wordmultiplier = 3;
                wordmult = true;
                opencSquereBrack= true;
            }
            for (int i = 0; i < _word.Length; i++)
            {
                char c = _word[i];
                if (points.ContainsKey(c)) score += this.points[c] * charmultiplier;
                if (c == '{' && _word[i + 2] == '}')
                {
                    if (i == 0 && wordmult)
                    {
                        wordmult = false;
                        wordmultiplier = 1;
                    }
                    charmultiplier = 2;
                    opencCurlyBrack = true;
                }
                else if (c == '[' && _word[i + 2] == ']')
                {
                    if (i == 0 && wordmult)
                    {
                        wordmult = false;
                    }
                    charmultiplier = 3;
                    opencSquereBrack = true;
                }
                else if (c == ']' && opencSquereBrack)
                {
                    charmultiplier = 1;
                    opencSquereBrack = false;
                }
                else if (c == '}' && opencCurlyBrack)
                {
                    charmultiplier = 1;
                    opencCurlyBrack = false;
                }
                else if (c == ']' && !opencSquereBrack && (c != _word.Length -1))
                {
                    return 0;
                }
                else if (c == '}' && !opencCurlyBrack && (c != _word.Length - 1))
                {
                    return 0;
                }

                    if (char.IsDigit(c)) return 0;
            }

            return score*wordmultiplier;
            //throw new NotImplementedException(); //TODO: Remove this line when the code has been written
        }
    }
}
