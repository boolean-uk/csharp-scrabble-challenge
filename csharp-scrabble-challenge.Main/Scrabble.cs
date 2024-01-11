﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private Dictionary<string, int> _letterValue;
        private string _word;
        public Scrabble(string Word)
        {
            //TODO: do something with the word variable
            _word = Word;
            _letterValue = new Dictionary<string, int>();
            _letterValue.Add("A", 1);
            _letterValue.Add("B", 3);
            _letterValue.Add("C", 3);
            _letterValue.Add("D", 2);
            _letterValue.Add("E", 1);
            _letterValue.Add("F", 4);
            _letterValue.Add("G", 2);
            _letterValue.Add("H", 4);
            _letterValue.Add("I", 1);
            _letterValue.Add("J", 8);
            _letterValue.Add("K", 5);
            _letterValue.Add("L", 1);
            _letterValue.Add("M", 3);
            _letterValue.Add("N", 1);
            _letterValue.Add("O", 1);
            _letterValue.Add("P", 3);
            _letterValue.Add("Q", 10);
            _letterValue.Add("R", 1);
            _letterValue.Add("S", 1);
            _letterValue.Add("T", 1);
            _letterValue.Add("U", 1);
            _letterValue.Add("v", 4);
            _letterValue.Add("W", 4);
            _letterValue.Add("X", 8);
            _letterValue.Add("Y", 4);
            _letterValue.Add("Z", 10);

            
            
        }

        public int score()
        {
            //TODO: score calculation code goes here
            int score = 0;
            for (int i = 0; i < _word.Length; i++)
            {
                string letter = _word[i].ToString().ToUpper();
                foreach(var item in _letterValue)
                {
                    if (letter.Equals(item.Key))
                    {
                        
                        score += item.Value;
                        
                    }
                    
                }
            }
            return score;


        }

        //public Dictionary<string, int> createScores()
        //{
        //    _letterValue = new Dictionary<string, int>();
        //    _letterValue.Add("A",1);
        //    _letterValue.Add("B",3);
        //    _letterValue.Add("C",3);
        //    _letterValue.Add("D",2);
        //    _letterValue.Add("E",1);
        //    _letterValue.Add("F",4);
        //    _letterValue.Add("G",2);
        //    _letterValue.Add("H",4);
        //    _letterValue.Add("I",1);
        //    _letterValue.Add("J",8);
        //    _letterValue.Add("K",5);
        //    _letterValue.Add("L",1);
        //    _letterValue.Add("M",3);
        //    _letterValue.Add("N",1);
        //    _letterValue.Add("O",1);
        //    _letterValue.Add("P",3);
        //    _letterValue.Add("Q",10);
        //    _letterValue.Add("R",1);
        //    _letterValue.Add("S",1);
        //    _letterValue.Add("T",1);
        //    _letterValue.Add("U",1);
        //    _letterValue.Add("v",4);
        //    _letterValue.Add("W",4);
        //    _letterValue.Add("X",8);
        //    _letterValue.Add("Y",4);
        //    _letterValue.Add("Z",10);

        //    return _letterValue;
        //}

        public Dictionary<string, int> letterValues { get { return _letterValue; } }
        public string word {  get { return _word; } }
    }
}
