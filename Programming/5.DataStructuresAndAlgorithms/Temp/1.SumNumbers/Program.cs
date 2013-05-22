using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();

        for (string line = null; !string.IsNullOrEmpty(line = Console.ReadLine()); )
            numbers.Add(int.Parse(line));

        Console.WriteLine("{0} {1}", numbers.Sum(), numbers.Average());
    }
}
