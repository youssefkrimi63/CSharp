// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<Drink> AllBeverages = new List<Drink>
        {
            new Soda(" Cola", "Brown", 4.0, false, 150),
            new Coffee("Americano", "Black", 80.0, "Medium", "Arabica", 5),
            new Wine("Red Wine", "Red", 18.0, "Bordeaux", 2019, 120)
        };

foreach (var beverage in AllBeverages)
{
    beverage.ShowDrink();
    Console.WriteLine();
}