using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Stack<int> numbers = new Stack<int>();

        for (string line = null; !string.IsNullOrEmpty(line = Console.ReadLine()); )
            numbers.Push(int.Parse(line));

        Console.WriteLine(string.Join(" ", numbers));
    }
}
