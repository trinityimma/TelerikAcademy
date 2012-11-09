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
