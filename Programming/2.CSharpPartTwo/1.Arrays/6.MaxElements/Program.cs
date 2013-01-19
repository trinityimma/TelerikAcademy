using System;

class Program
{
    // Swap two elements in an array
    static void Swap(int[] arr, int i, int j)
    {
        int t = arr[i];
        arr[i] = arr[j];
        arr[j] = t;
    }

    // Randomized quicksort partition of array
    static int Partition(int[] arr, int l, int r)
    {
        Swap(arr, new Random().Next(l, r + 1), r);
        int pivot = arr[r], i = l;

        for (int j = l; j < r; j++) if (arr[j] <= pivot) Swap(arr, i++, j);
        Swap(arr, i, r);

        return i;
    }

    // Find k-th ordered statistic in an array
    static int Select(int[] arr, int l, int r, int k)
    {
        if (l == r) return arr[l];

        int q = Partition(arr, l, r);
        int p = q - l + 1;

        if (k == p) return arr[q];
        else if (k < p) return Select(arr, l, q - 1, k);
        else return Select(arr, q + 1, r, k - p);
    }

    // Find the k-th biggest element and print all bigger or equal items
    static void Main()
    {
        int[] arr = new int[int.Parse(Console.ReadLine())];
        int k = int.Parse(Console.ReadLine());
        for (int i = 0; i < arr.Length; i++) arr[i] = int.Parse(Console.ReadLine());

        int x = Select(arr, 0, arr.Length - 1, arr.Length - k + 1);
        foreach (int item in arr) if (item >= x) Console.WriteLine(item);
    }
}
