using System;
using System.Collections.Generic;

static class IEnumerableExtensions
{
    // Min / Max
    private static T Reduce<T>(this IEnumerable<T> items, Func<T, dynamic, T> func, dynamic start = null)
    {
        IEnumerator<T> i = items.GetEnumerator();

        i.MoveNext();
        T previous = start ?? i.Current;

        while (i.MoveNext())
            previous = func(i.Current, previous);

        return previous;
    }

    public static T Max<T>(this IEnumerable<T> items)
    {
        return Reduce(items, (a, b) => a > b ? a : b);
    }

    public static T Min<T>(this IEnumerable<T> items)
    {
        return Reduce(items, (a, b) => a < b ? a : b);
    }

    public static T Sum<T>(this IEnumerable<T> items)
    {
        return Reduce(items, (a, b) => a + b);
    }

    public static T Product<T>(this IEnumerable<T> items)
    {
        return Reduce(items, (a, b) => a * b);
    }

    public static int Count<T>(this IEnumerable<T> items)
    {
        return Convert.ToInt32(Reduce(items, (_, b) => b + 1, start: 1));
    }

    public static double Average<T>(this IEnumerable<T> items)
    {
        return Convert.ToDouble(items.Sum<T>()) / Convert.ToDouble(items.Count<T>()); // TODO: Optimize
    }
}
