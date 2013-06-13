using System;
using System.Collections.Generic;

public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
{
    static void Merge(IList<T> collection, IList<T> temp, int left, int middle, int right)
    {
        int leftIndex = left;
        int middleIndex = middle + 1;
        int tempIndex = left;

        // For both arrays
        while (leftIndex <= middle && middleIndex <= right)
        {
            if (collection[leftIndex].CompareTo(collection[middleIndex]) < 0)
                temp[tempIndex++] = collection[leftIndex++];

            else temp[tempIndex++] = collection[middleIndex++];
        }

        // Copy items left from first array
        while (leftIndex <= middle)
            temp[tempIndex++] = collection[leftIndex++];

        // Or from second array
        while (middleIndex <= right)
            temp[tempIndex++] = collection[middleIndex++];

        // Save to the original array
        for (leftIndex = left; leftIndex <= right; leftIndex++)
            collection[leftIndex] = temp[leftIndex];
    }

    static void MergeSort(IList<T> collection, IList<T> temp, int left, int right)
    {
        if (left >= right) return;

        // Split in two
        int middle = left + (right - left) / 2;

        MergeSort(collection, temp, left, middle);
        MergeSort(collection, temp, middle + 1, right);

        // And merge the sorted halves
        Merge(collection, temp, left, middle, right);
    }

    public void Sort(IList<T> collection)
    {
        MergeSort(collection, new T[collection.Count], 0, collection.Count - 1);
    }
}
