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
        String word;
        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            this.word = word;
        }

        public int score()
        {
            //TODO: score calculation code goes here
           
            int score = 0;
            Dictionary <char, int> map = new Dictionary<char, int>(){
            { 'A', 1},{ 'B', 3},{ 'C', 3},{ 'D', 2},{ 'E', 1},{ 'F', 4},
            { 'G', 2},{ 'H', 4},{ 'I', 1},{ 'J', 8},{ 'K', 5},{ 'L', 1},
            { 'M', 3},{ 'N', 1},{ 'O', 1},{ 'P', 3},{ 'Q', 10},{ 'R', 1},
            { 'S', 1},{ 'T', 1},{ 'U', 1},{ 'V', 4},{ 'X', 8},{ 'Y', 4},
            { 'Z', 10},};

            string newWord= word.ToUpper();
          
            for(int i = 0; i < newWord.Length; i++)
            {

                if (map.ContainsKey(newWord[i]))
                {
                    score += map[newWord[i]];
                }
                else if (!(map.ContainsKey(newWord[i])))
                {
                    if (newWord[i] == '{')
                    {
                        i++;
                        List<char> list = new List<char>();
                        while (newWord[i] != '}')
                        {
                            list.Add(newWord[i]);
                            i++;
                        }
                        for (int j = 0; j < list.Count; j++)
                        {
                            int newscore = map[list[j]];
                            score += newscore * 2;
                        }
                    }
                    else if (newWord[i] == '[')
                    {
                        i++;
                        List<char> list = new List<char>();
                        while (newWord[i] != ']')
                        {
                            list.Add(newWord[i]);
                            i++;
                        }
                        for (int j = 0; j < list.Count; j++)
                        {
                            int newscore = map[list[j]];
                            score += newscore * 3;
                        }


                    }
                }
                

            }
            return score;


        }
      
    }
}
