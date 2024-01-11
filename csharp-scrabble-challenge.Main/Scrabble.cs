using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string _word;
        private int _score = 0;
        private Dictionary<string, int> _scrabbleList = new Dictionary<string, int>
        {
            ["AEIOULNRST"] = 1,
            ["DG"] = 2,
            ["BCMP"] = 3,
            ["FHVWY"] = 4,
            ["K"] = 5,
            ["JX"] = 8,
            ["QZ"] = 10
        };

        public Scrabble(string word)
        {            
            _word = word;
        }

        public int score()
        {
            //TODO: score calculation code goes here
            List<int> calc = new List<int>();
            Dictionary<char, int> multiplier = new Dictionary<char, int>();

            // prehandling - clean the string
            this._word.Trim().Replace("\n", "").Replace("\t", "").Replace("\f", "").Replace("\b", "").Replace("\r", "");

            

            // multiplier log
            if (this._word.Contains("{"))
            {
                string pattern_wv = @"\{(.*?)\}";
                string s = Regex.Match(this._word, pattern_wv).Value.Replace("{", "").Replace("}", "")
                    .Replace("[", "").Replace("]", "");

                string ns = String.Join("", s.ToUpper().Distinct());


                foreach (char c in ns)
                {
                    char cc = Char.ToUpper(c);
                    multiplier[cc] = 2;
                }
            }

            if (this._word.Contains("["))
            {
                string pattern_wv = @"\[(.*?)\]";
                string s = Regex.Match(this._word, pattern_wv).Value.Replace("[", "").Replace("]", "")
                    .Replace("{", "").Replace("}", "");

                string ns = String.Join("", s.ToUpper().Distinct());

                foreach (char c in ns)
                {
                    char cc = Char.ToUpper(c);

                    if (multiplier.Keys.Contains(cc))
                    {
                        multiplier[cc] = multiplier[cc] * 3;
                    }

                    else
                    {
                        multiplier[cc] = 3;
                    }

                }

            }


            // the string is empty! 
            if (this._word.Length < 1)
            {
                return 0;
            }


            // calculate score
            foreach (KeyValuePair<string, int> entry in _scrabbleList)
            {

                foreach (char c in this._word)
                {
                    char cc = Char.ToUpper(c);

                    if (!entry.Key.Contains(cc))
                    {
                        continue;
                    }
                   
                    int count = entry.Key.Count(f => f == cc);

                    int mlt = 1;

                    if (multiplier.ContainsKey(cc))
                    {
                        mlt = multiplier[cc];
                    }

                    calc.Add(entry.Value * mlt);

                }
             
            }

            return calc.Sum();

        }

        public string Word { get { return _word; } }
        public int Score { get { return _score; } }
    }
}
