using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private Dictionary<char, int> _letterPoints;
        private string _word;

        public Scrabble(string word)
        {
            _word = word;
            //TODO: do something with the word variable

            _letterPoints = new Dictionary<char, int>();
            _letterPoints.Add('A', 1);
            _letterPoints.Add('E', 1);
            _letterPoints.Add('I', 1);
            _letterPoints.Add('O', 1);
            _letterPoints.Add('U', 1);
            _letterPoints.Add('L', 1);
            _letterPoints.Add('N', 1);
            _letterPoints.Add('R', 1);
            _letterPoints.Add('S', 1);
            _letterPoints.Add('T', 1);
            _letterPoints.Add('D', 2);
            _letterPoints.Add('G', 2);
            _letterPoints.Add('B', 3);
            _letterPoints.Add('C', 3);
            _letterPoints.Add('M', 3);
            _letterPoints.Add('P', 3);
            _letterPoints.Add('F', 4);
            _letterPoints.Add('H', 4);
            _letterPoints.Add('V', 4);
            _letterPoints.Add('W', 4);
            _letterPoints.Add('Y', 4);
            _letterPoints.Add('K', 5);
            _letterPoints.Add('J', 8);
            _letterPoints.Add('X', 8);
            _letterPoints.Add('Q', 10);
            _letterPoints.Add('Z', 10);

        }
            
        // An atempt at the criteria from discord. Not working at all. Core tests shoulkd pass tho
        public int score()
        {
            int points = 0;
            int tempPoints = 0;

            List<int> placeTaken = new List<int>();


            //iterate throgh each letter in the word
            foreach (char c in _word)
            {   //convert all letters to uppercase to match the letters in library
                char upperC = Char.ToUpper(c);

                //check to see if library contains letter
                if (_letterPoints.ContainsKey(upperC))
                {
                    
                    points += _letterPoints[upperC];

                }
                //doubles all inside the brackets
                else if(upperC == '{')
                {
                    for(int i = _word[upperC]; i < _word.Length; i++)
                    {
                        tempPoints += _letterPoints[upperC];
                        //add place to list so it doesn't get counted twice when the loop exits. Keeps track of wich numbers get counted here
                        //Something like this has to work but this is not it
                        placeTaken.Add(i);

                        if (upperC == '}') 
                        {
                            points += (tempPoints)*2;
                            break;
                        } 
                    }
                }
                
            }

           
            return points;
        }


    }
}

