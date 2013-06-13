using System;
using System.Collections.Generic;

public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
{
    private static readonly Random random = new Random();

    private static void Swap(IList<T> collection, int i, int j)
    {
        T prev = collection[i];
        collection[i] = collection[j];
        collection[j] = prev;
    }

    private static int Partition(IList<T> collection, int l, int r)
    {
        Swap(collection, random.Next(l, r + 1), r);
        T pivot = collection[r];
        int i = l;

        for (int j = l; j < r; j++)
            if (collection[j].CompareTo(pivot) < 0)
                Swap(collection, i++, j);

        Swap(collection, i, r);

        return i;
    }

    private static void QuickSort(IList<T> collection, int l, int r)
    {
        if (l >= r) return;

        int q = Partition(collection, l, r);

        QuickSort(collection, l, q - 1);
        QuickSort(collection, q + 1, r);
    }

    public void Sort(IList<T> collection)
    {
        QuickSort(collection, 0, collection.Count - 1);
    }
}
