// Write an expression that checks for given integer if its third digit
// (right-to-left) is 7. E. g. 1732 -> true.

using System;

class Program
{
    static void Main()
    {
        int a = 1732;
        bool isSeven = ((a / 100) % 10) == 7;
    }
}
