// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


static string CoinFlip()
{
    Random rand = new Random();
    if(rand.Next(2) == 0)
    {
        return "Heads";
    } else {
        return "Tails";
    }
}
Console.WriteLine(CoinFlip());

static List<int> StatRoll()
{
    List<int> Results = new List<int>();
    for(int i = 0; i < 4; i++)
    {
        Results.Add(DiceRoll(6));
    }
    return Results;
}

Console.WriteLine(string.Join(", ", StatRoll()));

static int DiceRoll(int sides)
{
    Random rand = new Random();
    return rand.Next(1,sides+1);
}

Console.WriteLine(DiceRoll(6));

static string RollUntil(int number, int sides)
{
    if(number > sides)
    {
        return "Please choose another number";
    }
    int count = 0;
    int result = DiceRoll(sides);
    while(result != number)
    {
        count++;
        result = DiceRoll(sides);
    }
    return $"give a {number} after {count} tries";
}

Console.WriteLine(RollUntil(3, 6));