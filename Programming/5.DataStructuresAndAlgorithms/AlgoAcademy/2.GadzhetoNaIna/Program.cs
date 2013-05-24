using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        int n = int.Parse(Console.ReadLine());

        var input = Enumerable.Range(0, n)
            .Select(_ => Console.ReadLine().Split())
            .Select(line =>
                new KeyValuePair<string, string>(line[0], line[1])
            );

        var sorted = input.OrderBy(kvp => Regex.Matches(kvp.Value, "1").Count);

        Console.WriteLine(sorted.Last().Key);
    }
}
