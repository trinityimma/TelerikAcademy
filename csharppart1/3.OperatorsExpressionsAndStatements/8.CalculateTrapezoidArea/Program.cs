// Write an expression that calculates trapezoid's area by given sides a and b
// and height h.

using System;

class Program
{
    static void Main()
    {
        int a = 2;
        int b = 4;
        int h = 5;
        int area = (a + (b - a) / 2) * h;
    }
}
