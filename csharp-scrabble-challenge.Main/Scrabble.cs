namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private static Dictionary<char, int> _letterPoints = new()
        {
            {'A', 1 }, {'E', 1 }, {'I', 1 }, {'O', 1 }, {'U', 1 }, {'L', 1 }, {'N', 1}, {'R', 1}, {'S', 1}, {'T', 1},
            {'D', 2 }, {'G', 2},
            {'B', 3 }, {'C',  3 }, {'M', 3}, {'P', 3},
            { 'F', 4 }, { 'H', 4 }, { 'V', 4 }, { 'W', 4 }, { 'Y', 4 },
            {'K', 5 },
            {'J', 8 }, {'X', 8 },
            {'Q', 10 }, {'Z', 10 }
        };

        private string _word;

        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            _word = word.ToUpper();
        }

        public int score()
        {
            int multiplier = 1;
            int result = 0;
            //TODO: score calculation code goes here
            foreach (char c in _word)
            {
                switch (c)
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
                        if (_letterPoints.ContainsKey(c))
                        {
                            result += _letterPoints[c] * multiplier;
                        }
                        break;
                }
            }
            return result;
        }
    }
}
