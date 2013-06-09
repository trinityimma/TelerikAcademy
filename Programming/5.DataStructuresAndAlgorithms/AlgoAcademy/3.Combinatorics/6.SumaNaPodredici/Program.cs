using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

class Program
{
    static int[] indices = null;
    static int[] numbers = null;

    static bool[] used = null;

    static int result = 0;

    static void Variation(int i)
    {
        if (i == indices.Length)
        {
            result += indices.Select(x => numbers[x]).Sum();

            Debug.WriteLine(string.Join(" ", indices.Select(x => numbers[x])));

            return;
        }

        for (int j = 0; j < used.Length; j++)
        {
            if (used[j]) continue;

            indices[i] = j;

            used[j] = true;
            Variation(i + 1);
            used[j] = false;
        }
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
        Debug.Listeners.Add(new ConsoleTraceListener());
#endif

        foreach (int i in Enumerable.Range(0, int.Parse(Console.ReadLine())))
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];
            int k = input[1];

            string line = Console.ReadLine();
            numbers = line.Split().Select(int.Parse).ToArray();

            indices = new int[n - k];

            used = new bool[n];

            result = 0;

            Variation(0);

            Console.WriteLine(result);
        }
    }
}
