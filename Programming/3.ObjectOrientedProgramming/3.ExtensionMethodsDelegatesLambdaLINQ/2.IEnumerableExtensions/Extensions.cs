using System;
using System.Collections.Generic;

static class IEnumerableExtensions
{
    // Count
    public static int Count<T>(this IEnumerable<T> elements)
    {
        int count = 0;

        foreach (T _ in elements)
            count++;

        return count;
    }

    // Min / Max
    private static T MinMax<T>(this IEnumerable<T> elements, Func<dynamic, T, bool> predicate)
    {
        using (IEnumerator<T> i = elements.GetEnumerator())
        {
            i.MoveNext();
            T best = i.Current;

            while (i.MoveNext())
                if (predicate(best, i.Current))
                    best = i.Current;

            return best;
        }
    }

    public static T Max<T>(this IEnumerable<T> elements)
    {
        return MinMax(elements, (a, b) => a < b);
    }

    public static T Min<T>(this IEnumerable<T> elements)
    {
        return MinMax(elements, (a, b) => a > b);
    }

    // Sum / Product
    private static T SumProduct<T>(this IEnumerable<T> elements, Func<dynamic, T, T> function, dynamic start)
    {
        T accumulator = start;

        foreach (T item in elements)
            accumulator = function(item, accumulator);

        return accumulator;
    }

    public static T Sum<T>(this IEnumerable<T> elements)
    {
        return SumProduct(elements, (a, b) => a + b, 0);
    }

    public static T Product<T>(this IEnumerable<T> elements)
    {
        return SumProduct(elements, (a, b) => a * b, 1);
    }

    // Average
    public static double Average<T>(this IEnumerable<T> elements)
    {
        Func<dynamic, double> convert = Convert.ToDouble;

        return convert(elements.Sum<T>()) / convert(elements.Count<T>()); // TODO: Optimize
    }
}
