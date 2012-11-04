using System;

class Program
{
    static bool compare(double a, double b)
    {
        double precision = 1E-6;
        return Math.Abs(a - b) < precision;
    }

    static void Main()
    {
        Console.WriteLine(compare(5.3, 6.01));
        Console.WriteLine(compare(5.00000001, 5.00000003));
    }
}
