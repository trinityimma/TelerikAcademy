using System;
using System.Linq;

class Program
{
    static string input = null;

    static int maxRight = 0;
    static int maxWrong = 0;

    static int?[, ,] dp = new int?[2500, 2, 2500];

    static int Solve(int start, int current, bool wrong)
    {
        if (start == input.Length) return 0;

        var memo = dp[start, wrong ? 1 : 0, current];
        if (memo != null) return memo.Value;

        int result = 0;

        if (!wrong && current + 1 <= maxRight)
        {
            var next = (input[start] == 'G' ? 1 : 0);
            result = Math.Max(result, next + Solve(start + 1, current + 1, false));
        }

        if (wrong && current + 1 <= maxWrong)
        {
            var next = (input[start] == 'B' ? 1 : 0);
            result = Math.Max(result, next + Solve(start + 1, current + 1, true));
        }

        {
            var next = (input[start] == (wrong ? 'G' : 'B') ? 1 : 0);
            result = Math.Max(result, next + Solve(start + 1, 1, !wrong));
        }

        dp[start, wrong ? 1 : 0, current] = result;
        return result;
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var rw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        maxRight = rw[0];
        maxWrong = rw[1];
        input = Console.ReadLine();

        Console.WriteLine(Solve(0, 0, false));
    }
}
