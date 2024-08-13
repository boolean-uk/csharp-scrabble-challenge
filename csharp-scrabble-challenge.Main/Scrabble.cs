using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private static string letters;
        private int points = 0;
        private string[] letterCategory =
        {
            
            "AEIOULNRST",
            "DG",
            "BCMP",
            "FHVWY",
            "K",
            "JX",
            "QZ"
        };
        private int[] pointCategory =
        {
            
            1,
            2,
            3,
            4,
            5,
            8,
            10
        };
        public Dictionary<char, int> pointSheet = new Dictionary<char, int>();
        



        public Scrabble(string word)
        {
            letters = word.ToUpper().Trim();
        }




        public int score()
        {
            for (int i = 0; i < pointCategory.Length; i++)
            {
                foreach (char c in letterCategory[i])
                {
                    pointSheet.Add(c, pointCategory[i]);
                }
            }
            foreach (char letter in letters)
                points = (pointSheet.ContainsKey(letter))? points + pointSheet[letter]: points;

            if (letters.Contains('{') && letters.Contains('}'))
                points *= 2;

            if (letters.Contains('[') && letters.Contains(']'))
                points *= 3;

            return points;
        }
    }
}
