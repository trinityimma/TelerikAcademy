// Write an expression that extracts from a given integer i the value of a given
// bit number b. Example: i=5; b=2 -> value=1.

using System;

class Program
{
    static void Main()
    {
        int i = 5;
        int b = 2;
        int nthBit = (i >> b) & 1;
        Console.WriteLine("Bit number {0} of {1} is {2}", b, i, nthBit);
    }
}
