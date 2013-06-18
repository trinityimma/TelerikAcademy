using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static int[] pleasantness = null;
    static int variety = 0;

    static int[] dp = Enumerable.Repeat(int.MaxValue, 50).ToArray();

    static int minTasksSolved = int.MaxValue;

    static Stack<int> path = new Stack<int>();

    static void Solve(int start, int min, int max, int tasksSolved)
    {
        if (max - min >= variety)
        {
            minTasksSolved = Math.Min(tasksSolved, minTasksSolved);
            Debug.WriteLine(string.Join(" ", path.Reverse().Select(x => x)));
            return;
        }

        if (dp[start] < tasksSolved)
        {
            return;
        }

        dp[start] = tasksSolved;
        for (int i = 2; i >= 1; i--)
        {
            var next = start + i;

            if (next < pleasantness.Length)
            {
                var nextMin = Math.Min(pleasantness[next], min);
                var nextMax = Math.Max(pleasantness[next], max);

                path.Push(next);
                Solve(next, nextMin, nextMax, tasksSolved + 1);
                path.Pop();
            }
            else
            {
                minTasksSolved = Math.Min(pleasantness.Length, minTasksSolved);
                Debug.WriteLine("end");
            }
        }
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
        Debug.Listeners.Add(new ConsoleTraceListener());
#endif

        Console.ReadLine();
        pleasantness = Regex.Split(Console.ReadLine(), " ").Select(int.Parse).ToArray();
        variety = int.Parse(Console.ReadLine());

        path.Push(0);
        Solve(0, pleasantness[0], pleasantness[0], 1);
        path.Pop();

        Debug.WriteLine("DP: " + string.Join(" ", dp.Take(pleasantness.Length).Select(x => x != int.MaxValue ? x.ToString() : "-")));

        Console.WriteLine(minTasksSolved);
    }
}
