// See https://aka.ms/new-Systeme.Systeme.System.System.Console-template for more information
System.Console.WriteLine("Hello, World!");

static void PrintList(List<string> MyList)
{
    foreach (var item in MyList)
    {
        System.Console.WriteLine(item);
    }
}
List<string> TestStringList = new List<string>() {"Harry", "Steve", "Carla", "Jeanne"};
PrintList(TestStringList);


static void SumOfNumbers(List<int> IntList)
{
    int sum = 0 ;
    foreach (var item in IntList)
    {
        sum += item ;
    }
    System.Console.WriteLine(sum);
}
List<int> TestIntList = new List<int>() {2,7,12,9,3};
SumOfNumbers(TestIntList);


static int FindMax(List<int> IntList)
{
    int max = IntList[0]; 
    for (int i = 1; i < IntList.Count; i++)
    {
        if (IntList[i] > max)
        {
            max = IntList[i];
        }
    }
    System.Console.WriteLine(max);
    return max;
}
List<int> TestIntList2 = new List<int>() { -9, 12, 10, 3, 17, 5 };
FindMax(TestIntList2);

//44444444

List<int> TestIntList3 = new List<int>() { 1, 2, 3, 4, 5 };
List<int> squaredList = SquareValues(TestIntList3);

System.Console.Write("Original List: ");
PrintList(TestIntList3);

System.Console.Write("Squared List: ");
PrintList(squaredList);


static List<int> SquareValues(List<int> IntList)
{
    List<int> squaredList = new List<int>();

    foreach (int value in IntList)
    {
        squaredList.Add(value * value);
    }

    return squaredList;
}

static void PrintList(List<int> list)
{
    System.Console.Write("[");
    for (int i = 0; i < list.Count; i++)
    {
        System.Console.Write(list[i]);
        if (i < list.Count - 1)
        {
            System.Console.Write(", ");
        }
    }
    System.Console.WriteLine("]");
}

//555

int[] TestIntArray = new int[] { -1, 2, 3, -4, 5 };
int[] resultArray = NonNegatives(TestIntArray);

System.Console.Write("Original Array: ");
PrintArray(TestIntArray);

System.Console.Write("Modified Array: ");
PrintArray(resultArray);

static int[] NonNegatives(int[] IntArray)
{
    int[] NonNegativesArray = new int[IntArray.Length];

    for (int i = 0; i < IntArray.Length; i++)
    {
        NonNegativesArray[i] = Math.Max(0, IntArray[i]);
    }

    return NonNegativesArray;
}

static void PrintArray(int[] array)
{
    System.Console.Write("[");
    for (int i = 0; i < array.Length; i++)
    {
        System.Console.Write(array[i]);
        if (i < array.Length - 1)
        {
            System.Console.Write(", ");
        }
    }
    System.Console.WriteLine("]");
}


static void PrintDictionary(Dictionary<string, string> MyDictionary)
{
    foreach (var kvp in MyDictionary)
    {
        System.Console.WriteLine($"{kvp.Key}: {kvp.Value}");
    }
}
Dictionary<string, string> TestDict = new Dictionary<string, string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
PrintDictionary(TestDict);

Dictionary<string, string> TestDict = new Dictionary<string, string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");


System.Console.WriteLine(FindKey(TestDict, "RealName"));
System.Console.WriteLine(FindKey(TestDict, "Name"));

static bool FindKey(Dictionary<string, string> MyDictionary, string SearchTerm)
{
    return MyDictionary.ContainsKey(SearchTerm);
}

List<string> testNames = new List<string> { "Julie", "Harold", "James", "Monica" };
List<int> testNumbers = new List<int> { 6, 12, 7, 10 };

Dictionary<string, int> resultDict = GenerateDictionary(testNames, testNumbers);

System.Console.WriteLine("Generated Dictionary:");
PrintDictionary(resultDict);


static Dictionary<string, int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    Dictionary<string, int> resultDict = new Dictionary<string, int>();
    for (int i = 0; i < Names.Count; i++)
    {
        resultDict.Add(Names[i], Numbers[i]);
    }

    return resultDict;
}

static void PrintDictionary(Dictionary<string, int> MyDictionary)
{
    foreach (var kvp in MyDictionary)
    {
        System.Console.WriteLine($"{kvp.Key}: {kvp.Value}");
    }
}