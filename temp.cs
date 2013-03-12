using System;
using System.Collections.Generic;

static class Program
{
    static void Foreach<T>(this IList<T> arr, Action<T> f)
    {
        foreach (T x in arr) f(x);
    }

    static void Foreach<T>(this IList<T> arr, Action<T, int> f)
    {
        for (int i = 0; i < arr.Count; i++) f(arr[i], i);
    }

    static List<R> Map<T, R>(this IList<T> arr, Func<T, R> f)
    {
        List<R> result = new List<R>();

        foreach (T x in arr)
            result.Add(f(x));

        return result;
    }

    static List<T> Where<T>(this IList<T> arr, Predicate<T> f)
    {
        List<T> result = new List<T>();

        foreach (T x in arr)
            if (f(x)) result.Add(x);

        return result;
    }

    static Т Reduce<Т>(this IList<Т> arr, Func<Т, Т, Т> f)
    {
        Т current = arr[0];

        for (int i = 1; i < arr.Count; i++)
            current = f(current, arr[i]);

        return current;
    }

    static Func<T, T> Compose<T>(params Func<T, T>[] arr)
    {
        //if (arr.Length == 0)
        //    return result;

        //return Composition(
        //    x => arr[0](result(x)),
        //    arr.Skip(1).ToArray()
        //);

        //Func<T, T> result = arr[0];

        //for (int i = 1; i < arr.Length; i++)
        //{
        //    Func<T, T> temp = result;
        //    Func<T, T> f = arr[i];
        //    result = x => f(temp(x));
        //}

        //return result;

        return arr.Reduce((a, b) => x => b(a(x)));
    }

    // TODO: YCombinator, Currying
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
            //Console.WriteLine("Foreach: x, i");
            //numbers.Foreach((x, i) => Console.WriteLine("arr[{0}] = {1}", i, x));
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
            //Print(numbers.Map(x => Math.Pow(2, x)));
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
            //Print(Compose<int>(x => x + 1)(1));

            //Console.WriteLine("Recurse: f0(x) = x + 1; f1(x) = x * 2; f1(f0(1))");
            //Print(Compose<int>(x => x + 1, x => x * 2)(1));

            //Console.WriteLine("Recurse: f0(x) = x + 1; f1(x) = x * 2; f2(x) = x * x; f2(f1(f0(1)))");
            //Print(Compose<int>(x => x + 1, x => x * 2, x => x * x)(1));
        }
    }

    static void Print<T>(IList<T> arr)
    {
        arr.Foreach(x => Console.WriteLine(x));
    }

    static void Print(int n)
    {
        Console.WriteLine(n);
    }
}
