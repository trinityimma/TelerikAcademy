using System;
using System.Collections.Generic;
using System.Linq;

static class IEnumerableExtensions
{
    public static void Print(this IEnumerable<int> list)
    {
        foreach (var item in list) Console.WriteLine(item);

        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        IEnumerable<int> numbers = Enumerable.Range(1, 100);

        numbers.Where(n =>
            n % 21 == 0
        ).Print();

        (from n in numbers
            where n % 21 == 0
            select n
         ).Print();
    }
}
