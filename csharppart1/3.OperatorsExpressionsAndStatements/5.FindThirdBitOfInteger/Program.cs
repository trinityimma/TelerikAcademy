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
