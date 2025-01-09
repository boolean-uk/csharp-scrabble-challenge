using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        string _word { get; set; }
        Dictionary<List<char>, int> _letterScore { get; set; }
        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            _word = word;

            List<char> group1 = new List<char>
            {
                'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T',
            };

            List<char> group2 = new List<char>
            {
                'D', 'G'
            };

            List<char> group3 = new List<char>
            {
                'B', 'C', 'M', 'P'
            };

            List<char> group4 = new List<char>
            {
                'F', 'H', 'V', 'W', 'Y'
            };

            List<char> group5 = new List<char>
            {
                'K'
            };

            List<char> group6 = new List<char>
            {
                'J', 'X'
            };

            List<char> group7 = new List<char>
            {
                'Q', 'Z'
            };


            _letterScore = new Dictionary<List<char>, int>
            {
                {group1, 1}, {group2, 2 }, {group3, 3 }, {group4, 4}, {group5, 5 }, {group6, 8 }, {group7, 10}
            };
        }
        public int score()
        {
            Tuple<int, string> word_evaluation = Evaluate(_word, "", "", 0); //Returns a tuple of (score, rest)
            if (word_evaluation.Item2.Length > 0)
            {
                // Only legal rest is a score-double of a word: "{}"
                if (word_evaluation.Item2 == "{}")
                {
                        return word_evaluation.Item1 * 2;
                }
                else if (word_evaluation.Item2 == "[]")
                {
                    return word_evaluation.Item1 * 3;
                }

                return 0;
            }

            return word_evaluation.Item1;
            
        }

        // Splits the string into parts that can be scored individually
        public Tuple<int, string> Evaluate(string to_evaluate, string currently_evaluating, string rest, int currentScore)
        {
            Console.WriteLine(currentScore);
            if (to_evaluate.Length == 0)
            {
                return new Tuple<int, string>(currentScore, rest);
            }
            char next_char = to_evaluate[0];
            List<char> starter_brackets = new List<char>
            {
                '{', '['
            };
            List<char> end_brackets = new List<char>
            {
                '}', ']'
            };

            //init calculation variable
            Tuple<int, string> calculation = Tuple.Create(0, "");


            if (!char.IsLetter(next_char))
            {
                //New part to evaluate
                if (starter_brackets.Contains(next_char))
                {
                    // We start at a new evaluation part without completing the last
                    if (currently_evaluating.Length > 0)
                    {
                        rest += currently_evaluating;
                        currently_evaluating = "";
                    }
                    return Evaluate(to_evaluate.Substring(1), currently_evaluating + next_char, rest, currentScore);
                }

                //Currently_evaluating part is ready for score calculation
                else if (end_brackets.Contains(next_char))
                {
                    if (currently_evaluating.Length > 0)
                    {
                        currently_evaluating += next_char;
                        calculation = Calculate_score(currently_evaluating); //Tuple of (score, rest)
                        
                        return Evaluate(to_evaluate.Substring(1), "", rest += calculation.Item2, currentScore += calculation.Item1);
                    }
                    // The bracket is just added to the rest if the currently_evaluating part is empty (nothing to evaluate)
                    return Evaluate(to_evaluate.Substring(1), "", rest += next_char, currentScore); 
                }
                
            }
            if (char.IsLetter(next_char))
            {
                next_char = char.ToUpper(next_char);
                if (currently_evaluating.Length == 0) //Part complete: Calculate now
                {
                    calculation = Calculate_score(currently_evaluating + next_char); // Tuple of (score, rest)
                    
                    return Evaluate(to_evaluate.Substring(1), "", rest + calculation.Item2, currentScore += calculation.Item1);
                }
                // Add letter to currently_evaluating so it can be evaluated later
                return Evaluate(to_evaluate.Substring(1), currently_evaluating += next_char, rest, currentScore);
            }

            // This part should never be reached, atleast within the rules
            return new Tuple<int, string>(0, string.Empty);
        }

        //Calculates the score of an substring (a part)
        public Tuple<int, string> Calculate_score(string part)
        {
            int result = 0;
            
            if (part.Length == 1)
            {
                return new Tuple<int, string>(_letterScore.Where(x => x.Key.Contains(part[0])).FirstOrDefault().Value, "");
            }
            if (part.Length > 1)
            {
                int scaling = 1;
                if (part.First() == '{' && part.Last() == '}')
                {
                    return new Tuple<int, string> (sum_letter_scores(part)*2, "");
                }

                else if (part.First() == '[' && part.Last() == ']')
                {
                    return new Tuple<int, string>(sum_letter_scores(part)*3, "");
                }

                

            }
           
                return new Tuple<int, string> (result, part); 
            
        }

        private int sum_letter_scores(string substring)
        {
            int score = 0;
            for (int i = 1; i < substring.Length; i++)
            {
                score += _letterScore.Where(x => x.Key.Contains(substring[i])).FirstOrDefault().Value;
            }
            return score;
        }






















        public int mscore()
        {
            if (_word.Length == 0)
            {
                return 0;
            }
            int totalScore = 0;
            int nextLetterScore = 0;

            //init wordscaling
            int wordscaling = 1;
            if (_word.First() == '{' && _word.Last() == '}')
            {
                wordscaling = 2;
                _word = _word.Substring(0, _word.Length - 2);
            }

            else if (_word.First() == '[' && _word.Last() == ']')
            {
                wordscaling = 3;
                _word = _word.Substring(0, _word.Length - 2);

            }
            

            for (int i = 0; i < _word.Length; i++)
            {
                nextLetterScore = 0;
                char bigC = char.ToUpper(_word[i]);


                if (char.IsLetter(bigC))
                {
                    nextLetterScore = _letterScore.Where(x => x.Key.Contains(bigC)).FirstOrDefault().Value;
                }
                else if (bigC == '{') 
                {
                 if ((_word.Length > i + 2))
                    {
                        if (_word[i+2] == '}')
                        {
                            bigC = char.ToUpper(_word[i+1]);
                            nextLetterScore = _letterScore.Where(x => x.Key.Contains(bigC)).FirstOrDefault().Value * 2;
                        }
                    }
 
                }

                else if (bigC == '[')
                {
                    if ((_word.Length > i + 2))
                    {
                        if (_word[i + 2] == ']')
                        {
                            bigC = char.ToUpper(_word[i + 1]);
                            nextLetterScore = _letterScore.Where(x => x.Key.Contains(bigC)).FirstOrDefault().Value * 3;
                        }
                    }
                }

                else
                {
                    return 0;
                }
                
                totalScore += nextLetterScore;
            }

            return totalScore * wordscaling;
        }




    }


}
