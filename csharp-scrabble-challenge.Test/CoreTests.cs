using csharp_scrabble_challenge.Main;
using NUnit.Framework;

namespace csharp_scrabble_challenge.Test
{
    [TestFixture]
    public class CoreTests
    {        
        [TestCase("", 0)]
        [TestCase(" ", 0)]
        [TestCase(" \t\n", 0)]
        [TestCase("\n\r\t\b\f", 0)]
        [TestCase("a", 1)]
        [TestCase("f", 4)]
        [TestCase("OXyPHEnBUTaZoNE", 41)]
        [TestCase("quirky", 22)]
        [TestCase("street", 6)]
        [TestCase("[{h}o1s{e}]", 0)] // error case (zero for errors)
        [TestCase("{h}ous{e}", 13)]
        [TestCase("[{h}ous{e}]", 39)]
        [TestCase("[h}ous{e}]", 0)] //Error case (zero for errors)
        [TestCase("{h}ous{e", 0)] // Error case (zero for errors)
        [TestCase("[[a]]", 9)] 
        public void WordScoreTests(string word, int targetScore)
        {
            Assert.AreEqual(this.GetWordScore(word), targetScore);
        }

        private int GetWordScore(string word) => new Scrabble(word).score();
    }
}