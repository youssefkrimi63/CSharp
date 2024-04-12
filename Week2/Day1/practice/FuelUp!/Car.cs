public class Car : Vehicle, IFuel
{
    public string FuelType {get;set;}
    public int FuelTotal {get;set;}
    public Car(string n, int np, string c, int ts, string ft) : base(n, np, c, true, ts) 
    {
        FuelType = ft;
        FuelTotal = 10;
    }

    public void GiveFuel(int Amount)
    {
        FuelTotal+=Amount;
        Console.WriteLine($"Fueled the {Name} with {FuelType} to {FuelTotal}.");
    }
}