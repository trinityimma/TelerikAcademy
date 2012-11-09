// Write a boolean expression for finding if the bit 3 (counting from 0) of a
// given integer is 1 or 0.

using System;

class Program
{
    static void Main()
    {
        int a = 8;
        int thirdBit = (a >> 3) & 1;
        bool isOne = thirdBit == 1;
        Console.WriteLine("The third bit of {0} is {1}", a, thirdBit);
        Console.WriteLine("isOne: {0}", isOne);
    }
}
