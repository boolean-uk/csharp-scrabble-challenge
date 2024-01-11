using csharp_scrabble_challenge.Main;
using NUnit.Framework;

namespace csharp_scrabble_challenge.Test
{
    [TestFixture]
    public class CoreTests
    {
        private WordList _wordList;

        [SetUp]
        public void Setup()
        {
            string relativePathToWordList = "Data/SOWPODS.txt";
            _wordList = new WordList(relativePathToWordList);

        }

        [TestCase("", 0)]
        [TestCase(" ", 0)]
        [TestCase(" \t\n", 0)]
        [TestCase("\n\r\t\b\f", 0)]
        [TestCase("a", 0)]
        [TestCase("f", 0)]
        [TestCase("quirky", 22)]
        [TestCase("street", 6)]
        public void WordScoreTests(string word, int targetScore)
        {
            Assert.AreEqual(this.GetWordScore(word), targetScore);
        }

        private int GetWordScore(string word) => new Scrabble(word, _wordList).score();
    }
}