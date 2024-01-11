using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string _word;
        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            
            _word = word.ToUpper().ToString();
        }

        public int score()
        {
            //TODO: score calculation code goes here
            int points = 0;
            
            bool doubleScore = false;
            bool tripleScore = false;
            string lastLetter = "";
            List<string> Val_1 = new List<string> { "A", "E", "I", "O", "U", "L", "N", "R", "S", "T" };
            List<string> Val_2 = new List<string> { "D", "G" };
            List<string> Val_3 = new List<string> { "B", "C", "M", "P" };
            List<string> Val_4 = new List<string> { "F", "H", "V", "W", "Y" };
            List<string> Val_5 = new List<string> { "K" };
            List<string> Val_8 = new List<string> { "J", "X" };
            List<string> Val_10 = new List<string> { "Q", "Z" };

            // for each letter in the word, add points
            for (int i = 0; i < _word.Length; i++)
            {
                int score;
                string letter = _word[i].ToString();
                // check if letter should be doubled/tripled
                if (lastLetter == "{" && _word[i + 1].ToString() == "}")
                {
                    doubleScore = true;
                }
                else { doubleScore = false; }

                if (lastLetter == "[" && _word[i + 1].ToString() == "]")
                {
                    tripleScore = true;
                }
                else { tripleScore = false; }

                // find the value for each letter
                if (Val_1.Contains(letter))
                {
                    score = 1;
                    //points++;
                }
                else if (Val_2.Contains(letter))
                {

                    score = 2;
                    //points += 2;
                }
                else if (Val_3.Contains(letter))
                {
                    score = 3;
                    //points += 3;
                }
                else if (Val_4.Contains(letter))
                {
                    score = 4;
                    //points += 4;
                }
                else if (Val_5.Contains(letter))
                {
                    score = 5;
                    //points += 5;
                }
                else if (Val_8.Contains(letter))
                {
                    score = 8;
                    //points += 8;
                }
                else if (Val_10.Contains(letter))
                {
                    score = 10;
                    //points += 10;
                }
                else
                {
                    score = 0;
                }
                
                //double or triple the score
                if (doubleScore) { score *= 2; }
                if (tripleScore) { score *= 3; }

                //add the score to the points total
                points = points + score;

                //last letter
                lastLetter = letter;
            }
            
           
            //Check for double/triple word score:
            if (_word.StartsWith("{") && _word.EndsWith("}"))
            {
                points *= 2;
            }
            
            if (_word.StartsWith("[") && _word.EndsWith("]"))
            {
                points *= 3;
            }

            return points;
        }
    }
}
