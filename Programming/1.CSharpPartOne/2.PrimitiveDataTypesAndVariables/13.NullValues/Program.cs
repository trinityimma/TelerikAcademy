using System;

class Program
{
    static void Main()
    {
        int? a = null;
        double? b = null;
        Console.WriteLine("a: {0}, b: {1}", a, b);

        a += null;
        b += 3.1415926;
        Console.WriteLine("a: {0}, b: {1}", a, b);
    }
}
