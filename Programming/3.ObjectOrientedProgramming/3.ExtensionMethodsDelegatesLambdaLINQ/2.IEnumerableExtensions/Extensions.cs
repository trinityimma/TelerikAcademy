using System;
using System.Collections.Generic;

static class IEnumerableExtensions
{
    // Min / Max
    private static T MinMax<T>(this IEnumerable<T> elements, Func<dynamic, T, bool> predicate)
    {
        using (IEnumerator<T> i = elements.GetEnumerator())
        {
            i.MoveNext();
            T best = i.Current;

            while (i.MoveNext())
                if (predicate(best, i.Current)) best = i.Current;

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

    // Sum / Product / Count
    private static T Aggregate<T>(this IEnumerable<T> elements, Func<dynamic, dynamic, dynamic> function, dynamic start)
    {
        T accumulator = start;

        foreach (T item in elements) accumulator = function(item, accumulator);

        return accumulator;
    }

    public static T Sum<T>(this IEnumerable<T> elements)
    {
        return Aggregate(elements, (a, b) => a + b, 0);
    }

    public static T Product<T>(this IEnumerable<T> elements)
    {
        return Aggregate(elements, (a, b) => a * b, 1);
    }

    public static T Count<T>(this IEnumerable<T> elements)
    {
        return Aggregate(elements, (a, b) => b + 1, 0);
    }

    // Average
    public static double Average<T>(this IEnumerable<T> elements)
    {
        return Convert.ToDouble(elements.Sum<T>()) / Convert.ToDouble(elements.Count<T>()); // TODO: Optimize
    }
}
