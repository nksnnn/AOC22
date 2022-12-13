using System.Text.RegularExpressions;
using AOC22.Day07;
using File = System.IO.File;

#region PART ONE
{
    var input = File.ReadAllLines(AppContext.BaseDirectory + "Files/inputand.txt");
    var rootDir = new Dir("/");
    var currentDir = rootDir;

    var regCd = new Regex(@"\$ (cd) (.+)", RegexOptions.Singleline);
    var regLs = new Regex(@"\$ (ls)", RegexOptions.Singleline);
    var regDir = new Regex(@"dir (.+)", RegexOptions.Singleline);
    var regFileWithExt = new Regex(@"(\d+) (.+)\.(.+)", RegexOptions.Singleline);
    var regFile = new Regex(@"(\d+) (.+)", RegexOptions.Singleline);

    foreach (var line in input)
    {
        Match match;

        if (regCd.Match(line).Success)
        {
            match = regCd.Match(line);
            currentDir = match.Groups[2].Value switch
            {
                "/" => rootDir,
                ".." => currentDir?.ParentDir ?? rootDir,
                _ => currentDir?.Dirs.Find(d => d.Name == match.Groups[2].Value)
            };
        } // CD
        else if (regLs.Match(line).Success) // LS
        {
            continue;
        }
        else if (regDir.Match(line).Success) // DIR
        {
            match = regDir.Match(line);
            currentDir?.Dirs.Add(new Dir(match.Groups[1].Value, currentDir));
        }
        else if (regFile.Match(line).Success)
        {
            match = regFile.Match(line);
            currentDir?.Files.Add(new AocFile(match.Groups[2].Value, currentDir, ulong.Parse(match.Groups[1].Value),
                match.Groups[3].Value ?? null));
            currentDir.TotalSize += ulong.Parse(match.Groups[1].Value);
            Dir? parentDir = currentDir.ParentDir;
            while (parentDir is not null)
            {
                parentDir.TotalSize += ulong.Parse(match.Groups[1].Value);
                parentDir = parentDir.ParentDir;
            }
        }
        else if (regFileWithExt.Match(line).Success)
        {
            match = regFileWithExt.Match(line);
            currentDir?.Files.Add(new AocFile(match.Groups[2].Value, currentDir, ulong.Parse(match.Groups[1].Value),
                match.Groups[3].Value ?? null));
            currentDir.TotalSize += ulong.Parse(match.Groups[1].Value);
            Dir? parentDir = currentDir.ParentDir;
            while (parentDir is not null)
            {
                parentDir.TotalSize += ulong.Parse(match.Groups[1].Value);
                parentDir = parentDir.ParentDir;
            }
        }
        else
        {
            Console.WriteLine("Ayo wtf " + line);
        }
    }

    ulong total = 0;

    foreach (var dir in rootDir.Dirs)
    {
        if (dir.TotalSize <= 100000) total += dir.TotalSize;
        CheckAllDirs(dir);
    }

    void CheckAllDirs(Dir dir)
    {

        foreach (var d in dir.Dirs)
        {
            CheckAllDirs(d);
            if (d.TotalSize <= 100000) total += d.TotalSize;
        }
    }

    Console.WriteLine(total);
}
#endregion

#region PART TWO
{
    var input = File.ReadAllLines(AppContext.BaseDirectory + "Files/input.txt");
    var rootDir = new Dir("/");
    var currentDir = rootDir;
    const ulong maxSpace = 70000000;
    const ulong neededSpace = 30000000;

    var regCd = new Regex(@"\$ (cd) (.+)", RegexOptions.Singleline);
    var regLs = new Regex(@"\$ (ls)", RegexOptions.Singleline);
    var regDir = new Regex(@"dir (.+)", RegexOptions.Singleline);
    var regFileWithExt = new Regex(@"(\d+) (.+)\.(.+)", RegexOptions.Singleline);
    var regFile = new Regex(@"(\d+) (.+)", RegexOptions.Singleline);

    foreach (var line in input)
    {
        Match match;

        if (regCd.Match(line).Success)
        {
            match = regCd.Match(line);
            currentDir = match.Groups[2].Value switch
            {
                "/" => rootDir,
                ".." => currentDir?.ParentDir ?? rootDir,
                _ => currentDir?.Dirs.Find(d => d.Name == match.Groups[2].Value)
            };
        } // CD
        else if (regLs.Match(line).Success) // LS
        {
            continue;
        }
        else if (regDir.Match(line).Success) // DIR
        {
            match = regDir.Match(line);
            currentDir?.Dirs.Add(new Dir(match.Groups[1].Value, currentDir));
        }
        else if (regFile.Match(line).Success)
        {
            match = regFile.Match(line);
            currentDir?.Files.Add(new AocFile(match.Groups[2].Value, currentDir, ulong.Parse(match.Groups[1].Value),
                match.Groups[3].Value ?? null));
            currentDir.TotalSize += ulong.Parse(match.Groups[1].Value);
            Dir? parentDir = currentDir.ParentDir;
            while (parentDir is not null)
            {
                parentDir.TotalSize += ulong.Parse(match.Groups[1].Value);
                parentDir = parentDir.ParentDir;
            }
        }
        else if (regFileWithExt.Match(line).Success)
        {
            match = regFileWithExt.Match(line);
            currentDir?.Files.Add(new AocFile(match.Groups[2].Value, currentDir, ulong.Parse(match.Groups[1].Value),
                match.Groups[3].Value ?? null));
            currentDir.TotalSize += ulong.Parse(match.Groups[1].Value);
            Dir? parentDir = currentDir.ParentDir;
            while (parentDir is not null)
            {
                parentDir.TotalSize += ulong.Parse(match.Groups[1].Value);
                parentDir = parentDir.ParentDir;
            }
        }
        else
        {
            Console.WriteLine("Ayo wtf " + line);
        }
    }

    ulong usedSpace = rootDir.TotalSize;
    ulong freeSpace = maxSpace - usedSpace;
    ulong spaceToLookFor = neededSpace - freeSpace;

    var candidates = new List<Dir>();

    foreach (var dir in rootDir.Dirs)
    {
        if (!candidates.Contains(dir)) candidates.Add(dir);
        CheckAllDirs(dir);
    }

    void CheckAllDirs(Dir dir)
    {
        foreach (var d in dir.Dirs)
        {
            CheckAllDirs(d);
            if (!candidates.Contains(d)) candidates.Add(d);
        }
    }

    Console.WriteLine(candidates.Where(d => d.TotalSize >= spaceToLookFor).Min(d => d.TotalSize));
}
#endregion