// See https://aka.ms/new-console-template for more information
using csharp_scrabble_challenge.Main;

Console.WriteLine("Hello, gamer! Please, enter your word: ");
var input = Console.ReadLine();
Scrabble s = new Scrabble(input);
int result = s.score();
Console.WriteLine("Your score is: {0} points",  result);