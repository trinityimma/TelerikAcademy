using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static Dictionary<T, int> GroupByOccurence<T>(IEnumerable<T> elements)
    {
        return elements.GroupBy(el => el).ToDictionary(pair => pair.Key, n => n.Count());
    }

    static void Main()
    {
        int[] numbers = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

        Console.WriteLine(string.Join(" ", GroupByOccurence(numbers)));
    }
}
