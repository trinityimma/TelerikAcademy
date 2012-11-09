// Write an expression that checks for given integer if its third digit
// (right-to-left) is 7. E. g. 1732 -> true.

using System;

class Program
{
    static void Main()
    {
        int a = 1732;
        int thirdDigit = (a / 100) % 10;
        bool isSeven = thirdDigit == 7;
        Console.WriteLine("The third digit of {0} is {1}", a, thirdDigit);
        Console.WriteLine("Is it seven: {0}", isSeven);
    }
}
