using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<int> numbers = new Queue<int>();

        int s = 2;
        numbers.Enqueue(s);

        while (numbers.Count < 50)
        {
            numbers.Enqueue(s + 1);
            numbers.Enqueue(2 * s + 1);
            numbers.Enqueue(s + 2);

            s++;
        }

        Console.WriteLine(string.Join(" ", numbers.Take(50)));
    }
}
