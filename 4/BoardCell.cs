public class BoardCell
{
    public BoardCell(int value)
    {
        Value = value;
    }

    public int Value { get; set; }
    public bool Marked { get; set; }
}