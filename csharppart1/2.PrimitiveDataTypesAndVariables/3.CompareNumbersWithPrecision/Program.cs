// Write a program that safely compares floating-point numbers with precision of
// 0.000001. Examples: (5.3 ; 6.01) -> false;  (5.00000001 ; 5.00000003) -> true

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(Math.Abs(5.3 - 6.01) < 1E-6);
        Console.WriteLine(Math.Abs(5.00000001 - 5.00000003) < 1E-6);
    }
}
