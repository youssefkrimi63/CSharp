

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");

// ! first eruption 
Eruption firstEruptionInChile = eruptions.FirstOrDefault(e => e.Location == "Chile");


if (firstEruptionInChile != null)
{
    Console.WriteLine($"\nFirst eruption in Chile:\n{firstEruptionInChile}");
}
else
{
    Console.WriteLine("\nNo eruptions found in Chile.");
}

// ! 2 Find the first eruption 
Eruption firstEruptionHawaiianIs = eruptions.FirstOrDefault(e => e.Location == "Hawaiian Is");


if (firstEruptionHawaiianIs != null)
{
    Console.WriteLine($"\nFirst eruption in Hawaiian Is:\n{firstEruptionHawaiianIs}");
}
else
{
    Console.WriteLine("\nNo eruptions found in Hawaiian Is .");
}

// ! 3
Eruption firstEruptionGreenland = eruptions.FirstOrDefault(e => e.Location == "Greenland");


if (firstEruptionGreenland != null)
{
    Console.WriteLine($"\nFirst eruption in Greenland :\n{firstEruptionGreenland}");
}
else
{
    Console.WriteLine("\nNo eruptions found in Greenland  .");
}

// !4
Eruption firstEruptionAfter1900InNZ = eruptions.FirstOrDefault(e => e.Year > 1900 && e.Location == "New Zealand");
Console.WriteLine($"\nFirst eruption after 1900 in New Zealand:\n{firstEruptionAfter1900InNZ}");

// ! 5
IEnumerable<Eruption> highElevationEruptions = eruptions.Where(e => e.ElevationInMeters > 2000);

PrintEach(highElevationEruptions, "Eruptions with elevation over 2000m:");

void PrintEach(IEnumerable<Eruption> highElevationEruptions, string v)
{
    throw new NotImplementedException();
}


// ! 6

IEnumerable<Eruption> eruptionsStartingWithL = eruptions.Where(e => e.Volcano.StartsWith("L"));

PrintEach(eruptionsStartingWithL, "Eruptions with names starting with 'L':");
Console.WriteLine($"Number of eruptions starting with 'L': {eruptionsStartingWithL.Count()}");

// ! 7

int highestElevation = eruptions.Max(e => e.ElevationInMeters);
Console.WriteLine($"\nHighest Elevation: {highestElevation}");

// ! 8

Eruption volcanoWithHighestElevation = eruptions.FirstOrDefault(e => e.ElevationInMeters == highestElevation);
Console.WriteLine($"\nVolcano with the highest elevation ({highestElevation}m):\n{volcanoWithHighestElevation?.Volcano}");

// ! 9

IEnumerable<string> sortedVolcanoNames = eruptions
    .Select(e => e.Volcano)
    .OrderBy(name => name);

PrintEach(sortedVolcanoNames, "Volcano Names Alphabetically:");

// ! 10

int totalElevation = eruptions.Sum(e => e.ElevationInMeters);
Console.WriteLine($"\nTotal Elevation of All Volcanoes: {totalElevation}m");

// ! 11
bool anyEruptionsInYear2000 = eruptions.Any(e => e.Year == 2000);
Console.WriteLine($"\nDid any volcanoes erupt in the year 2000? {anyEruptionsInYear2000}");

// ! 12

IEnumerable<Eruption> stratovolcanoes = eruptions
    .Where(e => e.Type == "Stratovolcano")
    .Take(3);

PrintEach(stratovolcanoes, "First three Stratovolcanoes:");

// ! 13
IEnumerable<Eruption> eruptionsBeforeYear1000 = eruptions
    .Where(e => e.Year < 1000)
    .OrderBy(e => e.Volcano);

PrintEach(eruptionsBeforeYear1000, "Eruptions before the year 1000 CE alphabetically by Volcano name:");

// ! 14

IEnumerable<string> namesOfEruptionsBeforeYear1000 = eruptions
    .Where(e => e.Year < 1000)
    .OrderBy(e => e.Volcano)
    .Select(e => e.Volcano);

PrintEach(namesOfEruptionsBeforeYear1000, "Names of eruptions before the year 1000 CE alphabetically by Volcano name:");

void PrintEach(IEnumerable<string> namesOfEruptionsBeforeYear1000, string v)
{
    throw new NotImplementedException();
}
