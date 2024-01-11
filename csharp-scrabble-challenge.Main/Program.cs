// See https://aka.ms/new-console-template for more information
using csharp_scrabble_challenge.Main;

//Console.WriteLine("Hello, World!");

Scrabble s = new Scrabble("quirky");
Scrabble w = new Scrabble("OXyPHEnBUTaZoNE");

Console.WriteLine(s.score());

Console.WriteLine(w.score());
w.score();         
s.score();
