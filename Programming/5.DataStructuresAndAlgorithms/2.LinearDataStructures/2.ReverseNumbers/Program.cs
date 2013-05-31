using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var numbers = new Stack<int>();

        for (string line = null; (line = Console.ReadLine()) != string.Empty; )
            numbers.Push(int.Parse(line));

        Console.WriteLine(string.Join(" ", numbers));
    }
}
