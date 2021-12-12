public class Map
{
    private List<Segment> _segments;
    private int[] _map;
    public Map(List<Segment> segments)
    {
        _segments = segments;
        _calulateHeightAndWidth();
        _map = new int[Width * Height];
        _calculateMapWeights();
    }

    public int Width { get; private set; }
    public int Height { get; private set; }
    private void _calulateHeightAndWidth()
    {

        foreach (var segment in _segments)
        {
            foreach (var point in segment.GetAllPoints())
            {
                if (point.X > Width)
                {
                    Width = point.X;
                }
                if (point.Y > Height)
                {
                    Height = point.Y;
                }
            }
        }
        Height++;
        Width++;
    }

    private void _calculateMapWeights()
    {
        foreach (var segment in _segments)
        {

            foreach (var point in segment.GenerateAllHorizontalPoints())
            {
                var idx = point.X + point.Y * Width;
                _map[idx]++;
            }
            foreach (var point in segment.GenerateAllVerticalPoints())
            {
                var idx = point.X + point.Y * Width;
                _map[idx]++;
            }
        }

    }

    public void CalculatePart2()
    {

        foreach (var segment in _segments)
        {

            foreach (var point in segment.GenerateAllDiagonalPoints())
            {
                var idx = point.X + point.Y * Width;
                _map[idx]++;
            }
        }
    }

    public string GenerateStringMap()
    {
        var result = new System.Text.StringBuilder();
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                var idx = y + x * Width;
                switch (_map[idx])
                {
                    case 0:
                       result.Append(".");
                        break;
                    default:
                        result.Append(_map[idx].ToString());
                        break;
                }
            }
            result.Append(System.Environment.NewLine);

        }


        var overlap = 0;
        foreach (var item in _map)
        {
            if (item > 1)
            {
                overlap++;
            }
        }

        result.Append(System.Environment.NewLine);
        result.Append($"Number of overlapping: {overlap}");
        return result.ToString();
    }
}

