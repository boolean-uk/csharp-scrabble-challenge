using csharp_scrabble_challenge.Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        private WordList _wordList;

        public void Setup()
        {
            string relativePathToWordList = "./SOWPODS.txt";
            _wordList = new WordList(relativePathToWordList);

        }

        [TestCase("{street}", 12)] //extension double word
        [TestCase("[street]", 18)] //extension triple word
        [TestCase("{quirky}", 44)] //extension double word
        [TestCase("[quirky]", 66)] //extension triple word
        [TestCase("{OXyPHEnBUTaZoNE}", 82)]
        [TestCase("[OXyPHEnBUTaZoNE]", 123)]
        public void ExtendedCriteriaTests(string word, int targetScore)
        {
            Assert.AreEqual(this.GetWordScore(word), targetScore);
        }

        private int GetWordScore(string word) => new Scrabble(word, _wordList).score();
    }
}
