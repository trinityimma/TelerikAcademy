using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static IDictionary<T, int> GroupByOccurrence<T>(IEnumerable<T> elements)
    {
        return elements.GroupBy(el => el).ToDictionary(group => group.Key, group => group.Count());
    }

    static void Main()
    {
        var elements = new[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

        Console.WriteLine(string.Join(" ", GroupByOccurrence(elements)));
    }
}
