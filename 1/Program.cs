// See https://aka.ms/new-console-template for more information

//part 1

var input = System.IO.File.ReadAllLines(".\\input.txt");

var data = new int[input.Length];

for (int i = 0; i < input.Length; i++)
{
    data[i] = Convert.ToInt32(input[i]);
}

var result1 = 0;
var result2 = 0;

for (int i = 1; i < data.Length; i++)
{
    result1 += data[i] > data[i - 1] ? 1 : 0;
}

var slidingWindows = new List<int>();

for (int i = 2; i < data.Length; i++)
{
    slidingWindows.Add(data[i] + data[i-1]+ data[i-2]);
}


for (int i = 1; i < slidingWindows.Count; i++)
{
    result2 += slidingWindows[i] > slidingWindows[i - 1] ? 1 : 0;
}


Console.WriteLine("Part 1");
Console.WriteLine(result1);


Console.WriteLine("Part 2");
Console.WriteLine(result2);