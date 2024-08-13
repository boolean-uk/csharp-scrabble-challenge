

using csharp_scrabble_challenge.Main;

Scrabble test = new Scrabble("word");
test.score();
foreach (char key in test.pointSheet.Keys)
{
    Console.WriteLine($"{key} {test.pointSheet[key]}");
}
