var elves = new Dictionary<int, int>();
var testing = 1;
var done = false;
var topThree = 0;

foreach (var line in File.ReadLines(AppContext.BaseDirectory + "/Files/input.txt"))
{
    if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line))
    {
        testing++;
        continue;
    }
    
    if (!int.TryParse(line.Trim(), out var value))
    {
        Console.WriteLine($"Error while parsing value {line} ... ");
        continue;
    }

    if (elves.ContainsKey(testing))
    {
        value += elves[testing]; 
        elves.Remove(testing);
        elves.Add(testing, value);
    }
    else
    {
        elves.Add(testing, value);
    }
}

for(var i = 0; i < 3; i++)
{
    var highest = -1;
    var elve = -1;
    
    foreach (var v in elves)
    {
        if (v.Value > highest)
        {
            highest = v.Value;
            elve = v.Key;
        }
    }

    elves.Remove(elve);
    topThree += highest;
}

Console.WriteLine($"The sum of the three highest is {topThree}");