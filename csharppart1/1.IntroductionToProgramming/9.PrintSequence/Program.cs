// Write a program that prints the first 10 members of the sequence: 2, -3, 4,
// -5, 6, -7, ...

using System;

class Program
{
    static void Main()
    {
        for (int i = 2, j = 1; i < 12; i++, j *= -1)
        {
            Console.WriteLine(i * j);
        }
    }
}
