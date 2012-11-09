// Write a program that safely compares floating-point numbers with precision of
// 0.000001. Examples: (5.3 ; 6.01)  false;  (5.00000001 ; 5.00000003) -> true

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
