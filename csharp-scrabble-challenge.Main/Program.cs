// See https://aka.ms/new-console-template for more information
using csharp_scrabble_challenge.Main;

var safeWord = "help";
var enteredWord = "";

Console.WriteLine("Welcome to scrabble checker!");
Console.WriteLine("If things gets messy, close the application by typing the safe word.");
Console.WriteLine("Todays Safe word: " + safeWord+"\n\n");

while(enteredWord.ToLower() != safeWord)
{

    Console.WriteLine("Enter a word:");
    enteredWord = Console.ReadLine();
    Console.WriteLine("The score of " + enteredWord + " is: " + new Scrabble(enteredWord).score()+ "\n");
}