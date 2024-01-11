using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private Dictionary<string, int> Letters = new Dictionary<string, int>();
        private string _word;
        private  Char[] _chars;
        private int _specialValueStatus = 1;
        private int _lastSpecialValueStatus = 1;

        public void PopulateDictionary()
        {
            Letters.Add("A", 1);
            Letters.Add("B", 3);
            Letters.Add("C", 3);
            Letters.Add("D", 2);
            Letters.Add("E", 1);
            Letters.Add("F", 4);
            Letters.Add("G", 2);
            Letters.Add("H", 4);
            Letters.Add("I", 1);
            Letters.Add("J", 8);
            Letters.Add("K", 5);
            Letters.Add("L", 1);
            Letters.Add("M", 3);
            Letters.Add("N", 1);
            Letters.Add("O", 1);
            Letters.Add("P", 3);
            Letters.Add("Q", 10);
            Letters.Add("R", 1);
            Letters.Add("S", 1);
            Letters.Add("T", 1);
            Letters.Add("U", 1);
            Letters.Add("V", 4);
            Letters.Add("W", 4);
            Letters.Add("Z", 10);
            Letters.Add("X", 8);
            Letters.Add("Y", 4);
        }


        public Scrabble(string word)
        {
            _word = word.ToUpper();
            _chars = _word.ToCharArray();
            PopulateDictionary();

        }


        public int score()
        {
            int scoreResult = 0;


            for (int i = 0; i < _chars.Length; i++)
            {

                char toCheck = _chars[i];
                string keyToCheck = toCheck.ToString();
                bool lastCharacter = (i== _chars.Length - 1);


                if (Letters.ContainsKey(keyToCheck)) {
                    

                    scoreResult += (Letters[keyToCheck]*_specialValueStatus);

                }
                else {

                    changeStatus(keyToCheck, lastCharacter);
                }

            }
             return scoreResult;
        }

        public void changeStatus(string bracket, bool lastChar)
        {
            if (bracket == null)
            {
                _specialValueStatus = 1;
            }
            else if (bracket == "{")
            {
                _specialValueStatus = 2;
            }
            else if (bracket == "[")
            {
                _specialValueStatus = 3;
            }
            else if ((bracket == "}" || bracket == "]")&&(lastChar))
            {
                _specialValueStatus = 1;
                _lastSpecialValueStatus = 1;
            }else if ((bracket == "}" || bracket == "]") && (!lastChar)) {
                _specialValueStatus = _lastSpecialValueStatus;
            }
        }
    }
}