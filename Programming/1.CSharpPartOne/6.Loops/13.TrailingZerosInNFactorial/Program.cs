using System;

class Program
{
    static void Main()
    {
        int n = 50000;
        int r = 0;

        for (int i = 5; i <= n; i *= 5) r += n / i;

        Console.WriteLine(r);
    }
}
