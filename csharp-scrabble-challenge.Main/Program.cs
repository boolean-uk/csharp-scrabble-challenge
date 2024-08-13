// See https://aka.ms/new-console-template for more information
using csharp_scrabble_challenge.Main;

Console.WriteLine("Hello, World!");
Scrabble test0 = new Scrabble("");
/* 

Scrabble test2 = new Scrabble(" \t\n");
Scrabble test3 = new Scrabble("a");
Scrabble test4 = new Scrabble("f");
Scrabble test5 = new Scrabble("street");
Scrabble test6 = new Scrabble("quirky");
Scrabble test7 = new Scrabble("OXyPHEnBUTaZoNE");

Console.WriteLine(test1.score());
Console.WriteLine(test2.score());
Console.WriteLine(test3.score());
Console.WriteLine(test4.score());
Console.WriteLine(test5.score());
Console.WriteLine(test6.score());
Console.WriteLine(test7.score());
*/
Scrabble test = new Scrabble("dog");
Scrabble test1 = new Scrabble("d{o}g");
Scrabble test2 = new Scrabble("d[o]g");
Scrabble test3 = new Scrabble("{dog}");

Console.WriteLine(test0.score());
Console.WriteLine(test1.score());
Console.WriteLine(test2.score());
Console.WriteLine(test3.score());


