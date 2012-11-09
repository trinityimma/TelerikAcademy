// Create a program that assigns null values to an integer and to double
// variables. Try to print them on the console, try to add some values or the
// null literal to them and see the result.

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
