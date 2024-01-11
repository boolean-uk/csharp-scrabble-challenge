namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string _word;
        private Dictionary<char, int> map;
        public Scrabble(string word)
        {            
            //TODO: do something with the word variable
            _word = word.Trim().ToUpper();
            map = new Dictionary<char, int>
            {
                { 'A', 1 }, { 'E', 1 }, { 'I', 1 }, { 'O', 1 }, { 'U', 1 }, { 'L', 1 }, { 'N', 1 }, { 'R', 1 }, { 'S', 1 }, { 'T', 1 },
                { 'D', 2 }, { 'G', 2 },
                { 'B', 3 }, { 'C', 3 }, { 'M', 3 }, { 'P', 3 },
                { 'F', 4 }, { 'H', 4 }, { 'V', 4 }, { 'W', 4 }, { 'Y', 4 },
                { 'K', 5 },
                { 'J', 8 }, { 'X', 8 },
                { 'Q', 10 }, { 'Z', 10 }
            };
        }

        public int score()
        {
            //TODO: score calculation code goes here
            int score = 0;
            int scoreMultiplier = 1;
            for (int i = 0; i < _word.Length; i++)
            {
                switch (_word[i])
                {
                    case '{':
                        scoreMultiplier = 2;
                        i++;
                        break;
                    case '[':
                        scoreMultiplier = 3;
                        i++;
                        break;
                    case '}':
                        scoreMultiplier = 1;
                        i++;
                        break;
                    case ']':
                        scoreMultiplier = 2;
                        i++;
                        break;
                    default:
                        break;
                }
                if (i >= _word.Length) continue;
                score += map.GetValueOrDefault(_word[i]) * scoreMultiplier;
            }
            return score;
        }
    }
}
