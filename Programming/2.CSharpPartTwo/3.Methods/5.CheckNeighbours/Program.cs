using System;

class Program
{
    static bool IsInside(int[] arr, int i)
    {
        return 0 <= i && i < arr.Length;
    }

    static bool IsBigger(int[] arr, int i, int j)
    {
        return IsInside(arr, j) ? arr[i] > arr[j] : true;
    }

    static bool IsBiggerThanNeighbours(int[] arr, int i)
    {
        return IsBigger(arr, i, i - 1) && IsBigger(arr, i, i + 1);
    }

    static void Main()
    {
        int[] arr = { 1, 5, 2, 3, 3, 3, 4, 3, 4, 4, 5 };

        for (int i = 0; i < arr.Length; i++) Console.WriteLine(arr[i] + ": " + IsBiggerThanNeighbours(arr, i));
    }
}
