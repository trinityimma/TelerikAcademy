using System;
using System.Linq;
using System.Diagnostics;

class Program
{
    static int[][] blocks = null;

    static bool[] used = null;

    static int Solve(int height, int rows, int cols)
    {
        //Debug.WriteLine(string.Join(" ", height, rows, cols));

        var result = height;

        for (int i = 0; i < blocks.Length; i++)
        {
            if (used[i]) continue;

            used[i] = true;

            for (int j = 0; j < 3; j++)
            {
                int x = blocks[i][(0 + j) % 3];
                int y = blocks[i][(1 + j) % 3];
                int z = blocks[i][(2 + j) % 3];

                if (x < y)
                {
                    Swap(ref x, ref y);
                }

                if (rows >= x && cols >= y)
                {
                    var solve = Solve(height + z, x, y);
                    result = Math.Max(solve, result);
                }
            }

            used[i] = false;
        }

        return result;
    }

    static void Swap(ref int y, ref int x)
    {
        int t = y;
        y = x;
        x = t;
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
        Debug.Listeners.Add(new ConsoleTraceListener());
#endif

        blocks = Enumerable.Range(0, int.Parse(Console.ReadLine()))
            .Select(i => Console.ReadLine().Split().Select(int.Parse).ToArray())
            .ToArray();

        used = new bool[blocks.Length];

        Console.WriteLine(Solve(0, int.MaxValue, int.MaxValue));
    }
}
