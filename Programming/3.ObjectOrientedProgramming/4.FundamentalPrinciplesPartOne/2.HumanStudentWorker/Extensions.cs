using System;
using System.Collections.Generic;

static class IEnumerableExtensions
{
    public static void Print(this IEnumerable<object> list)
    {
        foreach (object item in list) Console.WriteLine(item);

        Console.WriteLine();
    }
}