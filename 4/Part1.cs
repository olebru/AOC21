public static class Part1
{
    public static void Compute(string[] data)
    {
        var numbersText = data[0].Split(",");
        var numbers = new List<int>();
        foreach (var item in numbersText)
        {
            numbers.Add(Convert.ToInt32(item));

        }
        var boards = new List<BingoBoard>();
        var boardFactory = new BoardFactory();
        for (int i = 2; i < data.Length; i += 6)
        {
            int end = i + 5;
            boards.Add(boardFactory.CreateBingoBoard(data[i..end]));
        }

        foreach (var number in numbers)
        {
            foreach (var board in boards)
            {
                board.Mark(number);
            }
        }
    }
}
