using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(Math.Abs(5.00000001 - 5.00000003) < 1E-6);
    }
}
