using System;
using System.Linq;

class Program
{
    static int[] deltas = null;
    static int[] current = null;

    static int startVolume = 0;
    static int maxVolume = 0;
    static int result = -1;

    static int[,] dp = null;

    static int Solve(int start)
    {
        if (start == current.Length)
        {
            result = Math.Max(result, current.Last());
            return current.Last();
        }

        if (dp[current[start - 1], start] != -1)
            return dp[current[start - 1], start];

        int currentResult = 0;

        current[start] = current[start - 1] + deltas[start - 1];
        if (current[start] <= maxVolume)
            currentResult += Solve(start + 1);

        current[start] = current[start - 1] - deltas[start - 1];
        if (0 <= current[start])
            currentResult += Solve(start + 1);

        dp[current[start - 1], start] = currentResult;
        return currentResult;
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        Console.ReadLine(); // C
        deltas = Console.ReadLine().Split().Select(int.Parse).ToArray();
        startVolume = int.Parse(Console.ReadLine());
        maxVolume = int.Parse(Console.ReadLine());

        current = new int[deltas.Length + 1];
        dp = new int[maxVolume + 1, deltas.Length + 1];

        for (int row = 0; row < dp.GetLength(0); row++)
            for (int col = 0; col < dp.GetLength(1); col++)
                dp[row, col] = -1;

        current[0] = startVolume;
        Solve(1);

        Console.WriteLine(result);
    }
}
