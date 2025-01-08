
namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {

        public static Dictionary<char, int> letterValues = new Dictionary<char, int>();

        public static List<char> validChars = new List<char>();

        public static void populateLetterValues()
        {
            letterValues.Add('A', 1);
            letterValues.Add('E', 1);
            letterValues.Add('I', 1);
            letterValues.Add('O', 1);
            letterValues.Add('U', 1);
            letterValues.Add('L', 1);
            letterValues.Add('N', 1);
            letterValues.Add('R', 1);
            letterValues.Add('S', 1);
            letterValues.Add('T', 1);
            letterValues.Add('D', 2);
            letterValues.Add('G', 2);
            letterValues.Add('B', 3);
            letterValues.Add('C', 3);
            letterValues.Add('M', 3);
            letterValues.Add('P', 3);
            letterValues.Add('F', 4);
            letterValues.Add('H', 4);
            letterValues.Add('V', 4);
            letterValues.Add('W', 4);
            letterValues.Add('Y', 4);
            letterValues.Add('K', 5);
            letterValues.Add('J', 8);
            letterValues.Add('X', 8);
            letterValues.Add('Q', 10);
            letterValues.Add('Z', 10);
        }

        public static void populateValidChars()
        {
            validChars.Add('A');
            validChars.Add('E');
            validChars.Add('I');
            validChars.Add('O');
            validChars.Add('U');
            validChars.Add('L');
            validChars.Add('N');
            validChars.Add('R');
            validChars.Add('S');
            validChars.Add('T');
            validChars.Add('D');
            validChars.Add('G');
            validChars.Add('B');
            validChars.Add('C');
            validChars.Add('M');
            validChars.Add('P');
            validChars.Add('F');
            validChars.Add('H');
            validChars.Add('V');
            validChars.Add('W');
            validChars.Add('Y');
            validChars.Add('K');
            validChars.Add('J');
            validChars.Add('X');
            validChars.Add('Q');
            validChars.Add('Z');
            validChars.Add('{');
            validChars.Add('}');
            validChars.Add('[');
            validChars.Add(']');
        }

        public static int countChars(string word, char letter)
        {
            int count = 0;

            foreach (var c in word)
            {
                if (c == letter)
                    count++;
            }

            return count;
        }

        public static List<int> getIndexes(string word, char letter)
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == letter)
                {
                    indexes.Add(i);
                }
            }

            return indexes;
        }

        public static (bool, List<char>)  onlyContainsValidChars(string word)
        {
            List<char> wordList = word.ToList();
            List<char> invalidChars = new List<char>();

            foreach (char c in wordList)
            {
                if (!validChars.Contains(c))
                {
                    invalidChars.Add(c);
                }
            }

            if (invalidChars.Count > 0)
            {
                return (false, invalidChars.Distinct().ToList());
            }
            else
            {
                return (true, invalidChars.Distinct().ToList());
            }
        }

        public static bool validFormatting(string word)
        {
            List<char> wordList = word.ToList();
            
            if (wordList.Count == 0) return false;

            if (wordList.Contains('{') && !wordList.Contains('}')) { return false; }
            if (!wordList.Contains('{') && wordList.Contains('}')) { return false; }
            if (wordList.Contains('[') && !wordList.Contains(']')) { return false; }
            if (!wordList.Contains('[') && wordList.Contains(']')) { return false; }

            int nd1 = countChars(word, '{');
            int nd2 = countChars(word, '}');
            int nt1 = countChars(word, '[');
            int nt2 = countChars(word, ']');

            if (nd1 != nd2 || nt1 != nt2) { return false; }

            bool checkDoubleFormat = false;
            bool checkTripleFormat = false;

            if (wordList.Contains('{') && wordList.Contains('}')) { checkDoubleFormat = true; }
            if (wordList.Contains('[') && wordList.Contains(']')) { checkTripleFormat = true; }

            if (checkDoubleFormat)
            {
                List<int> id1 = getIndexes(word, '{');
                List<int> id2 = getIndexes(word, '}');

                for (int i = 0; i < id1.Count; i++)
                {
                    if (id1[i] >= id2[i]) { return false; }
                }
            }

            if (checkTripleFormat)
            {
                List<int> it1 = getIndexes(word, '[');
                List<int> it2 = getIndexes(word, ']');

                for (int i = 0; i < it1.Count; i++)
                {
                    if (it1[i] >= it2[i]) { return false; }
                }

            }

            for (int i = 0; i < wordList.Count; i++)
            {
                if ((wordList[i] == '{' && wordList[i + 2] != '}') && (wordList[i] == '{' && wordList[wordList.Count - 1] != '}')) { return false; }
                if ((wordList[i] == '[' && wordList[i + 2] != ']') && (wordList[i] == '[' && wordList[wordList.Count - 1] != ']')) { return false; }
            }

            return true;
        }

        private string word = "";

        public Scrabble(string word = "")
        {
            if (letterValues.Count <= 0)
            {
                populateLetterValues();
            }

            if (validChars.Count <= 0)
            {
                populateValidChars();
            }

            word = word.ToUpper().Trim();

            (bool onlyValidChars, List<char> invalidChars) = onlyContainsValidChars(word);
            bool isEmpty = (word == "");
            bool hasValidFormatting = validFormatting(word);

            if (!onlyValidChars)
            {
                string invalidCharsString = string.Join(",", invalidChars);
                Console.WriteLine($"Invalid characters in input! Do not use: '" + invalidCharsString + "'. Please try again...");
                this.word = "";
            }
            else if (isEmpty)
            {
                Console.WriteLine("Input cannot be empty! Please try again...");
                this.word = "";
            }
            else if (!hasValidFormatting)
            {
                Console.WriteLine("Input har invalid formatting! Please try again...");
                this.word = "";
            }
            else
            {
                this.word = word;
            }
        }

        public int score()
        {
            
            int score = 0;

            bool doubleWordPoints = false;
            bool trippleWordPoints = false;

            try
            {
                if (word[0] == '{' && word[word.Length - 1] == '}' && word.Length > 3) { doubleWordPoints = true; }
                if (word[0] == '[' && word[word.Length - 1] == ']' && word.Length > 3) { trippleWordPoints = true; }
            }
            catch
            {

            }

            bool doubleLetterPoints = false;
            bool trippleLetterPoints = false;

            for (int i = 0; i < word.Length; i++)
            {
                char letter = word[i];
                if (!letterValues.ContainsKey(letter)) { continue; }
                int letterValue = letterValues[letter];
                try
                {
                    if (word[i - 1] == '{' && word[i + 1] == '}')
                    {
                        doubleLetterPoints = true;
                    }
                    else if (word[i - 1] == '[' && word[i + 1] == ']')
                    {
                        trippleLetterPoints = true;
                    }

                    if (doubleLetterPoints)
                    {
                        letterValue = letterValue * 2;
                    }
                    else if (trippleLetterPoints)
                    {
                        letterValue = letterValue * 3;
                    }
                }
                catch
                {

                }

                score += letterValue;
            }

            if (doubleWordPoints)
            {
                score = score * 2;
            }
            if (trippleWordPoints)
            {
                score = score * 3;
            }

            return score;
        }
    }
}
