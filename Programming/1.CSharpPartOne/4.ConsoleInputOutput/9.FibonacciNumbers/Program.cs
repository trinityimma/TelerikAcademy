using System;

class Program
{
    static void Main()
    {
        decimal n = 100, a = 0, b = 1;
        while (n-- != 0)
        {
            Console.WriteLine(a);
            b = a + b;
            a = b - a;
        }
    }
}
