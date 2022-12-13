using System.Collections.Concurrent;
using System.Text.RegularExpressions;

#region PART ONE
{
    Regex regex = new(@"move (\d+) from (\d+) to (\d+)", RegexOptions.Singleline);

    var input = File.ReadAllLines(AppContext.BaseDirectory + "Files/input.txt");

    var dict = new Dictionary<int, Stack<char>>();

    // Parsing input for dictionary
    for (int i = 0, c = 0; i < input.Length && c == 0; i++)
    {
        var line = input[i];
        
        if (line.TrimStart().StartsWith('[')) continue;
        
        for (var j = 0; j < line.Length; j++)
        {
            if (string.IsNullOrWhiteSpace(line[j].ToString())) continue;

            var list = new List<char>();
            
            for (var e = 0; e < i; e++)
            {
                if(!string.IsNullOrWhiteSpace(input[e][j].ToString())) list.Add(input[e][j]);
            }

            list.Reverse();
            
            dict.Add(int.Parse(line[j].ToString()), new Stack<char>(list));
        }
        
        c = 1;
    }

    //Read the lines and apply movements to the dictionary
    foreach (var s in input)
    {
        var reg = regex.Match(s);

        if (!reg.Success) continue;
        var amount = int.Parse(reg.Groups[1].Captures[0].Value); // Amount of time
        var from = int.Parse(reg.Groups[2].Captures[0].Value); // 
        var dest = int.Parse(reg.Groups[3].Captures[0].Value);

        for (var i = 0; i < amount; i++)
        {
            dict[dest].Push(dict[from].Pop());
        }
    }

    Console.WriteLine(dict.Aggregate("", (current, v) => current + v.Value.Peek()));
}
#endregion

#region PART TWO
{
    Regex regex = new(@"move (\d+) from (\d+) to (\d+)", RegexOptions.Singleline);

    var input = File.ReadAllLines(AppContext.BaseDirectory + "Files/input.txt");

    var dict = new Dictionary<int, List<char>>();

    // Parsing input for dictionary
    for (int i = 0, c = 0; i < input.Length && c == 0; i++)
    {
        var line = input[i];
        
        if (line.TrimStart().StartsWith('[')) continue;
        
        for (var j = 0; j < line.Length; j++)
        {
            if (string.IsNullOrWhiteSpace(line[j].ToString())) continue;

            var list = new List<char>();
            
            for (var e = 0; e < i; e++)
            {
                if(!string.IsNullOrWhiteSpace(input[e][j].ToString())) list.Add(input[e][j]);
            }

            dict.Add(int.Parse(line[j].ToString()), list);
        }
        
        c = 1;
    }

    //Read the lines and apply movements to the dictionary
    foreach (var s in input)
    {
        var reg = regex.Match(s);

        if (!reg.Success) continue;
        var amount = int.Parse(reg.Groups[1].Captures[0].Value); // Amount of time
        var from = int.Parse(reg.Groups[2].Captures[0].Value); // 
        var dest = int.Parse(reg.Groups[3].Captures[0].Value);

        var array = dict[from].GetRange(0, amount);
        dict[from].RemoveRange(0, amount);
        var list = new List<char>(array);
        list.AddRange(dict[dest].GetRange(0, dict[dest].Count));
        dict[dest] = list;
    }

    Console.WriteLine(dict.Aggregate("", (current, v) => current + v.Value[0]));
}
#endregion