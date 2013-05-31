using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Init<T>(Dictionary<T, int> dict, T value)
    {
        if (!dict.ContainsKey(value))
            dict[value] = 0;
    }

    static T FindMax<T>(Dictionary<T, int> dict)
        where T : IComparable<T>
    {
        var max = dict.First();

        foreach (var current in dict.Skip(1))
        {
            int compared = current.Value.CompareTo(max.Value);

            if ((compared > 0) || (compared == 0 && current.Key.CompareTo(max.Key) < 0))
                max = current;
        }

        return max.Key;
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var date = DateTime.Now;

        var d1 = new Dictionary<string, int>();
        var d2 = new Dictionary<string, int>();
        var d3 = new Dictionary<int, int>();
        var d4 = new Dictionary<string, int>();
        var d5 = new Dictionary<string, int>();
        var d6 = new Dictionary<int, int>();

        var separator = new string[] { ", " };

        foreach (int i in Enumerable.Range(0, int.Parse(Console.ReadLine())))
        {
            var parts = Console.ReadLine().Split(separator, StringSplitOptions.None);

            var names = parts[0].Split();

            Init(d1, names[0]);
            d1[names[0]]++;

            Init(d2, names[1]);
            d2[names[1]]++;

            int v3 = int.Parse(parts[1]);
            Init(d3, v3);
            d3[v3]++;

            Init(d4, parts[2]);
            d4[parts[2]]++;

            Init(d5, parts[3]);
            d5[parts[3]]++;

            int v6 = int.Parse(parts[4]);
            Init(d6, v6);
            d6[v6]++;
        }

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
#endif

        Console.WriteLine(string.Join(Environment.NewLine,
            FindMax(d1), FindMax(d2), FindMax(d3), FindMax(d4), FindMax(d5), FindMax(d6))
        );

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
#endif
    }
}
