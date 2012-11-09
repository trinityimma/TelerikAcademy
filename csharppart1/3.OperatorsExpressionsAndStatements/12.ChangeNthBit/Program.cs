using System;

class Program
{
    static void Main()
    {
        int n = 5;
        int p = 2;
        int v = 0;
        int r = (v == 0) ? (n & ~(1 << p)) : (n | 1 << p);
        Console.WriteLine("Changing bit number {0} of {1} to {2}: {3}", p, n, v, r);
    }
}
