namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {

        private Dictionary<char, int> letterValues = new Dictionary<char, int>()
            {
                {'A', 1 }, {'E', 1 }, {'I', 1 }, {'O', 1 }, {'U', 1 },
                {'L', 1 }, {'N', 1 }, {'R', 1 }, {'S', 1 }, {'T', 1 },
                {'D', 2 }, {'G', 2 },
                {'B', 3 }, {'C', 3 }, {'M', 3 }, {'P', 3 },
                {'F', 4 }, {'H', 4 }, {'V', 4 }, {'W', 4 }, {'Y', 4 },
                {'K', 5 },
                {'J', 8 }, {'X', 8 },
                {'Q', 10 }, {'Z', 10 }
            };

        private string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ{}[]";

        private string word;

        public Scrabble(string word)
        {
            this.word = word.ToUpper();
        }

        public int score()
        {
            if (HasInvalidBrackets() || HasInvalidCharacters())
            {
                return 0;
            }

            int score = 0;

            bool isDoubleWord = DoubleWordScore();
            bool isTripleWord = TripleWordScore();

            var doubleLetterScores = DoubleLetterScore();
            var tripleLetterScores = TripleLetterScore();

            // Calculate the base score and track double and triple letter scores
            foreach (char letter in word)
            {
                if (letterValues.ContainsKey(letter))
                {
                    score += letterValues[letter];

                    // Check if the letter is in double or triple letter scores
                    if (doubleLetterScores != null && doubleLetterScores.Contains(letter.ToString()))
                    {
                        score += letterValues[letter];
                    }

                    if (tripleLetterScores != null && tripleLetterScores.Contains(letter.ToString()))
                    {
                        score += letterValues[letter] *2;
                    }
                }
            }

            // Apply word score multipliers
            if (isDoubleWord)
                score *= 2;

            if (isTripleWord)
                score *= 3;

            return score;
        }

        private bool DoubleWordScore()
        {
            return word.StartsWith("{") && word.EndsWith("}") && word.Length > 2 && word[2] != '}';
        }

        private bool TripleWordScore()
        {
            return word.StartsWith("[") && word.EndsWith("]") && word.Length > 2 && word[2] != ']';
        }

        public List<string>? DoubleLetterScore() => GetLetterScores('{', '}');
        public List<string>? TripleLetterScore() => GetLetterScores('[', ']');

        // Check for equal amount of opening and closing brackets
        private bool HasInvalidBrackets()
        {
            bool isInvalid = false;

            if (word.Count(c => c == '{') != word.Count(c => c == '}'))
                isInvalid = true;

            if (word.Count(c => c == '[') != word.Count(c => c == ']'))
                isInvalid = true;

            return isInvalid;
        }

        private bool HasInvalidCharacters()
        {
            return word.Any(c => !validChars.Contains(c));
        }

        public List<string>? GetLetterScores(char openBracket, char closeBracket)
        {
            var letterScores = new List<string>();
            int index = 0;
            int openIndex = 0;

            if (DoubleWordScore() || TripleWordScore())
            {
                // Skip the word score bracket
                index++;
            }

            while (index < word.Length)
            {
                char currentChar = word[index];

                if (currentChar == openBracket)
                {
                    openIndex = index;
                }
                else if (currentChar == closeBracket)
                {
                 
                    // Extract the letter between the brackets
                    string letter = word.Substring(openIndex + 1, index - openIndex - 1);
                    letterScores.Add(letter);
                }

                index++;
            }

            return letterScores;
        }
    }
}
