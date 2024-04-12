public class Horse : Vehicle, IFuel
{
    public string FuelType {get;set;}
    public int FuelTotal {get;set;}
    public Horse(string n, string c, int ts, string ft) : base(n, 2, c, false, ts) 
    {
        FuelType = ft;
        FuelTotal = 10;
    }

    public void GiveFuel(int Amount)
    {
        FuelTotal+=Amount;
        Console.WriteLine($"Fed {Name} some {FuelType}.");
    }
}