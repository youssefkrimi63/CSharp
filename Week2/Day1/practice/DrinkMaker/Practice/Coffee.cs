public class Coffee : Drink
{
    public string Roast { get; set; }
    public string BeanType { get; set; }

    public Coffee(string name, string color, double temp, string roast, string beanType, int calories)
        : base(name, color, temp, false, calories)
    {
        Roast = roast;
        BeanType = beanType;
    }

    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Roast: {Roast}, BeanType: {BeanType}");
    }
}