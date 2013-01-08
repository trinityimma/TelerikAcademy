using System;

class Program
{
    static void Swap(string[] arr, int i, int j)
    {
        if (i == j) return;
        string t = arr[i];
        arr[i] = arr[j];
        arr[j] = t;
    }

    static int Partition(string[] arr, int l, int r)
    {
        Swap(arr, new Random().Next(l, r + 1), r);
        int pivot = arr[r].Length, i = l;

        for (int j = l; j < r; j++) if (arr[j].Length <= pivot) Swap(arr, i++, j);
        Swap(arr, i, r);

        return i;
    }

    static void QuickSort(string[] arr, int l, int r)
    {
        if (l >= r) return;

        int q = Partition(arr, l, r);

        QuickSort(arr, l, q - 1);
        QuickSort(arr, q + 1, r);
    }

    static void Main()
    {
        string[] arr = { "", "1", "22", "666666", "333", "55555", "4444" };

        QuickSort(arr, 0, arr.Length - 1); // TODO: Use indices

        foreach (string item in arr) Console.WriteLine(item);
    }
}
