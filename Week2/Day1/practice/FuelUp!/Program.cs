// Create 4 vehicles using each constructor at least once
Car car = new Car("Nissan GTR", 5, "White", 120, "Gas");
Bike bike = new Bike("Btwin ", "Silver", 30);
Horse horse = new Horse("Luna", "Brown", 20, "Hay");


// Put all the vehicles created into a List
List<Vehicle> AllVehicles = new List<Vehicle>();
AllVehicles.Add(car);
AllVehicles.Add(bike);
AllVehicles.Add(horse);

List<IFuel> NeedsFuel = new List<IFuel>();

// Loop through the List of Vehicles and if an item has the INeedFuel interface applies, add it to the INeedFuel List
foreach(Vehicle v in AllVehicles)
{
    if(v is IFuel)
    {
        NeedsFuel.Add((IFuel)v);
    }
}

car.ShowInfo();