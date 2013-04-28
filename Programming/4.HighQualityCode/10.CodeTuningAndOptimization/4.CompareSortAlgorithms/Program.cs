using System;
using System.Linq;
using System.Diagnostics;

static class Program
{
    static readonly Stopwatch stopwatch = new Stopwatch();

    static void DisplayExecutionTime(string title, Action action)
    {
        Console.Write("{0, -25}", title);
        stopwatch.Restart();

        action();

        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed);
    }

    static void Shuffle<T>(this T[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i--)
            Swap(ref arr[i], ref arr[random.Next(i + 1)]);
    }

    static void Main()
    {
        int[] arr = Enumerable.Range(0, (int)3E4).ToArray();

        {
            DisplayExecutionTime("QuickSort sorted", () =>
               QuickSort(arr)
                );

            DisplayExecutionTime("SelectionSort sorted", () =>
                SelectionSort(arr)
            );

            DisplayExecutionTime("InsertionSort sorted", () =>
                InsertionSort(arr)
            );
        }

        Console.WriteLine();

        {
            arr = arr.Reverse().ToArray();

            DisplayExecutionTime("QuickSort reversed", () =>
                QuickSort(arr)
            );

            DisplayExecutionTime("SelectionSort reversed", () =>
                SelectionSort(arr)
            );

            DisplayExecutionTime("InsertionSort reversed", () =>
                InsertionSort(arr)
            );
        }

        Console.WriteLine();

        {
            arr.Shuffle();

            DisplayExecutionTime("QuickSort shuffled", () =>
                QuickSort(arr)
            );

            DisplayExecutionTime("SelectionSort shuffled", () =>
                SelectionSort(arr)
            );

            DisplayExecutionTime("InsertionSort shuffled", () =>
                InsertionSort(arr)
            );
        }
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

        int middle = Partition(arr, left, right);

        QuickSort(arr, left, middle - 1);
        QuickSort(arr, middle + 1, right);
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
            int middle = left + (right - left) / 2;

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
