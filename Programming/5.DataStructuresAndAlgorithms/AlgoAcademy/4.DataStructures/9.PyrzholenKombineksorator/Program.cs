using System;
using System.Linq;

class Program
{
    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var input = Enumerable.Range(0, int.Parse(Console.ReadLine()))
            .Select(i =>
                Console.ReadLine().Split().Select(int.Parse).ToArray()
            );

        int result = 0;

        foreach (var coords in input)
        {
            result ^= Math.Abs(
                (coords[0] - coords[4]) * (coords[3] - coords[1]) -
                (coords[0] - coords[2]) * (coords[5] - coords[1])
            );
        }

        Console.WriteLine((result / 2.0).ToString("0.000000"));
    }
}
