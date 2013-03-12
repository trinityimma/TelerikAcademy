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

    static List<R> Map<T, R>(this IList<T> arr, Func<T, int, R> f)
    {
        List<R> result = new List<R>();

        for (int i = 0; i < arr.Count; i++) 
            result.Add(f(arr[i], i));

        return result;
    }

    static List<T> Where<T>(this IList<T> arr, Predicate<T> f)
    {
        List<T> result = new List<T>();

        foreach (T x in arr)
            if (f(x)) result.Add(x);

        return result;
    }

    static T Reduce<T>(this IList<T> arr, Func<T, T, T> f)
    {
        T current = arr[0];

        for (int i = 1; i < arr.Count; i++)
            current = f(current, arr[i]);

        return current;
    }


    static T Reduce<T>(this IList<T> arr, Func<T, T, T> f, T first)
    {
        //return arr.Shift(first).Reduce(f);

        T current = first;

        for (int i = 0; i < arr.Count; i++)
            current = f(current, arr[i]);

        return current;
    }

    static Func<T, T> Compose<T>(params Func<T, T>[] arr)
    {
        //if (arr.Length == 0)
        //    return result;

        //return Compose(
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

    static Func<T, T> Repeat<T>(Func<T, T> f, int n)
    {
        return new Func<T, T>[n].Map(x => f).Reduce((a, b) => Compose(a, b));
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

            //Console.WriteLine("Map: i: Binary(arr[i]) ");
            //Print(numbers.Map((x, i) => i + ": " + Convert.ToString(x, 2).PadLeft(3)));
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

            //// Join
            //Console.WriteLine("Join");
            //Print(numbers.Map(x => Convert.ToString(x)).Reduce((a, b) => a + ", " + b));

            //// Count
            //Console.WriteLine("Count");
            //Print(numbers.Reduce((a, b) => a + 1) - numbers[0] + 1);
            //Print(numbers.Reduce((a, b) => a + 1, 0));
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
            //Console.WriteLine("Compose: f0(x) = x + 1; f0(1)");
            //Print(Compose<int>(x => x + 1)(1));

            //Console.WriteLine("Compose: f0(x) = x + 1; f1(x) = x * 2; f1(f0(1))");
            //Print(Compose<int>(x => x + 1, x => x * 2)(1));

            //Console.WriteLine("Compose: f0(x) = x + 1; f1(x) = x * 2; f2(x) = x * x; f2(f1(f0(1)))");
            //Print(Compose<int>(x => x + 1, x => x * 2, x => x * x)(1));
            //Print(Compose(Compose(Compose<int>(x => x + 1), x => x * 2), x => x * x)(1));
        }

        {
            //Console.WriteLine("Repeat: f(x) = x * x; f(f(f(2)))");
            //Print(Repeat<int>(x => x * x, 4)(2));
        }
    }

    static void Print<T>(IList<T> arr)
    {
        arr.Foreach(x => Console.WriteLine(x));
    }

    static void Print(object obj)
    {
        Console.WriteLine(obj);
    }
}
