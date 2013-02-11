using System;
using System.Text.RegularExpressions;

class Program
{
    static int[] arr;

    static int maxJumps = 0;

    static void PrintArray(int[] arr)
    {
#if DEBUG
        for (int i = 0; i < arr.Length; i++)
            Console.Write(arr[i] + (i == arr.Length - 1 ? "\n" : " "));
#endif
    }

    static void Input()
    {
        string[] items = Regex.Split(Console.ReadLine(), ", ");
        arr = new int[items.Length];

        for (int i = 0; i < arr.Length; i++)
            arr[i] = int.Parse(items[i]);
    }

    static void CountJumps()
    {
        bool[,] dp = new bool[arr.Length, arr.Length];

        for (int step = 1; step < arr.Length; step++)
        {
            for (int position = 0; position < arr.Length; position++)
            {
                if (dp[position, step]) continue; // If not visited

                int currentMaxJumps = 1;

                for (int i = (position + step) % arr.Length; i != position; currentMaxJumps++)
                {
                    int next = (i + step) % arr.Length;

                    if (!(arr[next] > arr[i])) break;

                    dp[i, step] = true; // Mark as visited

                    i = next;
                }

                if (maxJumps < currentMaxJumps) maxJumps = currentMaxJumps;
            }
        }
    }

    static void Output()
    {
        Console.WriteLine(maxJumps);
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input2.txt"));
#endif
        Input();

        PrintArray(arr);

        CountJumps();

        Output();
    }
}
