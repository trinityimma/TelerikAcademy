using System;

class Program
{
    static void Check(int[] arr, int k)
    {
        for (int i = 0; i <= k; i++) Console.Write(arr[i] + 1 + (i == k ? "\n" : " "));
    }

    static void Variation(int[] arr, bool[] used, int k, int i)
    {
        if (i > k)
        {
            Check(arr, k);
            return;
        }

        for (int j = 0; j < arr.Length; j++)
        {
            if (used[j]) continue;

            used[j] = true;
            arr[i] = j;

            Variation(arr, used, k, i + 1);
            used[j] = false;
        }
    }

    static void Main()
    {
        int[] arr = new int[int.Parse(Console.ReadLine())];

        bool[] used = new bool[arr.Length];
        Variation(arr, used, arr.Length - 1, 0);
    }
}
