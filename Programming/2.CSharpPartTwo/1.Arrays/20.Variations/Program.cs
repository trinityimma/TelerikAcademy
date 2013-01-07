using System;

class Program
{
    static void Check(int[] arr, int k)
    {
        for (int i = 0; i <= k; i++) Console.Write(arr[i] + 1 + (i == k ? "\n" : " "));
    }

    static void Variation(int[] arr, int k, int i)
    {
        if (i > k)
        {
            Check(arr, k);
            return;
        }

        for (int j = 0; j < arr.Length; j++)
        {
            arr[i] = j;

            Variation(arr, k, i + 1);
        }
    }

    static void Main()
    {
        int[] arr = new int[int.Parse(Console.ReadLine())];
        int k = int.Parse(Console.ReadLine());

        Variation(arr, k - 1, 0);
    }
}
