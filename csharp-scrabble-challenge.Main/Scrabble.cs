using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {        
        private Dictionary<char, int> _scoreSheet;
        char[] point1 = "AEIOULNRST".ToCharArray();
        char[] point2 = "DG".ToCharArray();
        char[] point3 = "BCMP".ToCharArray();
        char[] point4 = "FHVWY".ToCharArray();
        char[] point5 = "K".ToCharArray();
        char[] point8 = "JX".ToCharArray();
        char[] point10 = "QZ".ToCharArray();
        string _word;
        int totalScore;
        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            _scoreSheet = new Dictionary<char, int>();
            foreach (char value in point1)
                _scoreSheet.Add(value, 1);
            foreach (char value in point2)
                _scoreSheet.Add(value, 2);
            foreach (char value in point3)
                _scoreSheet.Add(value, 3);
            foreach (char value in point4)
                _scoreSheet.Add(value, 4);
            foreach (char value in point5)
                _scoreSheet.Add(value, 5);
            foreach (char value in point8)
                _scoreSheet.Add(value, 8);
            foreach (char value in point10)
                _scoreSheet.Add(value, 10);
            
            _word = word;
        }

        public int score()
        {
            //TODO: score calculation code goes here
            char[] chars = _word.ToUpper().ToArray();
            foreach (char letter in chars)
            {
                if (_scoreSheet.ContainsKey(letter))
                {
                    totalScore += _scoreSheet[letter];
                }
                else
                {
                    Console.WriteLine($"{letter} is not an accepted letter!");
                    return 0;
                }  
            }
            return totalScore;
        }
    }
}
