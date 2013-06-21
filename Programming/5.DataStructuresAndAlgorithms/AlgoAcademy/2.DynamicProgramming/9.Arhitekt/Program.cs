using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;

class Program
{
    static int[][] blocks = null;

    static Dictionary<string, int> dp =
        new Dictionary<string, int>();

    static int Solve(string state, int height, int rows, int cols)
    {
        var tuple = state + ";" + rows + ";" + cols;

        if (dp.ContainsKey(tuple) && dp[tuple] > height)
        {
            return dp[tuple];
        }

        dp[tuple] = height;

        var result = height;

        var sb = state.ToCharArray();

        for (int i = 0; i < blocks.Length; i++)
        {
            if (sb[i] == '1') continue;

            sb[i] = '1';

            for (int j = 0; j < 3; j++)
            {
                int x = blocks[i][(0 + j) % 3];
                int y = blocks[i][(1 + j) % 3];
                int z = blocks[i][(2 + j) % 3];

                if (x < y)
                {
                    int t = y;
                    y = x;
                    x = t;
                }

                if (x <= rows && y <= cols)
                {
                    var solve = Solve(new string(sb), height + z, x, y);
                    result = Math.Max(solve, result);
                }
            }

            sb[i] = '0';
        }

        return result;
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
        Debug.Listeners.Add(new ConsoleTraceListener());
#endif

        var date = DateTime.Now;

        blocks = Enumerable.Range(0, int.Parse(Console.ReadLine()))
            .Select(i => Console.ReadLine().Split().Select(int.Parse).ToArray())
            .ToArray();

        Console.WriteLine(Solve(string.Concat(Enumerable.Repeat('0', blocks.Length)), 0, int.MaxValue, int.MaxValue));

        Debug.WriteLine(DateTime.Now - date);
    }
}