using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {

        /*
        // Sorted word points, easy to add more (Core)
        private char[] p1Words = {'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T'};
        private char[] p2Words = {'D', 'G'};
        private char[] p3Words = {'B', 'C', 'M', 'P'};
        private char[] p4Words = {'F', 'H', 'V', 'W', 'Y'};
        private char[] p5Words = {'K'};
        private char[] p8Words = {'J', 'X'};
        private char[] p10Words = {'Q','Z'};
    */
        //? Better solution?? (Extension) and now core
        private Dictionary<char, int> char_scores = new Dictionary<char, int> {
            {'A',1}, {'E',1}, {'I',1}, {'O',1}, {'U',1}, {'L',1}, {'N',1}, {'R',1}, {'S',1}, {'T',1}, //!One point
            {'D',2}, {'G',2}, //!Two point
            {'B',3},{'C',3},{'M',3}, {'P',3}, //!Three points
            {'F',4}, {'H',4}, {'V',4}, {'W',4}, {'Y',4}, //!Four points
            {'K',5}, //!Five points
            {'J', 8}, {'X',8}, //!Eight points
            {'Q',10}, {'Z',10} //!Ten points
            };

        // Global word score
        private int _score = 0;


        public Scrabble(string word)
        {    
            char[] input = word.ToUpper().ToCharArray();
            calulateScore(input);
        }

        public int score()
        {
            return _score;
        }
        
        public void calulateScore(char[] arr) {
            int i = 0; // initiate
            while (i < arr.Length) {
                switch (arr[i]) {
                    case '{':
                        i++;
                        while (arr[i] != '}') {
                            if (char_scores.TryGetValue(arr[i], out int valueTimes2)) {
                                _score += valueTimes2*2;
                            }
                            i++;
                        }
                        break;
                    case '[':
                        i++;
                        while (arr[i] != ']') {
                            if (char_scores.TryGetValue(arr[i], out int valueTimes3)) {
                                _score += valueTimes3*3;
                            }
                            i++;
                        }
                        break;
                    default:
                        if (char_scores.TryGetValue(arr[i], out int defaultValue)) {
                            _score += defaultValue;
                        }
                        break;
                }
                i++;
            }

            
        }

/*
        public void calulateScoreCore(char[] arr) {
            foreach (char ch in arr) {
                if (p1Words.Contains(ch)) {
                    _score += 1;
                } else if (p2Words.Contains(ch)) {
                    _score += 2;
                } else if (p3Words.Contains(ch)) {
                    _score += 3;
                } else if (p4Words.Contains(ch)) {
                    _score += 4;
                } else if (p5Words.Contains(ch)) {
                    _score += 5;
                } else if (p8Words.Contains(ch)) {
                    _score += 8;
                } else if (p10Words.Contains(ch)) {
                    _score += 10;
                }
            }
        }*/       
    }
}
