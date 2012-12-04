using System;

class Program
{
    static void Main()
    {
        int n = 5, p = 2, v = 0;
        n = (v == 0) ? (n & ~(1 << p)) : (n | 1 << p);
    }
}
