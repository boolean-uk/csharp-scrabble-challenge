﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private readonly char[] chars;

        public Scrabble(string word)
        {            
            //TODO: do something with the word variable

            if (word == null) throw new ArgumentNullException("No word!");

            // create a list of char of the word
            chars = word.ToUpper().ToCharArray();

            Console.WriteLine(word);
        }

        public int score()
        {
            //TODO: score calculation code goes here

            // Calculate value of each letter in a dictionary
            Dictionary<char, int> points = new Dictionary<char, int>();
            points.Add('A', 1);
            points.Add('E', 1);
            points.Add('I', 1);
            points.Add('O', 1);
            points.Add('U', 1);
            points.Add('L', 1);
            points.Add('N', 1);
            points.Add('R', 1);
            points.Add('S', 1);
            points.Add('T', 1);
            
            points.Add('D', 2);
            points.Add('G', 2);

            points.Add('B', 3);
            points.Add('C', 3);
            points.Add('M', 3);
            points.Add('P', 3);

            points.Add('F', 4);
            points.Add('H', 4);
            points.Add('V', 4);
            points.Add('W', 4);
            points.Add('Y', 4);

            points.Add('K', 5);

            points.Add('J', 8);
            points.Add('X', 8);

            points.Add('Q', 10);
            points.Add('Z', 10);

            if (chars.Length == 0)
            {
                return 0;
            }

            int score = 0;
            int pos = 0;

            
            foreach (var letter in chars)
            {
               if (points.ContainsKey(letter)) {
                {
                    int val = points[letter];

                        if (pos > 0 && pos < chars.Length-1)
                        {
                            
                            if ((chars[pos - 1] == '{') && (chars[pos + 1] == '}'))
                            {
                                score += (val * 2);
                              

                            }
                            else if ((chars[pos - 1] == '[') && (chars[pos + 1] == ']'))
                            {
                                score += (val * 3);
                                
                            } else
                            {
                                score += val;
                            }
                        }
                        else
                        {
                            score += val;
                        }
                    }
                }
                pos++;
            }
           
            if (chars.First() == '{' && chars.Last() == '}')
            {
                score *= 2;
            }
            if (chars.First() == '[' && chars.Last() == ']')
            {
                score *= 3;
            }
               

            return score;
        }
    }
}
