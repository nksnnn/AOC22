using AOC22.Day08;

#region PartOne
{
    var input = File.ReadAllLines(AppContext.BaseDirectory + "Files/input.txt");
    
    var height = input.Length;
    var length = input[0].Length;
    
    var array = new Tree[length, height];
    
    for (var y = 0; y < height; y++)
    {
        for (var x = 0; x < length; x++)
        {
            array[x, y] = new Tree(byte.Parse(input[y][x].ToString()));
        }
    }
    
    for (var y = 0; y < height; y++)
    {
        for (var x = 0; x < length; x++)
        {
            var currentTree = array[x, y];
            currentTree.hasBeenChecked = true;
            var top = false;
            var bot = false;
            var left = false;
            var right = false;
    
            if (x == 0 || x == length - 1 || y == 0 || y == height - 1) continue;
            
            for (var i = 0; i < x; i++)
            {
                if (array[i, y] == currentTree) continue;
                if (array[i, y].Size >= currentTree.Size) left = true;
            }
            for (var i = height - 1; i > x; i--)
            {
                if (array[i, y] == currentTree) continue;
                if (array[i, y].Size >= currentTree.Size) right = true;
            }
            for (var i = 0; i < y; i++)
            {
                if (array[x, i] == currentTree) continue;
                if (array[x, i].Size >= currentTree.Size) top = true;
            }
            for (var i = length - 1; i > y; i--)
            {
                if (array[x, i] == currentTree) continue;
                if (array[x, i].Size >= currentTree.Size) bot = true;
            }
    
            if (top && bot && left && right) currentTree.IsVisible = false;
        }
    }
    
    var totalVisible = 0;
    var totalChecked = 0;
    
    for (var i = 0; i < input.Length; i++)
    {
        for (var j = 0; j < input[i].Length; j++)
        {
            var currentTree = array[j, i];
    
            Console.ForegroundColor = currentTree.IsVisible ? ConsoleColor.Red : ConsoleColor.Green;
            if (currentTree.IsVisible) totalVisible++;
            if (currentTree.hasBeenChecked) totalChecked++;
            
            Console.Write($"T");
        }
    
        Console.WriteLine();
    }
    
    Console.WriteLine();
    
    // for (var i = 0; i < input.Length; i++)
    // {
    //     for (var j = 0; j < input[i].Length; j++)
    //     {
    //         var currentTree = array[j, i];
    //
    //         Console.ForegroundColor = currentTree.hasBeenChecked ? ConsoleColor.Green : ConsoleColor.Red;
    //
    //         Console.Write($"C  ");
    //     }
    //
    //     Console.WriteLine();
    // }
    //
    // Console.WriteLine();
    
    Console.ResetColor();
    Console.WriteLine("PART ONE:");
    Console.WriteLine($"  There are {totalVisible} trees visible!");
    Console.WriteLine($"  There are {totalChecked} trees checked!");
    Console.WriteLine();
    
    /*
     *      X X X X X
     *      X X X V X
     *      X X V X X
     *      X V X V X
     *      X X X X X
     */
}
#endregion

#region Part Two
{
    var input = File.ReadAllLines(AppContext.BaseDirectory + "Files/input.txt");

    var height = input.Length;
    var length = input[0].Length;
    
    var array = new Tree[length, height];

    for (var y = 0; y < height; y++)
    {
        for (var x = 0; x < length; x++)
        {
            array[x, y] = new Tree(byte.Parse(input[y][x].ToString()));
        }
    }

    var highestScore = -1;
    
    for (var y = 0; y < height; y++)
    {
        for (var x = 0; x < length; x++)
        {
            var currentTree = array[x, y];
            currentTree.hasBeenChecked = true;
            var top = 0;
            var bot = 0;
            var left = 0;
            var right = 0;

            if (x == 0) left = 0;
            if (x == length - 1) right = 0;
            if (y == 0) top = 0;
            if (y == height - 1) bot = 0;

            for (int i = x - 1, amount = 0; i >= 0 && x > 0; i--)
            {
                amount++;
                if (currentTree.Size <= array[i, y].Size)
                {
                    i = -1;
                    left = amount;
                }

                if (i == 0) left = amount;
            }

            for (int i = x + 1, amount = 0; i < length && x < length - 1; i++)
            {
                amount++;
                if (currentTree.Size <= array[i, y].Size)
                {
                    i = length;
                    right = amount;
                }

                if (i == length - 1) right = amount;
            }

            for (int i = y - 1, amount = 0; i >= 0 && y > 0; i--)
            {
                amount++;
                if (currentTree.Size <= array[x, i].Size)
                {
                    i = -1;
                    top = amount;
                }

                if (i == 0) top = amount;
            }

            for (int i = y + 1, amount = 0; i < height && y < height - 1; i++)
            {
                amount++;
                if (currentTree.Size <= array[x, i].Size)
                {
                    i = height;
                    bot = amount;
                }

                if (i == height - 1) bot = amount;
            }

            highestScore = top * bot * left * right > highestScore ? top * bot * left * right : highestScore;
        }
    }

    Console.WriteLine("PART TWO:");
    Console.WriteLine("  " + highestScore);

    /*
     *      X X X X X
     *      X X X V X
     *      X X V X X
     *      X V X V X
     *      X X X X X
     */
}
#endregion