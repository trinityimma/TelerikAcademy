using System;

class Program
{
    static void Main()
    {
        var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
        Console.WriteLine("All items before sorting:");
        Console.WriteLine(collection);

        Console.WriteLine("SelectionSorter result:");
        collection.Sort(new SelectionSorter<int>());
        Console.WriteLine(collection);

        Console.WriteLine("Quicksorter result:");
        collection.Sort(new Quicksorter<int>());
        Console.WriteLine(collection);

        Console.WriteLine("MergeSorter result:");
        collection.Sort(new MergeSorter<int>());
        Console.WriteLine(collection);

        Console.WriteLine("Linear search 101:");
        Console.WriteLine(collection.LinearSearch(101));

        Console.WriteLine("Binary search 101:");
        Console.WriteLine(collection.BinarySearch(101));

        Console.WriteLine("Shuffle:");
        collection.Shuffle();
        Console.WriteLine(collection);

        Console.WriteLine("Shuffle again:");
        collection.Shuffle();
        Console.WriteLine(collection);
    }
}
