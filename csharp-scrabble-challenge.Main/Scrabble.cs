﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private Dictionary<char, int> _scoreMap;
        private Dictionary<string, int> _multiplierMap;
        private string _word;
        public Scrabble(string word)
        {
            this._scoreMap = new Dictionary<char, int>();
            this._scoreMap = initDict(this._scoreMap);
            this._multiplierMap = new Dictionary<string, int>();
            this._multiplierMap = initMultiplierMap(this._multiplierMap);
            this._word = word;
            //TODO: do something with the word variable


        }

        public int score()
        {
            //TODO: score calculation code goes here
            int scoreVal = 0;
            int scoreMultiplier = 1;
            char[] wordCharArr = this._word.ToCharArray();
            for (int i = 0; i < wordCharArr.Length; i++)
            {
                if (wordCharArr[i] == '[')
                {
                    scoreMultiplier = 3;
                }
                if (wordCharArr[i] == '{')
                {
                    scoreMultiplier = 2;
                }
                if (wordCharArr[i] == '}')
                {
                    scoreMultiplier = 1;
                }
                if (wordCharArr[i] == ']')
                {
                    scoreMultiplier = 1;
                }
                if (this._scoreMap.ContainsKey(Char.ToUpper(wordCharArr[i])))
                {
                    scoreVal += this._scoreMap[Char.ToUpper(wordCharArr[i])] * scoreMultiplier;
                }
            }

            return scoreVal;
        }


        private Dictionary<string, int> initMultiplierMap(Dictionary<string, int> dict)
        {
            dict.Add("[", 2);
            dict.Add("]", 2);
            dict.Add("{", 3);
            dict.Add("}", 3);
            return dict;
        }
        private Dictionary<char, int> initDict(Dictionary<char, int> dict)
        {
            dict.Add('A', 1);
            dict.Add('E', 1);
            dict.Add('I', 1);
            dict.Add('O', 1);
            dict.Add('U', 1);
            dict.Add('L', 1);
            dict.Add('N', 1);
            dict.Add('R', 1);
            dict.Add('S', 1);
            dict.Add('T', 1);
            dict.Add('D', 2);
            dict.Add('G', 2);
            dict.Add('B', 3);
            dict.Add('C', 3);
            dict.Add('M', 3);
            dict.Add('P', 3);
            dict.Add('F', 4);
            dict.Add('H', 4);
            dict.Add('V', 4);
            dict.Add('W', 4);
            dict.Add('Y', 4);
            dict.Add('K', 5);
            dict.Add('J', 8);
            dict.Add('X', 8);
            dict.Add('Q', 10);
            dict.Add('Z', 10);


            return dict;
        }
    }
}