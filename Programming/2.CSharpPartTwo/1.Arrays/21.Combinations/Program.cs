using System;

class Program
{
    static void Check(int[] arr, int k)
    {
        for (int i = 0; i <= k; i++) Console.Write(arr[i] + 1 + (i == k ? "\n" : " "));
    }

    static void Combination(int[] arr, int k, int i, int next)
    {
        if (i > k) return;

        for (int j = next; j < arr.Length; j++)
        {
            arr[i] = j;

            if (i == k) Check(arr, k);

            Combination(arr, k, i + 1, j + 1);
        }
    }

    static void Main()
    {
        int[] arr = new int[int.Parse(Console.ReadLine())];
        int k = int.Parse(Console.ReadLine());

        Combination(arr, k - 1, 0, 0);
    }
}
