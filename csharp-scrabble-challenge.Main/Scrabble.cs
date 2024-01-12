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
        private string _originalWord;
        private string _word;

        private List<string> _doubleLetters = new List<string>();
        private List<string> _tripleLetters = new List<string>();

        private List<string> _doubleWords = new List<string>();
        private List<string> _tripleWords = new List<string>();

        private Dictionary<string, int> _points = new Dictionary<string, int>();
        int _version;

        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            _version = 2;
            _originalWord = word;
            _word = ProcessWord(_originalWord);
            if (_version == 1)
            {
                interpretMultiplier(ref _word);
            }
            populatePointsDict();

        }

        /// <summary>
        /// Remove any registered stopWord token from the provided string.
        /// </summary>
        /// <param name="word"> The string to be processed </param>
        /// <returns> A string of the processed input </returns>
        internal string ProcessWord(string word)
        {
            string processed = word.ToLower();
            string[] stopWords = ["-", "_", ":", ".", ",", ";", "'", "*", " " ,"\n", "\t", "?", "!"];
            foreach (string token in stopWords)
            {
                if (word.Contains(token)) 
                {
                    removeToken(ref processed, token);
                }
            }
            return processed;
        }

        /// <summary>
        /// Remove a specified token from the provided word. This method require a string passed by reference!
        /// </summary>
        /// <param name="word"> Referance variable of the string to remove a token from. </param>
        /// <param name="token"> The token that is to be removed from the word. </param>
        internal void removeToken(ref string word, string token)
        {
            word = word.Replace(token, "");
        }

        /// <summary>
        /// Remove a specified token from the provided word. This method require a string passed by reference!
        /// </summary>
        /// <param name="word"> Referance variable of the string to remove a token from. </param>
        /// <param name="token"> The token that is to be removed from the word. </param>
        internal void removeToken(ref string word, int firstPos, int lastPos)
        {
            word = word.Remove(firstPos, 1);
            word = word.Remove(lastPos-1, 1);
        }

        internal void removeAnyMultiplierTokens(ref string word) 
        {
            string[] tokens = ["[", "]", "{", "}"];
            foreach (string token in tokens) 
            {
                removeToken(ref word, token);
            }
        }

        internal void interpretMultiplier(ref string word)
        {
            // If nothing to interpret return
            if (!((word.Contains("{") && word.Contains("}") || (word.Contains("[") && word.Contains("]")))))
            {
                return;
            }
            else // valid multiplier found!
            { // This part can probably be made more dynamic
                if (word.Contains("{") && word.Contains("}"))
                {
                    addMultiplier(ref word, "{", "}");

                } else if (word.Contains("[") && word.Contains("]")) 
                {
                    addMultiplier(ref word, "[", "]");
                }
                // Recursion to find any other instances of double/trippel.
                // TODO Make it handle both word and letter multipler at same time
                interpretMultiplier(ref word);
            }
        }

        internal void addMultiplier(ref string word, string delim1, string delim2) 
        {
            List<string> letterList;
            List<string> WordList;

            // Select appropriate multiplier
            if (delim1 == "{")
            {
                letterList = _doubleLetters;
                WordList = _doubleWords;
            }
            else if (delim1 == "[")
            {
                letterList = _tripleLetters;
                WordList = _tripleWords;
            }
            else 
            {
                throw new ArgumentException("Non valid deliminator");
            }

            // First attempt to do whole word, then single letters.
            int index1 = word.IndexOf(delim1);
            int index2 = word.LastIndexOf(delim2);
            int distance = index2 - index1;
            if (distance == 2)
            {
                removeToken(ref word, index1, index2);
                letterList.Add(word.Substring(index1, 1));
            }
            else if (distance == (word.Length - 1))
            {
                string cleanedWord = word;
                removeToken(ref word, index1, index2);
                removeAnyMultiplierTokens(ref cleanedWord);
                WordList.Add(cleanedWord);
            }
            else
            {
                throw new ArgumentException("Invalid letter/word multiplier");
            }
        }

        /// <summary>
        /// Populate the dictionary that is used to calculate points. 
        /// </summary>
        internal void populatePointsDict()
        {
            string[] value1 = ["a", "e", "i", "o", "u", "l", "n", "r", "s", "t"];
            foreach (string val in value1) { _points.Add(val, 1); }
            string[] value2 = ["d", "g"];
            foreach (string val in value2) { _points.Add(val, 2); }
            string[] value3 = ["b", "c", "m", "p"];
            foreach (string val in value3) { _points.Add(val, 3); }
            string[] value4 = ["f", "h", "v", "w", "y"];
            foreach (string val in value4) { _points.Add(val, 4); }
            string[] value5 = ["k"];
            foreach (string val in value5) { _points.Add(val, 5); }
            string[] value8 = ["j", "x"];
            foreach (string val in value8) { _points.Add(val, 8); }
            string[] value10 = ["q", "z"];
            foreach (string val in value10) { _points.Add(val, 10); }
        }

        /// <summary>
        /// Version 2 solution. Takes the word provided and calculates the score based on a shared bracket multipler and iteration
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Int of the calculated score</returns>
        internal void recursiveSwitchScoring(string word, ref int res, ref int multiplier, int i = 0)
        {
            char letter = word[i];
            switch (letter)
            {
                case '{':
                    multiplier *= 2;
                    break;
                case '}':
                    multiplier /= 2;
                    break;
                case '[':
                    multiplier *= 3;
                    break;
                case ']':
                    multiplier /= 3;
                    break;
                default:
                    res += _points.GetValueOrDefault<string, int>(letter.ToString(), 0) * multiplier;
                    break;
             }
            if (i < word.Length-1)
            {
                recursiveSwitchScoring(word, ref res, ref multiplier, i + 1);
            }
            return;
        }

        internal bool validateWord(string word) 
        {
            // If number of {/[ and }/] dont match, i.e. not closed brackets indicate invalid word by returning false.
            if (
                (word.Count(c => c == '{') != word.Count(c => c == '}')) ||
                (word.Count(c => c == '[') != word.Count(c => c == ']')))
            { 
                return false; 
            }

            // Check if the word contains any numbers, in which case it would be invalid and return false. 
            if ( word.Count(char.IsDigit) > 0 ) 
            {
                return false;
            }
            return true;
        }

        public int score()
        {
            //TODO: score calculation code goes here
            int res = 0;

            // Validate for only letter/brackets and all brackets enclosed.
            if (!validateWord(_word)) 
            {
                return res;
            }

            if (_word.Length == 0) 
            { return res; }

            if (_version == 1) // Original, Passed extended tests, but not the luca tests. 
            {
                for (int i = 0; i < _word.Length; i++)
                {
                    string theLetter = _word[i].ToString();
                    if (_doubleLetters.Contains(theLetter))
                    {
                        res += (_points.GetValueOrDefault(theLetter, 0) * 2);
                    }
                    else if (_tripleLetters.Contains(theLetter))
                    {
                        res += (_points.GetValueOrDefault(theLetter, 0) * 3);
                    }
                    else
                    {
                        res += _points.GetValueOrDefault(theLetter, 0);
                    }
                }
                // Multiply the entire result if double or triple word.
                if (_doubleWords.Contains(_word)) { res = res * 2; }
                if (_tripleWords.Contains(_word)) { res = res * 3; }

                return res;
            }
            else if (_version == 2) // New version
            { // Idea: Iterative switch, switch determine either value or increase/decrease a multiplier, then recursively progress until full word iterated through.
                int multiplier = 1;
                recursiveSwitchScoring(_word, ref res, ref multiplier);
                return res;
            } 
            else 
            {
                return res;
            }
        }
    }
}
