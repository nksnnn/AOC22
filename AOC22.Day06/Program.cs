var input = File.ReadAllText(AppContext.BaseDirectory + "Files/input.txt").ToList();
bool done = false, found = false;

for (var i = 13; i < input.Count && done == false; i++)
{
    var list = input.GetRange(i - 13, 14);
    for (var j = 0; j < 14 && found == false; j++)
    {
        var c = list[0];
        list.RemoveAt(0);
        found = list.Contains(c);
    }

    if (!found)
    {
        Console.WriteLine(++i);
        done = true;
    }

    found = false;
}