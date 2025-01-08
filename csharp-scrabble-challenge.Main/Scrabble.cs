using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        Dictionary<string, int> points = new Dictionary<string, int>();
        List<string> zeroPoint = new List<string> { "{", "}", "[", "]"};
        List<string> onePoint = new List<string> { "A", "E", "I", "O", "U", "L", "N", "R", "S", "T" };
        List<string> twoPoint = new List<string> { "D", "G" };
        List<string> threePoint = new List<string> { "B", "C", "M", "P" };
        List<string> fourPoint = new List<string> { "F", "H", "V", "W", "Y" };
        List<string> fivePoint = new List<string> { "K" };
        List<string> eightPoint = new List<string> {"J", "X"};
        List<string> tenPoint = new List<string> { "Q", "Z" };
        public string Word { get; set; }
        public void makeDictionary() { 
            zeroPoint.ForEach(x => points[x] = 0);
            onePoint.ForEach(x => points[x] = 1);
            twoPoint.ForEach(x => points[x] = 2);
            threePoint.ForEach(x => points[x] = 3);
            fourPoint.ForEach(x => points[x] = 4);
            fivePoint.ForEach(x => points[x] = 5);
            eightPoint.ForEach(x => points[x] = 8);
            tenPoint.ForEach(x => points[x] = 10);
        }
        public Scrabble(string word) {
            makeDictionary();

            Word = word.ToUpper();
        
        }
        //TODO: do something with the word variable



        public int score()
        {
            Stack<string> stack = new Stack<string>();

            char[] array = Word.ToCharArray();
            int result = 0;

            for (int i = 0; i < array.Length; i++) {
                if (!points.ContainsKey(array[i].ToString())) 
                {
                    continue;
                }
                if (array[i] == '{') {
                    while (array[i] != '}' && i < array.Length) {
                        if (!points.ContainsKey(array[i].ToString())) { continue; }
                        result += points[array[i++].ToString()]*2;
                    }
                }
                if (array[i] == '[')
                {
                    while (array[i] != ']' && i< array.Length)
                    {
                        if (!points.ContainsKey(array[i].ToString())) { continue; }
                        result += points[array[i++].ToString()]*3;
                    }
                }
                else if (array[i] != '}' || array[i] != ']')
                {
                    result += points[array[i].ToString()];
                }
            }

            //TODO: Remove this line when the code has been written
            return result;
        }
    }
}
