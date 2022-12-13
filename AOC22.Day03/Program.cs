#region PART ONE
{
    IEnumerable<string> input = File.ReadAllLines(AppContext.BaseDirectory + "Files/input.txt");
    var prioritySum = 0;

    // A:65 Z:90 - a:97 z:122

    foreach (var line in input)
    {
        var first = line.Substring(0, line.Length / 2);
        var second = line.Substring(line.Length / 2);

        var common = first.FirstOrDefault(c => second.Contains(c));

        if (common == '\0') continue;
        
        if (common < 97) prioritySum += common - 64 + 26;
        else prioritySum += common - 96;
    }

    Console.WriteLine($"FIRST PART {prioritySum}");
}
#endregion

#region PART TWO
{
    var prioritySum = 0;
    var list = new List<string>();

    // A:65 Z:90 - a:97 z:122

    foreach (var line in File.ReadAllLines(AppContext.BaseDirectory + "Files/input.txt"))
    {
        if (list.Count == 3)
        {
            var common = list[0].First(c => list[1].Contains(c) && list[2].Contains(c));
            prioritySum += common < 97 ? common - 64 + 26 : common - 96;
            list = new List<string>();
        }

        list.Add(line);
    }

    if (list.Count == 3)
    {
        var common = list[0].First(c => list[1].Contains(c) && list[2].Contains(c));
        prioritySum += common < 97 ? common - 64 + 26 : common - 96;
    }

    Console.WriteLine($"SECOND PART {prioritySum}");
}
#endregion