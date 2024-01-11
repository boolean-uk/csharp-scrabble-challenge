using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {

        public string _word = "";
        
       
 
        public Scrabble(string word)
        {
            _word = word;
        }

        public int score()
        {
            int _score = 0;
            int multiplier = 1;
            //TODO: score calculation code goes here
            //throw new NotImplementedException(); //TODO: Remove this line when the code has been written


            for (int i = 0; i < _word.Length; i++)
            {
                if (i > 0 && _word[i] == '{')
                {
                    multiplier = 2;
                  
                }
                else if (i > 0 && _word[i] == '[')
                {
                    multiplier = 3;
                    
                }

                if (char.ToLower(_word[i]) == 'a' || char.ToLower(_word[i]) == 'e' || char.ToLower(_word[i]) == 'i' || char.ToLower(_word[i]) == 'o' ||
                   char.ToLower(_word[i]) == 'u' ||
                  char.ToLower(_word[i]) == 'l' || char.ToLower(_word[i]) == 'n' || char.ToLower(_word[i]) == 'r' || char.ToLower(_word[i]) == 's' ||
                  char.ToLower(_word[i]) == 't' )
                {
                    _score += (1*multiplier) ;
                    multiplier = 1;
                }
                else if (char.ToLower(_word[i]) == 'd' || char.ToLower(_word[i]) == 'g')
                {
                    _score += (2*multiplier);
                    multiplier = 1;
                }
                else if (char.ToLower(_word[i]) == 'b' || char.ToLower(_word[i]) == 'c' || char.ToLower(_word[i]) == 'm' || char.ToLower(_word[i]) == 'p')
                {
                    _score += (3 * multiplier);
                    multiplier = 1;
                }
                else if (char.ToLower(_word[i]) == 'f' || char.ToLower(_word[i]) == 'h' || char.ToLower(_word[i]) == 'v' ||
                    char.ToLower(_word[i]) == 'w' || char.ToLower(_word[i]) == 'y')
                {
                    _score += (4 * multiplier);
                    multiplier = 1;
                }
                else if (char.ToLower(_word[i]) == 'k')
                {
                    _score += (5 * multiplier);
                    multiplier = 1;
                }
                else if (char.ToLower(_word[i]) == 'j' || char.ToLower(_word[i]) == 'x')
                {
                    _score += (8 * multiplier);
                    multiplier = 1;
                }
                else if (char.ToLower(_word[i]) == 'q' || char.ToLower(_word[i]) == 'z')
                {
                    _score += (10 * multiplier);
                    multiplier = 1;
                }
                else {_score += 0;}
                
                
            }

            if (_word != string.Empty)
            {
                if (_word[0] == '{' && _word[_word.Length-1] == '}') { _score *= 2; }
                if (_word[0] == '[' && _word[_word.Length - 1] == ']') { _score *= 3; }
            }

            return _score;
        }









    }
}
