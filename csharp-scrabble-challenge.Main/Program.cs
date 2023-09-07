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

            //Initializing wordlist and the game
            var wordList = new WordList(fullPathToWordList);

            //asking user for input
            Console.WriteLine("Please enter a word to get the matching score:");
            string userInputWord = Console.ReadLine();

            //starting game with the user input word
            var game = new Scrabble(userInputWord, wordList);

            //printing out the score for the word
            Console.WriteLine($"The score for the word {game.GetWord()} is: {game.score()}");
        }
    }
}