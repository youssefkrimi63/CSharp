// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Car Car1 = new Car("Bmw M3", 2, "black", true);
Car Car2 = new Car("Porche ", "purple");
Car Car3 = new Car("Audi", 2, "white", false);
Car Car4 = new Car("supra", "blue");

List<Car> vehicleList = new List<Car>
        {
            Car1,
            Car2,
            Car3,
            Car4
        };

foreach (var vehicle in vehicleList)
{
    vehicle.ShowInfo();
    Console.WriteLine(); 
}

Car1.Travel(4558);
