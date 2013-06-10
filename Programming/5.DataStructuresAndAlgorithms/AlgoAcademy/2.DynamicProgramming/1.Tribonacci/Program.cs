using System;
using System.Linq;

class Program
{
    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        long t1 = input[0];
        long t2 = input[1];
        long t3 = input[2];

        int n = input[3];

        for (int i = 0; i < n - 1; i++)
        {
            long t4 = t1 + t2 + t3;
            t1 = t2;
            t2 = t3;
            t3 = t4;
        }

        Console.WriteLine(t1);
    }
}
