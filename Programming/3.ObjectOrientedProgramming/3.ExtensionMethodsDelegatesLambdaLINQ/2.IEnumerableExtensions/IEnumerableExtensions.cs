using System;
using System.Collections.Generic;

static class IEnumerableExtensions
{
    // Min / Max
    private static T MinMax<T>(this IEnumerable<T> items, Func<T, dynamic, bool> pred)
    {
        using (IEnumerator<T> i = items.GetEnumerator())
        {
            i.MoveNext();
            T best = i.Current;

            while (i.MoveNext())
                if (pred(best, i.Current)) best = i.Current;

            return best;
        }
    }

    public static T Max<T>(this IEnumerable<T> items)
    {
        return MinMax(items, (a, b) => a < b);
    }

    public static T Min<T>(this IEnumerable<T> items)
    {
        return MinMax(items, (a, b) => a > b);
    }

    // Sum / Product / Count
    private static T Aggregate<T>(this IEnumerable<T> items, Func<T, dynamic, dynamic> func, dynamic acc)
    {
        foreach (T item in items)
            acc = func(item, acc);

        return acc;
    }

    public static T Sum<T>(this IEnumerable<T> items)
    {
        return Aggregate(items, (a, b) => a + b, 0);
    }

    public static T Product<T>(this IEnumerable<T> items)
    {
        return Aggregate(items, (a, b) => a * b, 1);
    }

    public static T Count<T>(this IEnumerable<T> items)
    {
        return Aggregate(items, (_, b) => b + 1, 0);
    }

    // Average
    public static double Average<T>(this IEnumerable<T> items)
    {
        return Convert.ToDouble(items.Sum<T>()) / Convert.ToDouble(items.Count<T>()); // TODO: Optimize
    }
}
