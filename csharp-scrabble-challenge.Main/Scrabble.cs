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
        String word;
        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            this.word = word.ToUpper();
        }

        public int score()
        {
            //TODO: score calculation code goes here

           //set score to be zero
            int score = 0;
            //initialise a dictionary with all characters and ther points
            Dictionary <char, int> map = new Dictionary<char, int>(){
            { 'A', 1},{ 'B', 3},{ 'C', 3},{ 'D', 2},{ 'E', 1},{ 'F', 4},
            { 'G', 2},{ 'H', 4},{ 'I', 1},{ 'J', 8},{ 'K', 5},{ 'L', 1},
            { 'M', 3},{ 'N', 1},{ 'O', 1},{ 'P', 3},{ 'Q', 10},{ 'R', 1},
            { 'S', 1},{ 'T', 1},{ 'U', 1},{ 'V', 4},{ 'X', 8},{ 'Y', 4},
            { 'Z', 10},};

            
          
            for(int i = 0; i < word.Length; i++)
            {

                if (map.ContainsKey(word[i]))
                {
                    score += map[word[i]];
                }
                else if (!(map.ContainsKey(word[i])))
                {
                    if (word[i] == '{' || word[i] == '[') 
                    {
                        int outerMulti = word[i] == '{' ? 2 : 3;
                        //skrive expected end bracket
                        char expectedOuterBracket= word[i] == '{' ? '}' : ']';
                        i++;
                      

                        while (word[i] != '}' && word[i] != ']')
                        {
                        
                            if (word[i] == '{' || word[i] == '[')
                            {
                                int innerMulti = word[i] == '{' ? 2 : 3;
                                char expectedInnerBracket = word[i] == '{' ? '}' : ']';
                                i++;
                                while (word[i] != '}' && word[i] != ']')
                                {
                                    if (!(map.ContainsKey(word[i]))){
                                        return 0;
                                    }
                                    int mdl = map[word[i]];
                                    //hva skal multiplieren være??
                                    score += mdl * innerMulti * outerMulti;
                                    i++;

                                }
                                //her kan man sjekke bracket
                                if (expectedInnerBracket != word[i])
                                {
                                    return 0;
                                }
                                i++;

                            }
                            else {
                                if (!(map.ContainsKey(word[i])))
                                {
                                    return 0;
                                }
                                int newscore = map[word[i]];
                                score += newscore * outerMulti;
                                i++;
                        }
                            
                        }
                        //her kan man sjekke bracket
                        if (expectedOuterBracket != word[i])
                        {
                            return 0;
                        }
                       
                    }
                   
                }
                

            }
            return score;


        }
      
    }
}
