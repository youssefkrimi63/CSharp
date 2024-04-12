public abstract class Vehicle
{
    public string Name;
    public int NumPassengers;
    public string Color;
    public bool HasEngine;
    public int TopSpeed;
    private int DistanceTravelled = 0;

    public Vehicle(string n, int np, string c, bool he, int ts)
    {
        Name = n;
        NumPassengers = np;
        Color = c;
        HasEngine = he;
        TopSpeed = ts;
    }

    public Vehicle(string n, string c)
    {
        Name = n;
        NumPassengers = 5;
        Color = c;
        HasEngine = true;
        TopSpeed = 120;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Number of Passengers: {NumPassengers}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Has an Engine: {HasEngine}");
        Console.WriteLine($"Top Speed: {TopSpeed}");
        Console.WriteLine($"Distance Travelled: {DistanceTravelled}");
        Console.WriteLine("******************");
    }

    public void Travel(int amount)
    {
        DistanceTravelled+=amount;
        Console.WriteLine($"Traveled {amount} miles. Total distance travelled: {DistanceTravelled}");
    }
}