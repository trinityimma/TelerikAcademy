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

        var sum = Enumerable.Range(1, input[1]).ToArray();

        for (int i = 1; i < input[0]; i++)
            for (int j = 0, s = 0; j < input[1]; j++)
                sum[j] = s += sum[j];

        Console.WriteLine(sum.Sum());
    }
}
