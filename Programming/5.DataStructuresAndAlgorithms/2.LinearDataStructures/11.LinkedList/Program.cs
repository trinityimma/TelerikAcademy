using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var list = new LinkedList<int>();

        list.AddLast(1);
        Console.WriteLine(list);

        list.AddLast(2);
        Console.WriteLine(list);

        list.AddLast(3);
        Console.WriteLine(list);

        list.AddFirst(-1);
        Console.WriteLine(list);

        list.AddFirst(-2);
        Console.WriteLine(list);

        list.AddFirst(-3);
        Console.WriteLine(list);

        Console.WriteLine("Remove First: {0}", list.RemoveFirst().Value);
        Console.WriteLine("Remove Last: {0}", list.RemoveLast().Value);
        Console.WriteLine(list);

        Console.WriteLine("Min: {0}; Max: {1}", list.Min(), list.Max());
        Console.WriteLine("Contains 2: {0}", list.Contains(2));
        Console.WriteLine("Count: {0}", list.Count);
    }
}
