// See https://aka.ms/new-console-template for more information




using csharp_scrabble_challenge.Main;

void main()
{
    string userInput = "";
    var scrabbleApp = new Scrabble(userInput);
    Console.WriteLine("Hello, Scrabbler!");
    while (userInput != "/q")
    {
        
        Console.WriteLine("Type a word, press enter, get score. (/q to quit)");
        userInput = Console.ReadLine();
        Console.Clear();

        scrabbleApp.setWord(userInput);
        Console.WriteLine($"`{userInput}` gives: {scrabbleApp.score()} points!");
    }
}


main();