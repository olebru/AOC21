public static class Part2
{
    public static void Compute(string[] input)
    {

        var O2 = Convert.ToInt32(ComputeO2(string.Empty, input), 2);
        var Co2 = Convert.ToInt32(ComputeCo2(string.Empty, input), 2);

        Console.WriteLine($"O2 = {O2} Co2 = {Co2} Result = {O2 * Co2}");


    }

    private static string ComputeO2(string done, string[] data)
    {
        var currentBitIdx = done.Length;

        var one = done + "1";
        var zero = done + "0";

        var countOne = data.Count(s => s.Substring(0, one.Length) == one);
        var countZero = data.Count(s => s.Substring(0, zero.Length) == zero);

        var result = countOne >= countZero ? one : zero;

        var matchingElements = data.Where(s => s.StartsWith(result));
        if (matchingElements.Count() == 1)
        {
            return matchingElements.First();
        }


        return result.Length == data[0].Length ? result : ComputeO2(result, data);
    }

    private static string ComputeCo2(string done, string[] data)
    {
        var currentBitIdx = done.Length;

        var one = done + "1";
        var zero = done + "0";

        var countOne = data.Count(s => s.Substring(0, one.Length) == one);
        var countZero = data.Count(s => s.Substring(0, zero.Length) == zero);


        var result = countOne >= countZero ? zero : one;


        var matchingElements = data.Where(s => s.StartsWith(result));
        if (matchingElements.Count() == 1)
        {
            return matchingElements.First();
        }


        return result.Length == data[0].Length ? result : ComputeCo2(result, data);
    }
}