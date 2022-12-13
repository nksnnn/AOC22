#region PART ONE
{
    var total = 0;
    var input = File.ReadAllLines(AppContext.BaseDirectory + "Files/input.txt");
    
    total = input.Where(c =>
    {
        var array = c.Split(",");
        var first = array[0].Split("-").Select(s => int.Parse(s)).ToList();
        var second = array[1].Split("-").Select(s => int.Parse(s)).ToList();
        return (first[0] >= second[0] && first[1] <= second[1] ||
                first[0] <= second[0] && first[1] >= second[1]);
    }).Count();
    
    Console.WriteLine($"FIRST PART {total}");
}
#endregion

#region PART TWO
{
    var total = File.ReadAllLines(AppContext.BaseDirectory + "Files/input.txt").Where(c =>
    {
        var array = c.Split(",");
        var first = array[0].Split("-").Select(s => int.Parse(s)).ToList();
        var second = array[1].Split("-").Select(s => int.Parse(s)).ToList();

        // 2-4,6-8  FALSE    4-2 = 2 
        // 2-3,4-5  FALSE
        // 5-7,7-9  TRUE
        // 2-8,3-7  TRUE
        // 6-6,4-6  TRUE
        // 2-6,4-8  TRUE

        return first[0] <= second[1] && second[0] <= first[1];
    }).Count();
    
    Console.WriteLine($"SECOND PART {total}");
}
#endregion