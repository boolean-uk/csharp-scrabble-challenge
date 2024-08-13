using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private Dictionary<string, int> pointList = new Dictionary<string, int>() {
            { "a", 1 },
            { "e", 1 },
            { "i", 1 },
            { "o", 1 },
            { "u", 1 },
            { "l", 1 },
            { "n", 1 },
            { "r", 1 },
            { "s", 1 },
            { "t", 1 },
            { "d", 2 },
            { "g", 2 },
            { "b", 3 },
            { "c", 3 },
            { "m", 3 },
            { "p", 3 },
            { "f", 4 },
            { "h", 4 },
            { "v", 4 },
            { "w", 4 },
            { "y", 4 },
            { "k", 5 },
            { "j", 8 },
            { "x", 8 },
            { "q", 10 },
            { "z", 10 },
        };
        private char[] word;
        private bool doubleScore = false;
        private bool tripleScore = false;

        public Scrabble(string word)
        {
            word = word.ToLower();
            //Regex rgx = new Regex(@"\[\^a\-zA\-Z~\[\]{} \-\]");
            //word = rgx.Replace(word, "");
            //_word = word.ToLower();
            //if (!string.IsNullOrEmpty(word) && !string.IsNullOrWhiteSpace(_word))
            //{
            //    //score();
            //} else
            //{
            //    _word = "";
            //}

            checkModifier(word);

            if (doubleScore)
            {
                word = word.Substring(1, word.Length - 2);
            }
            if (tripleScore)
            {
                word = word.Substring(1, word.Length - 2);
            }
        //TODO: do something with the word variable


            if (!string.IsNullOrEmpty(word) && word.All(char.IsLetter) && !string.IsNullOrWhiteSpace(word) || doubleScore || tripleScore)
            {
                this.word = word.ToCharArray();
                //score();
            }
            else
            {
                this.word = new char[0];
                //score();
            }
        }

        private void checkModifier(string word)
        {

            string[] doubleCheck = word.Split('{', '}');
            //string[] tripleCheck = new string[0];
            string[] tripleCheck = word.Split('[', ']');

            //if (Regex.IsMatch(word, @"\[[^]]*]|[^,]+"))
            //{
            //    tripleCheck = new string[3];

            //    tripleCheck[0] = "[";
            //    tripleCheck[1] = "a";
            //    tripleCheck[2] = "]";

            //}

            if (doubleCheck.Length < 2)
            {
                if (!Regex.IsMatch(doubleCheck[0], @" ^ [a-zA-Z{}]+$")) /*|| !Regex.IsMatch(tripleCheck[0], @"^[a-z\[\]A-Z]+$")) return*/;
                if (!Regex.IsMatch(tripleCheck[0], @"^[a-z\[\]A-Z]+$")) return;

            }

            if (doubleCheck.Length == 3)
            {
                if (!doubleCheck.All(string.IsNullOrEmpty) && !doubleCheck.All(string.IsNullOrWhiteSpace))
                {
                    doubleScore = true;
                }
            }

            if (tripleCheck.Length == 3)
            {
                if (!tripleCheck.All(string.IsNullOrEmpty) && !tripleCheck.All(string.IsNullOrWhiteSpace))
                {
                    tripleScore = true;

                }
            }



        }

        public int score()
        {
            //TODO: score calculation code goes here
            int score = 0;

            foreach (var item in this.word)
            {
                string letter = item.ToString();
                score += this.pointList[letter];
            }
            if (doubleScore)
            {
                return score * 2;
            }
            return score;

            //else if (tripleScore)
            //{
            //    return score * 3;
            //}

            //return score;
            //if (doubleScore)
            //{
            //    return score * 2;

            //}
            //else if (tripleScore)
            //{
            //    return score * 3;
            //}
            //else
            //{
            //    return score;
            //}
        }
    }
}
