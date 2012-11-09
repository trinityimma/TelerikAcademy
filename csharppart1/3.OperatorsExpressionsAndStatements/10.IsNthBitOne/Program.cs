// Write a boolean expression that returns if the bit at position p (counting
// from 0) in a given integer number v has value of 1. Example: v=5; p=1 ->
// false.

using System;

class Program
{
    static void Main()
    {
        int v = 5;
        int p = 1;
        int nthBit = (v >> p) & 1;
        bool isOne = nthBit == 1;
        Console.WriteLine("Bit number {0} of {1} is {2}", p, v, nthBit);
        Console.WriteLine("isOne: {0}", isOne);
    }
}
