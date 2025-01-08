using csharp_scrabble_challenge.Main;

Console.WriteLine("SCRABBLE GAME");
Console.WriteLine("Write a word and get a score!");
Console.WriteLine("Write ... to exit!\n");

while (true)
{
    Console.Write("Input: ");
    string word = Console.ReadLine() ?? "";
    if (word == "...")
    {
        Console.WriteLine("Do you want to exit? (y/n)");
        string confirm = Console.ReadLine() ?? "";
        if (!string.IsNullOrEmpty(confirm) && confirm.ToLower() == "y")
        {
            break;
        }
        Console.WriteLine("Game will continue!");
    }
    else
    {
        Scrabble s = new Scrabble(word);
        Console.Write("Score: ");
        Console.WriteLine(s.score());
    }
}