var input = System.IO.File.ReadAllLines(".\\Input.txt");

var result = 0;
foreach (var line in input)
{
    foreach (var digit in line.Split(" | ")[1].Split(" "))
    {

      switch (digit.Length)
      {
          case 2:
          case 3:
          case 4:
          case 7:
          result++;
          break;
          default:
          break;
      }   
    }  
}
Console.WriteLine(result);
