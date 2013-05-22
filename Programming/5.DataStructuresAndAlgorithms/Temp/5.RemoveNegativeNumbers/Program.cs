using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        LinkedList<int> numbers = new LinkedList<int>(new int[] { 19, -10, 12, -6, -3, 34, -2, 5 });

        for (var node = numbers.First; node != null; )
        {
            var next = node.Next;

            if (node.Value < 0)
                numbers.Remove(node);

            node = next;
        }

        Console.WriteLine(string.Join(" ", numbers));
    }
}
