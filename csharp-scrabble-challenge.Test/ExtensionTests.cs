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

        [TestCase("qu{i}rky", 23)] // Double letter
        [TestCase("qu[i]rky", 24)] // Triple letter
        [TestCase("{qu[i]rky}", 48)] // Triple letter and double word
        [TestCase("[quir[k]y]",96)] // Triple letter and triple word
        public void MyOwnExtendedCriteriaTests(string word, int targetScore)
        {
            Assert.AreEqual(targetScore, this.GetWordScore(word));
        }

        private int GetWordScore(string word) => new Scrabble(word).score();
    }
}
