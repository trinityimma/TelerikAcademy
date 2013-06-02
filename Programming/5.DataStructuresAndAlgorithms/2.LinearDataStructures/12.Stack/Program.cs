using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var stack = new Stack<int>();

        stack.Push(1);
        Console.WriteLine(stack);

        stack.Push(2);
        Console.WriteLine(stack);

        stack.Push(3);
        Console.WriteLine(stack);

        Console.WriteLine("Last: {0}", stack.Peek());

        Console.WriteLine("Count: {0}", stack.Count);
        Console.WriteLine("Contains 2: {0}", stack.Contains(2));

        Console.WriteLine("Capacity: {0}", stack.Capacity);
        stack.TrimExcess();
        Console.WriteLine("Capacity: {0}", stack.Capacity);

        while (stack.Count != 0)
            Console.WriteLine("Pop: {0}", stack.Pop());

        Console.WriteLine("Count: {0}", stack.Count);

        try
        {
            stack.Clear();
            stack.Pop();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            stack.Clear();
            stack.Peek();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
