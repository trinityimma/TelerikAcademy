using System;

class Program
{
    static void Main()
    {
        int a = 5, b = 10;

        a ^= b;
        b ^= a;
        a ^= b;

        Console.WriteLine("a:{0} b:{1}", a, b);
    }
}
