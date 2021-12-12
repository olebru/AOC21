var input = System.IO.File.ReadAllLines(".\\Input.txt");

var segments = new List<Segment>();
foreach (var line in input)
{
    segments.Add(new Segment(line));
}

var map = new Map(segments);

Console.WriteLine(map.GenerateStringMap());

map.CalculatePart2();

Console.WriteLine(map.GenerateStringMap());
