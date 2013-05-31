using System;
using System.Linq;

class Program
{
    static bool[][] input = null;

    static long?[] dp = null;

    static long CalcSallary(int row)
    {
        if (dp[row] != null)
            return dp[row].Value;

        long sallary = input[row]
            .Select((col, i) => i)
            .Where(col => input[row][col])
            .Sum(col => CalcSallary(col));

        if (sallary == 0)
            sallary = 1;

        dp[row] = sallary;
        return sallary;
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        int n = int.Parse(Console.ReadLine());

        input = Enumerable.Range(0, n)
            .Select(_ => Console.ReadLine())
            .Select(line =>
                line.Select(c => c == 'Y').ToArray()
            ).ToArray();

        dp = new long?[n];

        long result = input
            .Select((row, i) => i)
            .Sum(i => CalcSallary(i));

        Console.WriteLine(result);
    }
}
