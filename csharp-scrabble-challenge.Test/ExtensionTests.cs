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
       [TestCase("d{o}g", 6)] //extension double letter
        [TestCase("d[o]g", 7)] //extension triple letter
        [TestCase("[d[1]g]", 0)]
        [TestCase("[[zz]z]", 210)]

        [TestCase("j[o]h{n}", 17)] // "j[o]h{n}": o blir trippel, n blir dobbel
        [TestCase("k[e]y", 12)] // "k[e]y": e blir trippel
        [TestCase("{x}yz", 30)] // "{x}yz": x blir dobbel
        [TestCase("k[e][y]", 20)] // "k[e]y": e blir trippel
        [TestCase("{x}[y]z", 38)] // "{x}yz": x blir dobbel

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
            Assert.AreEqual(this.GetWordScore(word), targetScore);
        }

        private int GetWordScore(string word) => new Scrabble(word).score();
    }
}
