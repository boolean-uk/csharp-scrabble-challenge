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
        private Dictionary<char, int> _letterValues;
        private string? _word;

        public Scrabble(string word)
        {
            _letterValues = new Dictionary<char, int>();
            _letterValues.Add('A', 1);
            _letterValues.Add('B', 3);
            _letterValues.Add('C', 3);
            _letterValues.Add('D', 2);
            _letterValues.Add('E', 1);
            _letterValues.Add('F', 4);
            _letterValues.Add('G', 2);
            _letterValues.Add('H', 4);
            _letterValues.Add('I', 1);
            _letterValues.Add('J', 8);
            _letterValues.Add('K', 5);
            _letterValues.Add('L', 1);
            _letterValues.Add('M', 3);
            _letterValues.Add('N', 1);
            _letterValues.Add('O', 1);
            _letterValues.Add('P', 3);
            _letterValues.Add('Q', 10);
            _letterValues.Add('R', 1);
            _letterValues.Add('S', 1);
            _letterValues.Add('T', 1);
            _letterValues.Add('U', 1);
            _letterValues.Add('V', 4);
            _letterValues.Add('W', 4);
            _letterValues.Add('X', 8);
            _letterValues.Add('Y', 4);
            _letterValues.Add('Z', 10);


            //TODO: do something with the word variable

             _word = word.ToUpper();
            
        }

        public int score()
        {
            //TODO: score calculation code goes here
            int score = 0;
            

            foreach(var letter in _word)
            {
                if (_letterValues.ContainsKey(letter))
                {
                    score += _letterValues[letter];
                    
                }

                if (letter == '{')
                {

                }   
                
                if (letter == '[')
                {
                   
                }
                    
            }

            return score;
            
            
        }
    }
}
