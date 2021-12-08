public static class Part1
{
    public static void Compute(string[] input)
    {

        var bitSumOfOnes = new int[input[0].Length];

        int bitLength = bitSumOfOnes.Length;
        int maxValue = (int)System.Math.Pow(2, bitLength) - 1;



        foreach (var textByte in input)
        {
            for (int i = 0; i < bitSumOfOnes.Length; i++)
            {
                bitSumOfOnes[i] += Convert.ToInt32(textByte.Substring(i, 1));
            }
        }

        var resultBin = new System.Text.StringBuilder();
        for (int i = 0; i < bitSumOfOnes.Length; i++)
        {
            if (bitSumOfOnes[i] > input.Length / 2)
            {
                resultBin.Append("1");
            }
            else
            {
                resultBin.Append("0");
            }
        }

        var gamma = Convert.ToInt32(resultBin.ToString(), 2);
        var epsilon = maxValue - gamma;

        Console.WriteLine($"gamma = {gamma} epsilon = {epsilon} result = {gamma * epsilon}");

    }


}