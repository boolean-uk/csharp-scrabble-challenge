using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string _word;
        public Scrabble(string word)
        {
            _word = word.ToLower();
        }
        public string word { get => _word; set => _word = value; }

        public int score()
        {
            Dictionary<char, int> scores = new Dictionary<char, int>();
            scores.Add('a', 1);
            scores.Add('b', 3);
            scores.Add('c', 3);
            scores.Add('d', 2);
            scores.Add('e', 1);
            scores.Add('f', 4);
            scores.Add('g', 2);
            scores.Add('h', 4);
            scores.Add('i', 1);
            scores.Add('j', 8);
            scores.Add('k', 5);
            scores.Add('l', 1);
            scores.Add('m', 3);
            scores.Add('n', 1);
            scores.Add('o', 1);
            scores.Add('p', 3);
            scores.Add('q', 10);
            scores.Add('r', 1);
            scores.Add('s', 1);
            scores.Add('t', 1);
            scores.Add('u', 1);
            scores.Add('v', 4);
            scores.Add('w', 4);
            scores.Add('x', 8);
            scores.Add('y', 4);
            scores.Add('z', 10);
            int result = 0;
            int intOut;
            int modifier = 1;
            char[] charArr = word.ToCharArray();
            
            if(charArr.Length == 0)
            {
                return 0; //If empty return 0
            }

            for(int i = 0; i < charArr.Length; i++)
            {
                if(i != 0 && i != charArr.Length - 1) // Don't check out of bounds
                {
                    if (charArr[i - 1] == '{' && charArr[i + 1] == '}') // Check if letter is surrounded
                    {
                        modifier = 2;
                    }
                    if (charArr[i - 1] == '[' && charArr[i + 1] == ']') // Check if letter is surrounded
                    {
                        modifier = 3;
                    }
                }
                
                scores.TryGetValue(charArr[i], out intOut);
                result += intOut*modifier;
                modifier = 1; // Make sure to reset modifier to default
            }
            if (charArr[0] == '{' && charArr[charArr.Length-1] == '}') // Check if whole word is surrounded
            {
                result = result * 2;
            }
            if (charArr[0] == '[' && charArr[charArr.Length - 1] == ']') //Check if whole word is surrounded
            {
                result = result * 3;
            }
            return result;

        }
    }
}
