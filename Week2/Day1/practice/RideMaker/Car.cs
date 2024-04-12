public class Car
{
    // Properties
    public string Name { get; set; }
    public int Number { get; set; }
    public string Color { get; set; }
    public bool Drift { get; set; }
    public double Km{ get; set; } = 0;

    // Constructors **
    public Car(string name, int number, string color, bool drift)
    {
        Name = name;
        Number = number;
        Color = color;
        Drift = drift;
    }
    public Car(string name, string color)
    {
        Name = name;
        Number = 4;
        Color = color;
        Drift = true;
        Km= 200;
    }

    // Methods
    public virtual void ShowInfo()
    {
        System.Console.WriteLine($"Car name : {Name}\nPassengers : {Number}\nColor : {Color}\nDrift : {Drift}%\nKm: {Km}");
    }

    public virtual void Travel(double distance)
    {
        Km+=  distance ;
        Console.WriteLine($"The vehicle has {distance} Km. Total Km: {Km}");
    }

}