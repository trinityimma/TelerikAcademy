using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var order = new Dictionary<char, int>()
        {
            { 'm', 2 },
            { 'k', 1 },
            { 'p', 0 }
        };

        Console.ReadLine();

        Console.WriteLine(string.Join(" ", Console.ReadLine()
            .Trim()
            .Split()
            .OrderByDescending(p => order[p[0]])
        ));
    }
}
