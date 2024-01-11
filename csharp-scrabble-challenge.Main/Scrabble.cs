using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
   
    public class Scrabble
    {
        private string _word;
        public Scrabble(string word)
        {            
            //TODO: do something with the word variable
            _word = word;
            _word = _word.ToUpper();


        }

        public int score()
        {
            string input = _word;
            int scoreValue = 0;
            int finalValue = 0;
            bool dblVal = false;
            bool trplVal = false;
            //TODO: score calculation code goes here

            for (int i = 0; i < _word.Length; i++)
            {

                switch (input[i])
                {
                    case 'A': scoreValue = 1;
                        break;
                    case 'E': scoreValue = 1;
                        break;
                    case 'I': scoreValue = 1;
                        break;
                    case 'O': scoreValue = 1;
                        break;
                    case 'U': scoreValue = 1;
                        break;
                    case 'L': scoreValue = 1;
                        break;
                    case 'N': scoreValue = 1;
                        break;
                    case 'R': scoreValue = 1;
                        break;
                    case 'S': scoreValue = 1;
                        break;
                    case 'T': scoreValue = 1;
                        break;
                    case 'D': scoreValue = 2;
                        break;
                    case 'G': scoreValue = 2;
                        break;
                    case 'B': scoreValue = 3;
                        break;
                    case 'C': scoreValue = 3;
                        break;
                    case 'M': scoreValue = 3;
                        break;
                    case 'P': scoreValue = 3;
                        break;
                    case 'F': scoreValue = 4;
                        break;
                    case 'H': scoreValue = 4;
                        break;
                    case 'V': scoreValue = 4;
                        break;
                    case 'W': scoreValue = 4;
                        break;
                    case 'Y': scoreValue = 4;
                        break;
                    case 'K': scoreValue = 5;
                        break;
                    case 'J': scoreValue = 8;
                        break;
                    case 'X': scoreValue = 8;
                        break;
                    case 'Q': scoreValue = 10;
                        break;
                    case 'Z': scoreValue = 10;
                        break;
                    default: scoreValue = 0;
                        break;
                }
                if (input[i] == '{')
                {
                    dblVal = true;
                }
                if (input[i] == '}')
                {
                    dblVal = false;
                }
                if (input[i] == '[')
                {
                    trplVal = true;
                }
                if (input[i] == ']')
                {
                    trplVal = false;
                }

                if (dblVal == true)
                {
                    finalValue += (2 * scoreValue);
                }
                else if (trplVal == true)
                {
                    finalValue += (3 * scoreValue);
                }
                else
                {
                    finalValue += scoreValue;
                }
            }

            return finalValue;
            
        }
    }
}
