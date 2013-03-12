using System;
using System.Linq;
using System.Collections.Generic;

static class Program
{
    static void Foreach(this List<int> arr, Action<int> f)
    {
        foreach (int x in arr) f(x);
    }

    static List<int> Map(this List<int> arr, Func<int, int> f)
    {
        List<int> result = new List<int>();

        foreach (int x in arr)
            result.Add(f(x));

        return result;
    }

    static List<int> Where(this List<int> arr, Predicate<int> f)
    {
        List<int> result = new List<int>();

        foreach (int x in arr)
            if (f(x)) result.Add(x);

        return result;
    }

    static int Reduce(this List<int> arr, Func<int, int, int> f)
    {
        int current = arr[0];

        for (int i = 1; i < arr.Count; i++)
            current = f(current, arr[i]);

        return current;
    }

    static Func<int, int> Recurse(Func<int, int> result, params Func<int, int>[] functions)
    {
        if (functions.Length == 0)
            return result;

        return Recurse(
            x => functions[0](result(x)),
            functions.Skip(1).ToArray()
        );
    }

    static void Print(List<int> arr)
    {
        arr.Foreach(x => Console.WriteLine(x));
    }

    static void Print(int n)
    {
        Console.WriteLine(n);
    }

    static void Main()
    {
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };

        {
            //Console.WriteLine("Foreach: x");
            //numbers.Foreach(x => Console.WriteLine(x));

            //Console.WriteLine("Foreach: x * 2");
            //numbers.Foreach(x => Console.WriteLine(x * 2));

            //Console.WriteLine("Foreach: x * x");
            //numbers.Foreach(x => Console.WriteLine(x * x));
        }

        {
            //Console.WriteLine("Print");
            //Print(numbers);
        }

        {
            //Console.WriteLine("Map: x * 2");
            //Print(numbers.Map(x => x * 2));

            //Console.WriteLine("Map: x * x");
            //Print(numbers.Map(x => x * x));

            //Console.WriteLine("Map: 2 ^ x");
            //Print(numbers.Map(x => (int)Math.Pow(2, x)));
        }

        {
            //Console.WriteLine("Where: x % 2 == 0");
            //Print(numbers.Where(x => x % 2 == 0));

            //Console.WriteLine("Where: x > 2");
            //Print(numbers.Where(x => x > 2));
        }

        {
            //// Sum
            //Console.WriteLine("Reduce: a + b");
            //Print(numbers.Reduce((a, b) => a + b));

            //// Product
            //Console.WriteLine("Reduce: a * b");
            //Print(numbers.Reduce((a, b) => a * b));

            //// Min
            //Console.WriteLine("Reduce: a < b");
            //Print(numbers.Reduce((a, b) => a < b ? a : b));

            //// Max
            //Console.WriteLine("Reduce: a > b");
            //Print(numbers.Reduce((a, b) => a > b ? a : b));
        }

        {
            //Console.WriteLine("Map: x * 5");
            //Print(numbers.Map(x => x * 5));

            //Console.WriteLine("Map: x * 5; Where: x > 12");
            //Print(numbers.Map(x => 5 * x).Where(x => x > 12));

            //Console.WriteLine("Map: x * 5; Where: x > 12; Reduce: a + b");
            //Print(numbers.Map(x => 5 * x).Where(x => x > 12).Reduce((a, b) => a + b));
        }

        {
            //Console.WriteLine("Recurse: f0(x) = x + 1; f0(1)");
            //Console.WriteLine(Recurse(x => x + 1)(1));

            //Console.WriteLine("Recurse: f0(x) = x + 1; f1(x) = x * 2; f1(f0(1))");
            //Console.WriteLine(Recurse(x => x + 1, x => x * 2)(1));

            //Console.WriteLine("Recurse: f0(x) = x + 1; f1(x) = x * 2; f2(x) = x * x; f2(f1(f0(1)))");
            //Console.WriteLine(Recurse(x => x + 1, x => x * 2, x => x * x)(1));
        }
    }
}
