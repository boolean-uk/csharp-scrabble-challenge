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
        private Dictionary<char, int> scoreTable = new Dictionary<char, int>();
        private string inputWord;
        private int finalScore = 0;
        
        public Scrabble(string word)
        {   
            scoreTable.Add('a', 1);
            scoreTable.Add('b', 3);
            scoreTable.Add('c', 3);
            scoreTable.Add('d', 2);
            scoreTable.Add('e', 1);
            scoreTable.Add('f', 4);
            scoreTable.Add('g', 2);
            scoreTable.Add('h', 4);
            scoreTable.Add('i', 1);
            scoreTable.Add('j', 8);
            scoreTable.Add('k', 5);
            scoreTable.Add('l', 1);
            scoreTable.Add('m', 3);
            scoreTable.Add('n', 1);
            scoreTable.Add('o', 1);
            scoreTable.Add('p', 3);
            scoreTable.Add('q', 10);
            scoreTable.Add('r', 1);
            scoreTable.Add('s', 1);
            scoreTable.Add('t', 1);
            scoreTable.Add('u', 1);
            scoreTable.Add('v', 4);
            scoreTable.Add('x', 8);
            scoreTable.Add('y', 4);
            scoreTable.Add('z', 10);
            //TODO: do something with the word variable
            inputWord = word.ToLower();
        }

        public int score()
        {
            //TODO: score calculation code goes here
            if(inputWord.Length <= 0)
                return 0;

            for(int i = 0; i < inputWord.Length; i++)
            {
                if (scoreTable.ContainsKey(inputWord[i]))
                {
                    finalScore += scoreTable[inputWord[i]];
                } 
            }
            if (inputWord[0] == '[' && inputWord.Last() == ']')
                return finalScore*3;
            else if(inputWord[0] == '{' && inputWord.Last() == '}')
                return finalScore*2;
            else
                return finalScore;
        }
    }
}
