namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private readonly string _word;
        private readonly bool _doubleWord;
        private readonly bool _tripleWord;

        private static readonly Dictionary<char , int> LetterValues = new Dictionary<char , int>
        {
        {'A', 1}, {'E', 1}, {'I', 1}, {'O', 1}, {'U', 1}, {'L', 1}, {'N', 1}, {'R', 1}, {'S', 1}, {'T', 1},
        {'D', 2}, {'G', 2},
        {'B', 3}, {'C', 3}, {'M', 3}, {'P', 3},
        {'F', 4}, {'H', 4}, {'V', 4}, {'W', 4}, {'Y', 4},
        {'K', 5},
        {'J', 8}, {'X', 8},
        {'Q', 10}, {'Z', 10}
        };

        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            _word = word.ToUpper();
            _doubleWord = _word.StartsWith('{') && _word.EndsWith('}');
            _tripleWord = _word.StartsWith('[') && _word.EndsWith(']');
            _word = _word.TrimStart('{' , '[').TrimEnd('}' , ']');
        }

        public int score()
        {
            //TODO: score calculation code goes here
            try
            {
                int score = 0;
                foreach(char letter in _word)
                {
                    if(LetterValues.ContainsKey(letter))
                    {
                        int letterScore = LetterValues[letter];
                        if(_word.Contains("{" + letter + "}"))
                        {
                            letterScore *= 2;
                        }
                        else if(_word.Contains("[" + letter + "]"))
                        {
                            letterScore *= 3;
                        }
                        score += letterScore;
                    }
                    else if(char.IsDigit(letter))
                    {
                        throw new ArgumentException("Invalid character in word: numbers are not allowed.");
                    }
                }
                if(_doubleWord)
                {
                    score *= 2;
                }
                else if(_tripleWord)
                {
                    score *= 3;
                }
                return score;
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return 0;
            }
        }
    }
}
