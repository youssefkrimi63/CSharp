// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
string[] names = new string[] { "Tim", "Martin", "Nikki ", "Sara" };
bool[] boolean = new bool[10];
boolean[0] = true;
boolean[1] = false;
boolean[2] = true;
boolean[3] = false;
boolean[4] = true;
boolean[5] = false;


List<string> iceCream = new List<string>();
iceCream.Add("Flavor1");
iceCream.Add("Flavor2");
iceCream.Add("Flavor3");
iceCream.Add("Flavor4");
iceCream.Add("Flavor5");
iceCream.Add("Flavor6");

System.Console.WriteLine(iceCream.Count);
System.Console.WriteLine(iceCream[2]);
iceCream.RemoveAt(2);
System.Console.WriteLine(iceCream.Count);

Dictionary<string, string> Disc = new Dictionary<string, string>();
Random random = new Random();
foreach (string name in names)
{
    int randomIndex = random.Next(iceCream.Count);
    string randomFlavor = iceCream[randomIndex];
    Disc[name] = randomFlavor;
}
foreach (var pair in Disc)
{
    System.Console.WriteLine($"{pair.Key} ' s favorite Ice Cream Flavor is {pair.Value}...");
}