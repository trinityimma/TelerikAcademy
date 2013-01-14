using System;

class Program
{
    static void Main()
    {
        for (int i = 2, j = 1; i < 12; i++, j *= -1)
            Console.WriteLine(i * j);
    }
}
