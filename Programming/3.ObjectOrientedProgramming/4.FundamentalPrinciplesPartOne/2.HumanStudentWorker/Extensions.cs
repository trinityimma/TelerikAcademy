using System;
using System.Text;
using System.Collections.Generic;

static class IEnumerableExtensions
{
    public static void Print(this IEnumerable<object> list)
    {
        foreach (object item in list)
            Console.WriteLine(item);

        Console.WriteLine();
    }

    public static StringBuilder TrimEnd(this StringBuilder input)
    {
        while (Char.IsWhiteSpace(input[input.Length - 1]))
            input.Remove(input.Length - 1, 1);

        return input;
    }
}
