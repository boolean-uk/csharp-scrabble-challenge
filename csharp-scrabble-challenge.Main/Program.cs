// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Hello, World!");
Console.WriteLine("n\r\t\b\f".ToUpper().ToString());

List<string> Val_1 = new List<string> {"A", "E", "I", "O", "U", "L", "N", "R", "S", "T"};
//Val_1.AddRange({ "A", "E", "I", "O", "U", "L", "N", "R", "S", "T" };);
foreach (string c in Val_1)
{
    Console.WriteLine(c);
}
//Console.WriteLine(Val_1);

string[] input = { "Brachiosaurus",
                           "Amargasaurus",
                           "Mamenchisaurus" };

List<string> dinosaurs = new List<string>(input);

Console.WriteLine("\nCapacity: {0}", dinosaurs.Capacity);
Console.WriteLine(dinosaurs);

string word = "d{o}g";
Console.WriteLine(word.Length);

Console.WriteLine(word[4]);

//Console.WriteLine(word[0]);
