using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class WordList
    {
        private HashSet<string> _validWordsCheck = new HashSet<string>();

        public WordList() { }

        public async Task InitializeAsync(HttpClient httpClient)
        {
            var wordFileContent = await httpClient.GetStringAsync("Data/SOWPODS.txt");
            _validWordsCheck = new HashSet<string>(wordFileContent.Split('\n').Select(word => word.Trim().ToUpper()));
        }

        public bool IsItAValidWord(string word)
        {
            return _validWordsCheck.Contains(word);
        }
    }
}