using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var results = new List<int>();

        var numbers = new Queue<int>();

        numbers.Enqueue(2);

        for (int i = 0; i < 50; i++)
        {
            int s = numbers.Dequeue();
            
            results.Add(s);

            numbers.Enqueue(s + 1);
            numbers.Enqueue(2 * s + 1);
            numbers.Enqueue(s + 2);
        }

        Console.WriteLine(string.Join(" ", results));
    }
}
