using System;
using System.Linq;
using System.Collections.Generic;

static class Program
{
    static Dictionary<T, int> GroupByOccurence<T>(IEnumerable<T> elements)
    {
        return elements.GroupBy(el => el).ToDictionary(pair => pair.Key, n => n.Count());
    }

    static LinkedList<T> Filter<T>(this LinkedList<T> linkedList, Predicate<T> predicate)
    {
        for (LinkedListNode<T> node = linkedList.First, next; node != null; node = next)
        {
            next = node.Next;

            if (!predicate(node.Value))
                linkedList.Remove(node);
        }

        return linkedList;
    }

    static void Main()
    {
        LinkedList<int> numbers = new LinkedList<int>(new int[] { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 });

        Dictionary<int, int> groupedByOccurence = GroupByOccurence(numbers);

        Console.WriteLine(string.Join(" ", groupedByOccurence));

        numbers.Filter(n => groupedByOccurence[n] % 2 == 0);

        Console.WriteLine(string.Join(" ", numbers));
    }
}
