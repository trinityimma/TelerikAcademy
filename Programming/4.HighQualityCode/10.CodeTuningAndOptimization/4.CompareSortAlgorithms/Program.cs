using System;
using System.Linq;
using System.Diagnostics;

class Program
{
    const int IterationCount = (int)1.6E7;

    static readonly Stopwatch stopwatch = new Stopwatch();

    static void DisplayExecutionTime(string title, Action action)
    {
        Console.Write("{0, -20}", title);
        stopwatch.Restart();

        action();

        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed);
    }

    static void Main()
    {
        int[] arr = { -1, 2, -3, 4, 4, -5, 6, -7 };

        QuickSort(arr);
        Print(arr);

        SelectionSort(arr);
        Print(arr);

        InsertionSort(arr);
        Print(arr);
    }

    static readonly Random random = new Random(0);

    static void Print<T>(T[] arr)
    {
        Console.WriteLine(String.Join(" ", arr));
    }

    static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    static int Partition<T>(T[] arr, int left, int right) where T : IComparable<T>
    {
        int randomIndex = random.Next(left, right + 1);
        Swap(ref arr[randomIndex], ref arr[right]);
        T pivot = arr[right];

        int smallerIndex = left;

        for (int i = left; i < right; i++)
            if (arr[i].CompareTo(pivot) < 0)
                Swap(ref arr[smallerIndex++], ref arr[i]);

        Swap(ref arr[smallerIndex], ref arr[right]);

        return smallerIndex;
    }

    static void QuickSort<T>(T[] arr, int left, int right) where T : IComparable<T>
    {
        if (left >= right) return;

        int q = Partition(arr, left, right);

        QuickSort(arr, left, q - 1);
        QuickSort(arr, q + 1, right);
    }

    static void QuickSort(int[] arr)
    {
        QuickSort(arr, 0, arr.Length - 1);
    }

    static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int min = i;

            for (int j = i + 1; j < arr.Length; j++)
                if (arr[j].CompareTo(arr[min]) < 0)
                    min = j;

            Swap(ref arr[min], ref arr[i]);
        }
    }

    private static int BinarySearch<T>(T[] arr, int i) where T : IComparable<T>
    {
        int left = 0;
        int right = i;

        while (left < right)
        {
            int middle = (left + right) / 2;

            if (arr[i].CompareTo(arr[middle]) >= 0)
                left = middle + 1;

            else right = middle;
        }

        return left;
    }

    static void InsertionSort<T>(T[] arr) where T : IComparable<T>
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int insertionIndex = BinarySearch(arr, i);

            T currentValue = arr[i];
            Array.Copy(arr, insertionIndex, arr, insertionIndex + 1, i - insertionIndex);
            arr[insertionIndex] = currentValue;
        }
    }
}
