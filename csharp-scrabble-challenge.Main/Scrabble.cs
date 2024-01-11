using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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
        }

        public string Word { get { return _word; } set { _word = value; } }

        public int score()
        { 
            if (Word == "") return 0;

            int result = 0;

            foreach (char c in Word){
                if (c == 'a' || c == 'A' || c == 'e' || c == 'E' || c == 'i' || c == 'I' || c == 'o' || c == 'O'||
                    c == 'u' || c == 'U' || c == 'l' || c == 'L' || c == 'n' || c == 'N' || c == 'r' || c == 'R'||
                    c == 's' || c == 'S' || c == 't' || c == 'T') {
                    result += 1;
                } else if (c == 'd' || c == 'D' || c == 'g' || c == 'G')
                {
                    result += 2;
                } else if (c == 'b' || c == 'B' || c == 'c' || c == 'C' || c == 'm' || c == 'M' || c == 'p' || 
                    c == 'P')
                {
                    result += 3;
                } else if (c == 'f' || c == 'F' || c == 'v' || c == 'V' || c == 'w' || c == 'W' || c == 'y' ||
                    c == 'Y' || c == 'h' || c == 'H')
                {
                    result += 4;
                } else if (c == 'k' || c == 'K')
                {
                    result += 5;
                } else if (c == 'j' || c == 'J' || c == 'x' || c == 'X')
                {
                    result += 8;
                } else if (c == 'q' || c == 'Q' || c == 'z' || c == 'Z')
                {
                    result += 10;
                } else if (c == '{' || c == '}' || c == '[' || c == ']') {
                    result += 0;
                } else {
                    return 0;
                }
                                             
            }

            
            if (Word[0] == '{' && Word[Word.Length-1] == '}')
            {
                result *= 2;
            } else if (Word[0] == '[' && Word[Word.Length-1] == ']') {
                result *= 3;
            } else {
                result += 0;
            }
            

            return result;
            
        }
    }
}
