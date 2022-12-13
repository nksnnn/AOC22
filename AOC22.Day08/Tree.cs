namespace AOC22.Day08;

public class Tree
{
    public Tree(byte size)
    {
        IsVisible = true;
        Size = size;
    }

    public bool IsVisible { get; set; }
    public byte Size { get; set; }
    public bool hasBeenChecked { get; set; } = false;
}