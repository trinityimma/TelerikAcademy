using System;
using System.Collections.Generic;

static class IEnumerableExtensions
{
    // Min / Max
    private static T ForEach<T>(this IEnumerable<T> items, Func<T, dynamic, T> func, dynamic start = null)
    {
        IEnumerator<T> i = items.GetEnumerator();

        i.MoveNext();
        T best = start ?? i.Current;

        while (i.MoveNext())
            best = func(i.Current, best);

        return best;
    }

    public static T Max<T>(this IEnumerable<T> items)
    {
        return ForEach(items, (a, b) => a > b ? a : b);
    }

    public static T Min<T>(this IEnumerable<T> items)
    {
        return ForEach(items, (a, b) => a < b ? a : b);
    }

    public static T Sum<T>(this IEnumerable<T> items)
    {
        return ForEach(items, (a, b) => a + b);
    }

    public static T Product<T>(this IEnumerable<T> items)
    {
        return ForEach(items, (a, b) => a * b);
    }

    public static int Count<T>(this IEnumerable<T> items)
    {
        return Convert.ToInt32(ForEach(items, (_, b) => b + 1, start: 1));
    }

    // Average
    public static double Average<T>(this IEnumerable<T> items)
    {
        return Convert.ToDouble(items.Sum<T>()) / Convert.ToDouble(items.Count<T>()); // TODO: Optimize
    }
}
