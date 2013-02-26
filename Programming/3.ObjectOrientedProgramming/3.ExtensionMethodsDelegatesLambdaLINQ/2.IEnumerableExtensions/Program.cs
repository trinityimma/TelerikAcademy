using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        IEnumerable<int> elements = Enumerable.Range(1, 9);

        Console.WriteLine("Max: {0}", elements.Max<int>());
        Console.WriteLine("Min: {0}", elements.Min<int>());
        Console.WriteLine("Sum: {0}", elements.Sum<int>());
        Console.WriteLine("Product: {0}", elements.Product<int>());
        Console.WriteLine("Count: {0}", elements.Count<int>());
        Console.WriteLine("Average: {0}", elements.Average<int>());
    }
}
