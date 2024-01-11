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

        private string _word;
        private int points = 0; //For storing of points.

        private Dictionary<List<char>, int> _dictionary = new Dictionary<List<char>, int>();

        private List<char> letters = new List<char>(); //A List for input letters
        List<char> list1 = new List<char>() { 'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T' };
        List<char> list2 = new List<char>() { 'D', 'G' };
        List<char> list3 = new List<char>() { 'B', 'C', 'M', 'P' };
        List<char> list4 = new List<char>() { 'F', 'H', 'V', 'W', 'Y' };
        List<char> list5 = new List<char>() { 'K' };
        List<char> list8 = new List<char>() { 'J', 'X' };
        List<char> list10 = new List<char>() { 'Q', 'Z' };
       
        public Scrabble(string word)
        {
            _word = word;
            letters = word.ToCharArray().ToList();

            //Setting up the letter score dic:
         
            _dictionary.Add(list1, 1);
            _dictionary.Add(list2, 2);
            _dictionary.Add(list3, 3);
            _dictionary.Add(list4, 4);
            _dictionary.Add(list5, 5);
            _dictionary.Add(list8, 8);
            _dictionary.Add(list10, 10);




        }

        public int score()
        {
            // Check if input words is not empty and not contains special characters.
            if (!letters.Any() || !ContainsOnlyLetters(_word) )
            {
                points = 0;
               
            }
            else {
                // Check the score with the dictionary of words
                foreach (var kvp in _dictionary)
                    foreach (char letter in letters)
                    {
                        if (kvp.Key.Contains(char.ToUpper(letter)))
                        {
                            points += kvp.Value;

                           
                        }

                        
                    }

                // Check for x2 / x3 word
                if (checkDTWord(_word) != 0)
                {
                    points *= checkDTWord(_word);
                }

                // Check for x2 / x3 Letter
                else if (checkDTLetter(_word) != 0)
                {
                    points += checkDTLetter(_word);
                }

            }

           

            return points;

        }

        static bool ContainsOnlyLetters(string input)
        {
            // Define a regular expression pattern to match only letters
            Regex regex = new Regex("^[a-zA-Z{}\\[\\]]+$");

            // Check if the input matches the pattern
            return regex.IsMatch(input);
        }

        public int checkDTLetter(string word)
        {
            int extraPoint = 0;
            //throw new NotImplementedException();
            // If letter is {/[ and not first n+1 *2
            for (int i = 0; i < letters.Count; i++)
            {
                if (letters[i] == '{' && letters.First() != '{') {
                    foreach (var kvp in _dictionary)
                    {
                        if (kvp.Key.Contains(char.ToUpper(letters[i + 1])))
                        {
                            extraPoint += (kvp.Value * 2) - kvp.Value;
                            return extraPoint;
                        }
                    }
                    
                }
                else if (letters[i] == '[' && letters.First() != '[')
                {
                    foreach (var kvp in _dictionary)
                    {
                        if (kvp.Key.Contains(char.ToUpper(letters[i + 1])))
                        {
                            extraPoint += (kvp.Value * 3) - kvp.Value;
                            return extraPoint;
                        }
                    }
                }
            }

            return 0;
        }

        public int checkDTWord(string word)
        {
            int extraPoint = 0; 
            if (letters.First() == '{' && letters.Last() == '}')
            {
                return extraPoint = 2; 
            }
            else if (letters.First() == '[' && letters.Last() == ']')
            {
                return extraPoint = 3;
            }
            return 0;
            
        }

    }
}
