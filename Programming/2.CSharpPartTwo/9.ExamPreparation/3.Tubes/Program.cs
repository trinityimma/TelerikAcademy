using System;
using System.Collections.Generic;

class Program
{
    static int N, M;

    static int best;
    static List<int> tubes = new List<int>();

    static void Input()
    {
        N = int.Parse(Console.ReadLine());
        M = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
            tubes.Add(int.Parse(Console.ReadLine()));
    }

    static int GetMaxTubes(int length)
    {
        int count = 0;

        foreach (int tube in tubes)
            count += tube / length;

        return count;
    }

    static void BinarySearch()
    {
        int l = 0;
        int r = (int)2e9;

        while (l < r)
        {
            int m = (l + r) / 2;

            if (GetMaxTubes(m) < M) r = m;
            else l = m + 1;
        }

        if (GetMaxTubes(l) < M) l--;

        best = l;
    }

    static void Output()
    {
        Console.WriteLine(best);
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt")); // Runs locally only
#endif

        Input();

        BinarySearch();

        Output();
    }
}
