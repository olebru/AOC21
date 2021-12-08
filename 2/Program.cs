var input = System.IO.File.ReadAllLines(".\\input.txt");

var horizontal = 0;
var depth = 0;

foreach (var item in input)
{
    var direction = item.Split(" ")[0];
    var change = Convert.ToInt32(item.Split(" ")[1]);
    switch (direction)
    {
        case "forward":
            horizontal += change;
            break;
        case "up":
            depth -= change;
            break;
        case "down":
            depth += change;
            break;


    }
}

Console.WriteLine($"part 1: pos = {horizontal} depth = {depth} result = {horizontal*depth}");

horizontal = 0;
depth = 0;
var aim = 0;
foreach (var item in input)
{
    var direction = item.Split(" ")[0];
    var change = Convert.ToInt32(item.Split(" ")[1]);
    switch (direction)
    {
        case "forward":
            horizontal += change;
            depth = depth + (aim * change);
            break;
        case "up":
            aim -= change;
            break;
        case "down":
            aim += change;
            break;


    }
}

Console.WriteLine($"part 1: pos = {horizontal} depth = {depth} result = {horizontal*depth}");
       