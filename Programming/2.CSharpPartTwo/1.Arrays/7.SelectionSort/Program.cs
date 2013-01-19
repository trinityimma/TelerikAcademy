using System;

class Program
{
    static void Swap(int[] arr, int i, int j)
    {
        int t = arr[i];
        arr[i] = arr[j];
        arr[j] = t;
    }

    static void Main()
    {
        int[] arr = { -1, 2, -3, 4, -5, 6, -7 };

        for (int i = 0; i < arr.Length; i++)
        {
            int min = i;

            for (int j = i + 1; j < arr.Length; j++) if (arr[j] < arr[min]) min = j;
            Swap(arr, i, min);
        }

        foreach (int item in arr) Console.WriteLine(item);
    }
}
