var input = System.IO.File.ReadAllLines(".\\Input.txt");

var prev = new List<int>();
var fishList = new List<int>();

var currentData = new Int64[9];
var nextData = new Int64[9];


foreach (var item in input[0].Split(","))
{
    currentData[Convert.ToInt64(item)] = currentData[Convert.ToInt64(item)] + 1;
}

int days = 256;

for (int i = 1; i <= days; i++)
{
    nextData = new Int64[9];
    nextData[0] = currentData[1];
    nextData[1] = currentData[2];
    nextData[2] = currentData[3];
    nextData[3] = currentData[4];
    nextData[4] = currentData[5];
    nextData[5] = currentData[6];
    nextData[6] = currentData[7] + currentData[0];
    nextData[7] = currentData[8];
    nextData[8] = currentData[0];

    currentData = nextData;

    Console.WriteLine($"Day {i} {nextData.Sum()}");


}

Console.WriteLine($"Number of fish {currentData.Sum()}");

