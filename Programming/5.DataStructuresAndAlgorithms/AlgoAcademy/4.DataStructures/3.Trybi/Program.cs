using System;
using System.Linq;

class Program
{
    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

        var pipes = Enumerable.Range(0, n)
            .Select(_ => int.Parse(Console.ReadLine()))
            .ToArray();

        Func<int, int> split = x =>
            pipes.Select(i => i / x).Sum();

        int min = 0;
        int max = (int)2e9;

        while (min < max)
        {
            int middle = min + (max - min + 1) / 2;

            if (split(middle) < m) max = middle - 1;
            else min = middle;
        }

        Console.WriteLine(min);
    }
}
