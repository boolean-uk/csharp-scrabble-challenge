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
        /*                        | Letter | Value |
                       | ----                          | ----  |
                       | A, E, I, O, U, L, N, R, S, T | 1 |
                       | D, G | 2 |
                       | B, C, M, P | 3 |
                       | F, H, V, W, Y | 4 |
                       | K | 5 |
                       | J, X | 8 |
                       | Q, Z | 10 |*/
        [TestCase("{street}", 12)] //extension double word
        [TestCase("[street]", 18)] //extension triple word
        [TestCase("{quirky}", 44)] //extension double word
        [TestCase("[quirky]", 66)] //extension triple word
        [TestCase("{OXyPHEnBUTaZoNE}", 82)]
        [TestCase("[OXyPHEnBUTaZoNE]", 123)]
        [TestCase("stre[e]t", 8)]
        [TestCase("{stre[e]t}", 16)]
        [TestCase("{d[o]g}", (2+1*3+2)*2) ]
        public void ExtendedCriteriaTests(string word, int targetScore)
        {
            Assert.AreEqual(this.GetWordScore(word), targetScore);
        }

        private int GetWordScore(string word) => new Scrabble(word).score();
    }
}
