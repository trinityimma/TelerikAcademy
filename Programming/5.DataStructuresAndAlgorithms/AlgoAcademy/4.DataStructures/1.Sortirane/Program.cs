using System;
using System.Linq;

class Program
{
    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        uint x = Console.ReadLine().Split().Select(uint.Parse).ElementAt(1);

        Console.WriteLine(string.Join(" ", Console.ReadLine()
            .Split()
            .Select(uint.Parse)
            .OrderBy(n => n % x)
            .ThenBy(n => n)
        ));
    }
}
