namespace AOC22.Day07;

public class Dir
{
    public Dir(string name, Dir? parentDir = null)
    {
        Name = name;
        ParentDir = parentDir;
    }

    public string Name { get; set; }
    public Dir? ParentDir { get; set; }
    public ulong TotalSize { get; set; } = 0;
    public List<AocFile> Files { get; set; } = new List<AocFile>();
    public List<Dir> Dirs { get; set; } = new List<Dir>();
}