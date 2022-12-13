namespace AOC22.Day07;

public class AocFile
{
    public AocFile(string name, Dir parentDir, ulong size, string? extension = null)
    {
        Name = name;
        Extension = extension;
        Size = size;
        ParentDir = parentDir;
    }

    public string Name { get; set; }
    public Dir ParentDir { get; set; }
    public string? Extension { get; set; }
    public ulong Size { get; set; }
}