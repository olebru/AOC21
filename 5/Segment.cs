public class Segment
{
    private Point _start;
    private Point _end;
 
    public Segment(string rawInputLine)
    {
        var startX = Convert.ToInt32(rawInputLine.Split(" ")[0].Split(",")[0]);
        var startY = Convert.ToInt32(rawInputLine.Split(" ")[0].Split(",")[1]);
        var endX = Convert.ToInt32(rawInputLine.Split(" ")[2].Split(",")[0]);
        var endY = Convert.ToInt32(rawInputLine.Split(" ")[2].Split(",")[1]);
        _start = new Point(startX, startY);
        _end = new Point(endX, endY);

    }

    public Boolean IsHorizontal()
    {
        return _start.Y == _end.Y;
    }
    public Boolean IsVertial()
    {
        return _start.X == _end.X;
    }

    public Boolean IsDiagonal()
    {


        if (
            (_start.X + _end.Y)==(_start.Y + _end.X) ||
            (_start.X + _end.X)==(_start.Y + _end.Y) ||
            (_start.X + _start.Y)==(_end.X + _end.Y) 
            
        )
        {
            return true;
        }
        return false;


    }

    public List<Point> GetAllPoints()
    {
        var result = new List<Point>();
        result.Add(_start);
        result.Add(_end);
        return result;


    }
    public List<Point> GenerateAllHorizontalPoints()
    {
        var result = new List<Point>();

        if (IsHorizontal())
        {
            var left = _start.X <= _end.X ? _start : _end;
            var right = left == _start ? _end : _start;

            for (int x = left.X; x < (right.X + 1); x++)
            {
                result.Add(new Point(x, left.Y));
            }
        }
        return result;
    }

    public List<Point> GenerateAllVerticalPoints()
    {
        var result = new List<Point>();

        if (IsVertial())
        {
            var top = _start.Y <= _end.Y ? _start : _end;
            var bottom = top == _start ? _end : _start;

            for (int y = top.Y; y < (bottom.Y + 1); y++)
            {
                result.Add(new Point(top.X, y));
            }
        }
        return result;
    }
    public List<Point> GenerateAllDiagonalPoints()
    {
        var result = new List<Point>();
        if (IsDiagonal())
        {
            var left = _start.X <= _end.X ? _start : _end;
            var right = left == _start ? _end : _start;
            var bottom = left.Y < right.Y ? left : right;

            var yDir = left == bottom ? 1 : -1;

            var dist = right.X - left.X;

            for (int xOff = 0; xOff <= dist; xOff++)
            {
                var yOff = xOff * yDir;
                result.Add(new Point(left.X + xOff, left.Y + yOff));
            }

        }
        return result;
    }
}