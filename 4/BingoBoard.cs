public class BingoBoard
{
    public int BoardSize { get; set; }
    private List<BoardCell> _cells = new List<BoardCell>();
    private int _id;

    bool HasWonOnce = false;


    public BingoBoard(string[] data, int id)
    {
        BoardSize = 5;
        _id = id;
        foreach (var line in data)
        {
            var values = line.Split(" ");
            foreach (var value in values)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _cells.Add(new BoardCell(Convert.ToInt32(value)));
                }
            }
        }
    }

    public Boolean Won()
    {
        if (HasWonOnce == true)
        {
            return false;
        }
        //Collumns
        for (int x = 0; x < BoardSize; x++)
        {
            int markedInCollumn = 0;
            for (int y = 0; y < BoardSize; y++)
            {
                if (_cells[_indexFromXY(x, y, BoardSize)].Marked)
                {
                    markedInCollumn++;
                }
            }
            if (markedInCollumn == BoardSize)
            {
                HasWonOnce = true;
                return true;
            }
        }
        //Rows
        for (int y = 0; y < BoardSize; y++)
        {
            int markedInRow = 0;
            for (int x = 0; x < BoardSize; x++)
            {
                if (_cells[_indexFromXY(x, y, BoardSize)].Marked)
                {
                    markedInRow++;
                }
            }
            if (markedInRow == BoardSize)
            {
                HasWonOnce = true;
                return true;
            }
        }
        return false;
    }

    public int SumOfAllUnmarked()
    {
        int result = 0;
        foreach (var unmarkedCell in _cells.Where(c => c.Marked == false))
        {
            result += unmarkedCell.Value;
        }
        return result;
    }

    private int _indexFromXY(int x, int y, int width)
    {

        return x + (y * width);

    }

    public void Mark(int number)
    {
        var cellToMark = _cells.FirstOrDefault(c => c.Value == number);
        if (cellToMark != null)
        {
            cellToMark.Marked = true;
            //Console.WriteLine($"Board: {_id} arked number: {number}");
        }
        if (Won())
        {
            int score = SumOfAllUnmarked() * number;
            Console.WriteLine($"Board: {_id} won with number: {number} score is: {score}");
            //Console.ReadLine();

        }
    }
}
