using System;
using System.Collections.Generic;

static class Program
{
    static LinkedList<T> Filter<T>(this LinkedList<T> linkedList, Predicate<T> predicate)
    {
        for (var node = linkedList.First; node != null; )
        {
            var next = node.Next;

            if (!predicate(node.Value))
                linkedList.Remove(node);

            node = next;
        }

        return linkedList;
    }

    static void Main()
    {
        LinkedList<int> numbers = new LinkedList<int>(new int[] { 19, -10, 12, -6, -3, 34, -2, 5 });

        numbers.Filter(n => n > 0);

        Console.WriteLine(string.Join(" ", numbers));
    }
}
