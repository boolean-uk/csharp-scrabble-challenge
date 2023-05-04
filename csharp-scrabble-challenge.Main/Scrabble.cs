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
        public string word
        {
            get { return _word; }
            set { _word = value; }
        }

        public Scrabble(string word)
        {
            this.word = word;
            //TODO: do something with the word variable
        }

        public int score()
        {
            Dictionary<String, int> table = new Dictionary<String, int>();
            table.Add("AEIOULNRST", 1);
            table.Add("DG", 2);
            table.Add("BCMP", 3);
            table.Add("FHVWY", 4);
            table.Add("K", 5);
            table.Add("JX", 8);
            table.Add("QZ", 10);
            int score = 0;
            string check = _word.ToUpper();

            if (check.Equals(""))
            {
                return 0;
            }



            for (int i = 0; i<check.Length; i++)
            {
                
                if (check[i].Equals(" "))
                {
                    return 0;
                }
                if (check[i].Equals("[") && check[i + 2].Equals("]"))
                {
                    foreach (KeyValuePair<string, int> kvp in table)
                    {
                        if (kvp.Key.Contains(check[i+1]))
                        {
                            score += kvp.Value*3;
                        }
                        i += 2;
                        break;
                    }
                }
                if (check[i].Equals("{") && check[i + 2].Equals("}"))
                {
                    foreach (KeyValuePair<string, int> kvp in table)
                    {
                        if (kvp.Key.Contains(check[i + 1]))
                        {
                            score += kvp.Value * 2;
                        }
                        i += 2;
                        break;
                    }
                }
                foreach (KeyValuePair<string, int> kvp in table)
                {
                    if (kvp.Key.Contains(check[i])){
                        score += kvp.Value;
                    }
                }
            }


            if (check[0].Equals('[') && check[check.Length - 1].Equals(']'))
            {
                score = score*3;
            }
            if (check[0].Equals('{') && check[check.Length - 1].Equals('}'))
            {
                score = score*2;
            }



            return score;
            //TODO: score calculation code goes here
            throw new NotImplementedException(); //TODO: Remove this line when the code has been written
        }
    }
}
