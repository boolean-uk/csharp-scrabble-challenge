using csharp_scrabble_challenge.Main;

Scrabble s = new Scrabble("");
Scrabble s1 = new Scrabble(" \t\n");
Scrabble s2 = new Scrabble("a");
Scrabble s3 = new Scrabble("f");
Scrabble s4 = new Scrabble("street");
Scrabble s5 = new Scrabble("quirky");
Scrabble s6 = new Scrabble("OXyPHEnBUTaZoNE");


Scrabble s7 = new Scrabble("dog");
Scrabble s8 = new Scrabble("{dog}");
Scrabble s9 = new Scrabble("[dog]");
Scrabble s10 = new Scrabble("d{o}g");


Console.WriteLine("Din score er: " + s.score());
Console.WriteLine("Din score er: " + s1.score());
Console.WriteLine("Din score er: " + s2.score());
Console.WriteLine("Din score er: " + s3.score());
Console.WriteLine("Din score er: " + s4.score());
Console.WriteLine("Din score er: " + s5.score());
Console.WriteLine("Din score er: " + s6.score());

Console.WriteLine("Din score er: " + s7.score());
Console.WriteLine("Din score er: " + s8.score());
Console.WriteLine("Din score er: " + s9.score());
Console.WriteLine("Din score er: " + s10.score());