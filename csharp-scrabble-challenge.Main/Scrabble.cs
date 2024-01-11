using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    
    public class Scrabble
    {
        private string _word;



        private Dictionary<char, int> scoreDictionary;

        private List<char> multiplyer;

        public Scrabble(string word)
        {       
            //TODO: do something with the word variable

            scoreDictionary = new Dictionary<char, int>();

            scoreDictionary.Add('a', 1);
            scoreDictionary.Add('e', 1);
            scoreDictionary.Add('i', 1);
            scoreDictionary.Add('o', 1);
            scoreDictionary.Add('u', 1);
            scoreDictionary.Add('l', 1);
            scoreDictionary.Add('n', 1);
            scoreDictionary.Add('r', 1);
            scoreDictionary.Add('s', 1);
            scoreDictionary.Add('t', 1);
            scoreDictionary.Add('d', 2);
            scoreDictionary.Add('g', 2);
            scoreDictionary.Add('b', 3);
            scoreDictionary.Add('c', 3);
            scoreDictionary.Add('m', 3);
            scoreDictionary.Add('p', 3);
            scoreDictionary.Add('f', 4);
            scoreDictionary.Add('h', 4);
            scoreDictionary.Add('v', 4);
            scoreDictionary.Add('w', 4);
            scoreDictionary.Add('y', 4);
            scoreDictionary.Add('k', 5);
            scoreDictionary.Add('j', 8);
            scoreDictionary.Add('x', 8);
            scoreDictionary.Add('q', 10);
            scoreDictionary.Add('z', 10);

            multiplyer = new List<char>();
            multiplyer.Add('{');
            multiplyer.Add('}');
            multiplyer.Add('[');
            multiplyer.Add(']');
             
                
            _word = word;

            score();
        }

        public int score()
        {
            //TODO: score calculation code goes here
            char[] letters = _word.ToLower().ToArray();
            int totalScore = 0;


            int doubleScoreIndexStart = 0;  
            int doubleScoreIndexEnd = 0;
            int tripleScoreIndexStart = 0;
            int tripleScoreIndexEnd = 0;
            for (int i = 0; i < letters.Length; i++)
            {
                if (scoreDictionary.ContainsKey(letters[i]))
                {

                    totalScore = totalScore + scoreDictionary[letters[i]];

                }
                else if (multiplyer.Contains(letters[i]))
                {
                    if (letters[i] == '{')
                    {
                        doubleScoreIndexStart = i;

                    }
                    if (letters[i] == '[')
                    {
                        tripleScoreIndexStart = i;
                    }
                    if (letters[i] == '}')
                    {
                        doubleScoreIndexEnd = i;

                    }
                    if (letters[i] == ']')
                    {
                        tripleScoreIndexEnd = i;
                    }



                }
                else
                {
                    totalScore = 0;
                    break;
                }
            }
            if(doubleScoreIndexStart != doubleScoreIndexEnd)
            {
                for(int i = doubleScoreIndexStart; i <= doubleScoreIndexEnd; i++)
                {
                    if (scoreDictionary.ContainsKey(letters[i]))
                    {
                        totalScore = totalScore + scoreDictionary[letters[i]];

                    }
                }
            }

            if(tripleScoreIndexStart != tripleScoreIndexEnd)
            {
                for (int i = tripleScoreIndexStart; i <= tripleScoreIndexEnd; i++)
                {
                    if (scoreDictionary.ContainsKey(letters[i]))
                    {

                        totalScore = totalScore + (2 * scoreDictionary[letters[i]]);
                    }
                }
            }



            return totalScore;

        }
    }
}
