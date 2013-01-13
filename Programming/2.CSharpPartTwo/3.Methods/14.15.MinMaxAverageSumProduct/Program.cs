using System;

class Program
{
    static T GetMin<T>(T[] arr) where T : IComparable<T>
    {
        int best = 0;

        for (int i = 1; i < arr.Length; i++) if (arr[i].CompareTo(arr[best]) < 0) best = i;

        return arr[best];
    }

    static T GetMax<T>(T[] arr) where T : IComparable<T>
    {
        int best = 0;

        for (int i = 1; i < arr.Length; i++) if (arr[i].CompareTo(arr[best]) > 0) best = i;

        return arr[best];
    }

    static T GetAverage<T>(T[] arr)
    {
        return GetSum(arr) / (dynamic)arr.Length;
    }

    static T GetSum<T>(T[] arr)
    {
        dynamic accumulator = 0;

        for (int i = 0; i < arr.Length; i++) accumulator += arr[i];

        return accumulator;
    }

    static T GetProduct<T>(T[] arr)
    {
        dynamic accumulator = 1;

        for (int i = 0; i < arr.Length; i++) accumulator *= arr[i];

        return accumulator;
    }

    static void Main()
    {
        int[] arr = { 5, 8, -1, 3 };

        Console.WriteLine(GetMin(arr));
        Console.WriteLine(GetMax(arr));
        Console.WriteLine(GetAverage(arr));
        Console.WriteLine(GetSum(arr));
        Console.WriteLine(GetProduct(arr));
    }
}
