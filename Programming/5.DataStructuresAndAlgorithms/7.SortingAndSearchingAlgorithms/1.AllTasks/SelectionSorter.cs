using System;
using System.Collections.Generic;

public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
{
    private static void Swap(IList<T> collection, int i, int j)
    {
        T prev = collection[i];
        collection[i] = collection[j];
        collection[j] = prev;
    }

    public void Sort(IList<T> collection)
    {
        for (int i = 0; i < collection.Count; i++)
        {
            int min = i;

            for (int j = i + 1; j < collection.Count; j++)
                if (collection[j].CompareTo(collection[min]) < 0)
                    min = j;

            Swap(collection, i, min);
        }
    }
}
