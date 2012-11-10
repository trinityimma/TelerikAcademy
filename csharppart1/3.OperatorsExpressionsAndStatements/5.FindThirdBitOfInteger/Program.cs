// Write a boolean expression for finding if the bit 3 (counting from 0) of a
// given integer is 1 or 0.

using System;

class Program
{
    static void Main()
    {
        int a = 8;
        bool isOne = ((a >> 3) & 1) == 1;
    }
}
