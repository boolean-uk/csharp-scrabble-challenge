using System;
using System.Collections;
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
            _word = word;
        }

        public int score()
        {

            Dictionary<string, int> wordMap = new Dictionary<string, int>()
            {
                {"A",1},{"B",3},{"C",3},{"D",2},{"E",1},{"F",4},{"G",2},
                {"H",4},{"I",1},{"J",8},{"K",5},{"L",1},{"M",3},{"N",1},
                {"O",1},{"P",3},{"Q",10},{"R",1},{"S",1},{"T",1},{"U",1},
                {"V",4},{"W",4},{"X",8},{"Y",4},{"Z",10}
            };
            char[] chars = _word.ToUpper().ToCharArray();
            int result = 0;
            int letterBonus = 1;
            int value;
            for (int i = 0; i < chars.Length; i++)
            {
                if (i != 0 && i !=  chars.Length - 1)
                {
                    if (chars[i - 1] == '{'  && chars[i + 1] == '}')
                    {
                        letterBonus = 2;
                    }
                    if (chars[i - 1] == '[' && chars[i + 1] == ']')
                    {
                        letterBonus = 3;
                    }
                }
                wordMap.TryGetValue(chars[i].ToString(), out value);
                result += letterBonus * value;
                letterBonus = 1;
            }

            if (chars[0] == '{' && chars[chars.Length - 1] == '}')
            {
                result = result * 2;
            }
            if (chars[0] == '[' && chars[chars.Length - 1] == ']')
            {
                result = result * 3;
            }
            
            return result;
        }





    }
}

