using System;
using System.Collections.Generic;

static class Program
{
    private static T Reduce<T>(this IEnumerable<T> items, Func<dynamic, T, T> func, dynamic first = null)
    {
        IEnumerator<T> i = items.GetEnumerator();

        i.MoveNext();
        T previous = first ?? i.Current;

        while (i.MoveNext())
            previous = func(i.Current, previous);

        return previous;
    }

    static T Max<T>(this IEnumerable<T> items)
    {
        return items.Reduce((a, b) => a > b ? a : b);
    }

    static T Min<T>(this IEnumerable<T> items)
    {
        return items.Reduce((a, b) => a < b ? a : b);
    }

    static T Sum<T>(this IEnumerable<T> items)
    {
        return items.Reduce((a, b) => a + b);
    }

    static T Product<T>(this IEnumerable<T> items)
    {
        return items.Reduce((a, b) => a * b);
    }

    static int Count<T>(this IEnumerable<T> items)
    {
        return Convert.ToInt32(items.Reduce((a, _) => a + 1, 1));
    }

    static double Average<T>(this IEnumerable<T> items)
    {
        return Convert.ToDouble(items.Sum()) / items.Count(); // TODO: Optimize
    }

    static void Main()
    {
        int[] elements = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        Console.WriteLine("Max: {0}", elements.Max<int>());
        Console.WriteLine("Min: {0}", elements.Min<int>());
        Console.WriteLine("Sum: {0}", elements.Sum<int>());
        Console.WriteLine("Product: {0}", elements.Product<int>());
        Console.WriteLine("Count: {0}", elements.Count<int>());
        Console.WriteLine("Average: {0}", elements.Average<int>());
    }
}
