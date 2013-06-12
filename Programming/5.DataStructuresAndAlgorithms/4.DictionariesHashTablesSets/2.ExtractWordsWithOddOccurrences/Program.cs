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
        var elements = new[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

        var occurrences = GroupByOccurrence(elements);
        var result = occurrences.Where(kvp => kvp.Value % 2 == 1);

        Console.WriteLine(string.Join(" ", result));
    }
}
