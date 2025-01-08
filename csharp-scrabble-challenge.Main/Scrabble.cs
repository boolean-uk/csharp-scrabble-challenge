namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private static readonly Dictionary<char, int> letterScores = new Dictionary<char, int>
        {
            { 'A', 1 },
            { 'E', 1 },
            { 'I', 1 },
            { 'O', 1 },
            { 'U', 1 },
            { 'L', 1 },
            { 'N', 1 },
            { 'R', 1 },
            { 'S', 1 },
            { 'T', 1 },
            { 'D', 2 },
            { 'G', 2 },
            { 'B', 3 },
            { 'C', 3 },
            { 'M', 3 },
            { 'P', 3 },
            { 'F', 4 },
            { 'H', 4 },
            { 'V', 4 },
            { 'W', 4 },
            { 'Y', 4 },
            { 'K', 5 },
            { 'J', 8 },
            { 'X', 8 },
            { 'Q', 10 },
            { 'Z', 10 }
        };

        private string word;

        public Scrabble(string word)
        {            
            this.word = word;
        }

        // Aiming for 0(n) complexity
        public int score()
        {
            int score = 0;
            var multiplier = 1;
            
            var letters = word.ToUpper().ToCharArray();

            foreach (char letter in letters)
            {
                var points = 0; // Letters not set in my dictionary will not give points.
                
                switch (letter)
                {
                    case '{':
                        multiplier = 2;
                        break;
                    case '[':
                        multiplier = 3;
                        break;
                    case '}':
                    case ']':
                        multiplier = 1;
                        break;
                }
                
                if (letterScores.TryGetValue(letter, out points))
                {
                    // Only adds points if the letter is in the dictionary
                    score += points * multiplier;
                }
            }

            return score;
        }
    }
}
