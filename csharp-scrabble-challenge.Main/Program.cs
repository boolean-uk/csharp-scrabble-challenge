// See https://aka.ms/new-console-template for more information
using csharp_scrabble_challenge.Main;

Console.WriteLine("Hello, World!");

Scrabble scrabble = new Scrabble("{qu[i]r{k}y}");
Console.WriteLine(scrabble.scoreExtension());