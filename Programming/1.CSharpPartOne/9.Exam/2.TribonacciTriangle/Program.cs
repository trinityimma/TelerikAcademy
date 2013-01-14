using System;

class Program
{
    static long t0, t1, t2;

    static int current = -1;
    static long GetNextTribonacci()
    {
        current++;

        if (current == 0) return t0;
        if (current == 1) return t1;
        if (current == 2) return t2;

        else
        {
            long t3 = t0 + t1 + t2;

            t0 = t1;
            t1 = t2;
            t2 = t3;

            return t2;
        }
    }

    static void Main()
    {
        t0 = int.Parse(Console.ReadLine());
        t1 = int.Parse(Console.ReadLine());
        t2 = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        for (int row = 1; row <= n; row++)
            for (int col = 1; col <= row; col++)
                Console.Write(GetNextTribonacci() + (col == row ? "\n" : " "));
    }
}
