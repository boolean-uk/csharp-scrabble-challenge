using csharp_scrabble_challenge.Main;
using System.IO;

namespace csharp_scrabble_challenge
{
    class Program
    {
        static void Main()
        {
            //setting up path for SOWPODS.txt
            string currentDirectory = Directory.GetCurrentDirectory();
            string relativePathToWordList = "./SOWPODS.txt";
            string fullPathToWordList = Path.Combine(currentDirectory, relativePathToWordList);


            //making sure the file does exist
            if (!File.Exists(fullPathToWordList))
            {
                Console.WriteLine($"ERROR! Could not find word list file");
                return;
            }

            //Initializing wordlist 
            var wordList = new WordList(fullPathToWordList);
            Console.WriteLine("Welcome to the Scrabble, the best game ever!");
            Console.WriteLine("Enter a word to get its score, or press the spacebar to exit the game.");

            //asking user for input and loop untill space is pressed
            while (true)
            {            
                Console.WriteLine("Please enter a word to get the matching score:");
                string userInputWord = Console.ReadLine();
       
                //checking for spacebar pressed
                if(string.IsNullOrEmpty(userInputWord) || userInputWord == " ")
                {
                    Console.WriteLine("Thank you for playing, Goodbye!");
                    break; // for exeting the loop
                }
                //starting game with the user input word
                var game = new Scrabble(userInputWord, wordList);

                //printing out the score for the word
                Console.WriteLine($"The score for the word {game.GetWord()} is: {game.score()}");

            }

        }
    }
}