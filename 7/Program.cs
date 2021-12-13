var input = System.IO.File.ReadAllLines(".\\Input.txt");

var initPositions = new List<int>();

foreach (var item in input[0].Split(","))
{
    initPositions.Add(Convert.ToInt32(item));
}
var numberOfCrabs = initPositions.Count;
var longestDistance = initPositions.Max() + 1;

var costs = new int[numberOfCrabs][];
for (int i = 0; i < numberOfCrabs; i++)
{
    costs[i] = new int[longestDistance];
    var initPos = initPositions[i];
    for (int j = 0; j < longestDistance; j++)
    {
        var numberOfSteps = Math.Abs(j - initPos);
        var cost = 0;
        var stepCost = 1;
        while(numberOfSteps != 0)
        {
            cost = cost +stepCost;
            stepCost++;
            numberOfSteps--;
        }

        costs[i][j] = cost;
        
    }
}

int result = int.MaxValue;
for (int i = 0; i < longestDistance; i++)
{
    int temp = 0;
    for (int j = 0; j < numberOfCrabs; j++)
    {
        if (temp > result)
        {
            break;
        }
        temp += costs[j][i];
    }
    if (temp < result)
    {
        result = temp;
    }
}

Console.WriteLine(result);




 