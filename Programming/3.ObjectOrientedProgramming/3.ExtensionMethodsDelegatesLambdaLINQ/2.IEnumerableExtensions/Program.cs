using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        IEnumerable<int> elements = Enumerable.Range(1, 9);

        Console.WriteLine(elements.Count<int>());
        Console.WriteLine(elements.Min<int>());
        Console.WriteLine(elements.Max<int>());
        Console.WriteLine(elements.Sum<int>());
        Console.WriteLine(elements.Product<int>());
        Console.WriteLine(elements.Average<int>());
    }
}
