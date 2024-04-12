public class Wine : Drink
{
    public string Region { get; set; }
    public int BottledYear { get; set; }
    public Wine(string name, string color, double temp, string region, int bottledYear, int calories)
        : base(name, color, temp, false, calories) 
    {
        Region = region;
        BottledYear = bottledYear;
    }
    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Region: {Region}, BottledYear: {BottledYear}");
    }
}