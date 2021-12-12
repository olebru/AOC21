public class BoardFactory
{
    private int boardnum = -1;

    public BingoBoard CreateBingoBoard(string[] data)
    {
        boardnum++;
        return new BingoBoard(data, boardnum);
    }

}