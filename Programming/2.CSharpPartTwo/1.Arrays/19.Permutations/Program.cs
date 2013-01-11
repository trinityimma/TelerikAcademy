using System;

class Program
{
    static void Check(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++) Console.Write(arr[i] + 1 + (i == arr.Length - 1 ? "\n" : " "));
    }

    static void Variation(int[] arr, bool[] used, int n, int i)
    {
        if (i == arr.Length)
        {
            Check(arr);
            return;
        }

        for (int j = 0; j < n; j++)
        {
            if (used[j]) continue;

            arr[i] = j;
            used[j] = true;

            Variation(arr, used, n, i + 1);
            used[j] = false;
        }
    }

    static void Main()
    {
        int[] arr = new int[int.Parse(Console.ReadLine())];

        bool[] used = new bool[arr.Length];
        Variation(arr, used, arr.Length, 0);
    }
}
