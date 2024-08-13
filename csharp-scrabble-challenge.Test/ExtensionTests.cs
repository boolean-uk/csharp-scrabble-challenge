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
        [TestCase("[{h}o1s{e}]", 0)] // error case (zero for errors)
        [TestCase("{h}ous{e}", 13)]
        [TestCase("[{h}ous{e}]", 39)]
        [TestCase("[h}ous{e}]", 0)] //Error case (zero for errors)
        public void ExtendedCriteriaTests(string word, int targetScore)
        {
            Assert.AreEqual(targetScore, this.GetWordScore(word));
        }

        private int GetWordScore(string word) => new Scrabble(word).score();
    }
}
