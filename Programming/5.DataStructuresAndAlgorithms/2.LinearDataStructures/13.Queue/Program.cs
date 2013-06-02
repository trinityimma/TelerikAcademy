using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var queue = new Queue<int>();

        queue.Enqueue(1);
        Console.WriteLine(queue);

        queue.Enqueue(2);
        Console.WriteLine(queue);

        queue.Enqueue(3);
        Console.WriteLine(queue);

        Console.WriteLine("First: {0}", queue.Peek());

        Console.WriteLine("Count: {0}", queue.Count);
        Console.WriteLine("Contains 2: {0}", queue.Contains(2));

        while (queue.Count != 0)
            Console.WriteLine("Dequeue: {0}", queue.Dequeue());

        Console.WriteLine("Count: {0}", queue.Count);

        try
        {
            queue.Clear();
            queue.Dequeue();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            queue.Clear();
            queue.Peek();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
