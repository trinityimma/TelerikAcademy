using System;
using System.Linq;
using System.Collections.Generic;

class Permutator<T>
{
    private readonly IList<T> elements = null;
    private readonly IList<bool> used = null;
    private readonly IList<int> indices = null;

    private Action<IList<T>> action = null;

    public Permutator(IList<T> elements)
    {
        this.elements = elements;

        this.used = new bool[elements.Count];
        this.indices = new int[elements.Count];
    }

    public void Permutation(Action<IList<T>> action)
    {
        this.action = action;

        Permutation(0);
    }

    private void Permutation(int i)
    {
        if (i == indices.Count)
        {
            action(indices.Select(x => elements[x]).ToArray());
            return;
        }

        for (int j = 0; j < indices.Count; j++)
        {
            if (used[j]) continue;

            indices[i] = j;

            used[j] = true;
            Permutation(i + 1);
            used[j] = false;
        }
    }
}

class Program
{
    static HashSet<int> set = new HashSet<int>();

    static int[][] combinations =
    {
        new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
        new [] { 4, 1, 2, 3, 8, 5, 6, 7, 12, 9, 10, 11 },
        new [] { 3, 4, 1, 2, 7, 8, 5, 6, 11, 12, 9, 10 },
        new [] { 2, 3, 4, 1, 6, 7, 8, 5, 10, 11, 12, 9 },
        new [] { 3, 7, 11, 8, 4, 2, 10, 12, 1, 6, 9, 5 },
        new [] { 2, 6, 10, 7, 3, 1, 9, 11, 4, 5, 12, 8 },
        new [] { 1, 5, 9, 6, 2, 4, 12, 10, 3, 8, 11, 7 },
        new [] { 4, 8, 12, 5, 1, 3, 11, 9, 2, 7, 10, 6 },
        new [] { 11, 10, 9, 12, 8, 7, 6, 5, 3, 2, 1, 4 },
        new [] { 10, 9, 12, 11, 7, 6, 5, 8, 2, 1, 4, 3 },
        new [] { 9, 12, 11, 10, 6, 5, 8, 7, 1, 4, 3, 2 },
        new [] { 12, 11, 10, 9, 5, 8, 7, 6, 4, 3, 2, 1 },
        new [] { 9, 6, 1, 5, 12, 10, 2, 4, 11, 7, 3, 8 },
        new [] { 12, 5, 4, 8, 11, 9, 1, 3, 10, 6, 2, 7 },
        new [] { 11, 8, 3, 7, 10, 12, 4, 2, 9, 5, 1, 6 },
        new [] { 10, 7, 2, 6, 9, 11, 3, 1, 12, 8, 4, 5 },
        new [] { 5, 4, 8, 12, 9, 1, 3, 11, 6, 2, 7, 10 },
        new [] { 8, 3, 7, 11, 12, 4, 2, 10, 5, 1, 6, 9 },
        new [] { 7, 2, 6, 10, 11, 3, 1, 9, 8, 4, 5, 12 },
        new [] { 6, 1, 5, 9, 10, 2, 4, 12, 7, 3, 8, 11 },
        new [] { 7, 11, 8, 3, 2, 10, 12, 4, 6, 9, 5, 1 },
        new [] { 6, 10, 7, 2, 1, 9, 11, 3, 5, 12, 8, 4 },
        new [] { 5, 9, 6, 1, 4, 12, 10, 2, 8, 11, 7, 3 },
        new [] { 8, 12, 5, 4, 3, 11, 9, 1, 7, 10, 6, 2 },
    };

    static void AddAll(IList<int> colors)
    {
        foreach (var combination in combinations)
        {
            int result = combination.Sum(edge => 13 * colors[edge - 1]);

            set.Add(result);
        }
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var sides = Console.ReadLine().Split().Select(int.Parse).ToArray();


        new Permutator<int>(sides).Permutation(AddAll);

        Console.WriteLine(set.Count);
    }
}

/*
 * 1234 5678 9ABC
 * 4123 8567 C9AB
 * 3412 7856 BC9A
 * 2341 6785 ABC9
 * 
 * 37B8 42AC 1695
 * 26A7 319B 45C8
 * 1596 24CA 38B7
 * 48C5 13B9 27A6
 * 
 * BA9C 8765 3214
 * A9CB 7658 2143
 * 9CBA 6587 1432
 * CBA9 5876 4321
 * 
 * 9615 CA24 B738
 * C548 B913 A627
 * B837 AC42 9516
 * A726 9B31 C845
 * 
 * 548C 913B 627A
 * 837B C42A 5169
 * 726A B319 845C
 * 6159 A24C 738B
 * 
 * 7B83 2AC4 6951
 * 6A72 19B3 5C84
 * 5961 4CA2 8B73
 * 8C54 3B91 7A62
 */