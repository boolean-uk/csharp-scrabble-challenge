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
    // https://stackoverflow.com/questions/29786674/how-to-use-setup-method-to-arrange-for-a-unit-test-how-about-parameters used this for some guidance
    {
        private WordList _wordList;

        [SetUp]
        public void Setup()
        {
            string relativePathToWordList = "Data/SOWPODS.txt";
            _wordList = new WordList(relativePathToWordList);

        }

        [TestCase("{street}", 12)] //extension double word
        [TestCase("[street]", 18)] //extension triple word
        [TestCase("{quirky}", 44)] //extension double word
        [TestCase("[quirky]", 66)] //extension triple word
        [TestCase("{OXyP}", 0)]

        public void ExtendedCriteriaTests(string word, int targetScore)
        {
            Assert.AreEqual(this.GetWordScore(word), targetScore);
        }

        private int GetWordScore(string word) => new Scrabble(word, _wordList).score();
    }
}
