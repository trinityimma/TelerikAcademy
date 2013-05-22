using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        LinkedList<int> numbers = new LinkedList<int>(new int[] { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 });

        Dictionary<int, int> groupByOccurence = new Dictionary<int, int>();

        foreach (int number in numbers)
        {
            if (!groupByOccurence.ContainsKey(number))
                groupByOccurence[number] = 0;

            groupByOccurence[number]++;
        }

        Console.WriteLine(string.Join(" ", groupByOccurence));

        for (var node = numbers.First; node != null; )
        {
            var next = node.Next;

            if (groupByOccurence[node.Value] % 2 == 1)
                numbers.Remove(node);

            node = next;
        }

        Console.WriteLine(string.Join(" ", numbers));
    }
}
