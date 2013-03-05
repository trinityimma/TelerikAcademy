using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Print(IEnumerable<int> list)
    {
        foreach (var item in list) Console.WriteLine(item);

        Console.WriteLine();
    }

    static void Main()
    {
        IEnumerable<int> numbers = Enumerable.Range(1, 100);

        Print(numbers.Where(n =>
            n % 21 == 0
        ));

        Print(
            from n in numbers
            where n % 21 == 0
            select n
        );
    }
}
