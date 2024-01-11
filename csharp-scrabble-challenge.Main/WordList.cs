using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //for class to interact with the wordlist file

namespace csharp_scrabble_challenge.Main
{
    //https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1?view=net-7.0
    public class WordList
    {
        private HashSet<string> _validWordsCheck = new HashSet<string>();

        public WordList(string path)
        {
            LoadAllWords(path);
        }

        private void LoadAllWords(string path)
        {
            _validWordsCheck = new HashSet<string>(File.ReadAllLines(path).Select(word => word.Trim().ToUpper()));
        }

        public bool IsItAValidWord (string word)
        {
            return _validWordsCheck.Contains(word);
        }
    }
}
