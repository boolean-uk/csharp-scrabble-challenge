// See https://aka.ms/new-console-template for more information
using csharp_scrabble_challenge.Main;

Console.WriteLine("Hello, World!");
string word = "a";
Scrabble test = new Scrabble(word);


Console.WriteLine(test.score());