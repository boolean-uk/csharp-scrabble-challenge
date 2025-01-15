using System;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string word;
        private int scoreCounter;

        public Scrabble(string word)
        {
            this.word = word.ToUpper();
            this.scoreCounter = 0;
        }

        public int score()
        {
            scoreCounter = 0;

            // Check for double or triple word scores
            int wordMultiplier = 1;
            string inputWord = word;

            if (word.StartsWith("{") && word.EndsWith("}"))
            {
                wordMultiplier = 2;
                inputWord = word[1..^1]; // Remove curly braces
            }
            else if (word.StartsWith("[") && word.EndsWith("]"))
            {
                wordMultiplier = 3;
                inputWord = word[1..^1]; // Remove square brackets
            }

            // Process each letter
            for (int i = 0; i < inputWord.Length; i++)
            {
                char letter = inputWord[i];
                int letterMultiplier = 1;

                // Check for double/triple letter modifiers
                if (letter == '{' && i + 2 < inputWord.Length && inputWord[i + 2] == '}')
                {
                    letterMultiplier = 2;
                    letter = inputWord[i + 1]; // Extract the actual letter
                    i += 2; // Skip over the brackets
                }
                else if (letter == '[' && i + 2 < inputWord.Length && inputWord[i + 2] == ']')
                {
                    letterMultiplier = 3;
                    letter = inputWord[i + 1];
                    i += 2; 
                }

                // Calculate letter score
                switch (letter)
                {
                    case 'A':
                    case 'E':
                    case 'I':
                    case 'O':
                    case 'U':
                    case 'L':
                    case 'N':
                    case 'R':
                    case 'S':
                    case 'T':
                        scoreCounter += 1 * letterMultiplier;
                        break;
                    case 'D':
                    case 'G':
                        scoreCounter += 2 * letterMultiplier;
                        break;
                    case 'B':
                    case 'C':
                    case 'M':
                    case 'P':
                        scoreCounter += 3 * letterMultiplier;
                        break;
                    case 'F':
                    case 'H':
                    case 'V':
                    case 'W':
                    case 'Y':
                        scoreCounter += 4 * letterMultiplier;
                        break;
                    case 'K':
                        scoreCounter += 5 * letterMultiplier;
                        break;
                    case 'J':
                    case 'X':
                        scoreCounter += 8 * letterMultiplier;
                        break;
                    case 'Q':
                    case 'Z':
                        scoreCounter += 10 * letterMultiplier;
                        break;
                    default:
                        return 0;
                }
            }
            return scoreCounter * wordMultiplier;
        }
    }
}
