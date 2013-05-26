using System;
using System.Linq;

class Program
{
    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int sum = 0;
        int i = 0;

        for (; i < arr.Length; i++)
        {
            if (sum + arr[i] > n)
                break;

            sum += arr[i];
        }

        Console.WriteLine(i);
    }
}
