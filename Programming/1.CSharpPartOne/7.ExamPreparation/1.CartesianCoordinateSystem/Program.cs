using System;

class Program
{
    static void Main()
    {
        decimal x = decimal.Parse(Console.ReadLine());
        decimal y = decimal.Parse(Console.ReadLine());

        int q = 0;
        if (x >  0 && y >  0) q = 1;
        if (x <  0 && y >  0) q = 2;
        if (x <  0 && y <  0) q = 3;
        if (x >  0 && y <  0) q = 4;
        if (x == 0 && y != 0) q = 5;
        if (x != 0 && y == 0) q = 6;

        Console.WriteLine(q);
    }
}
