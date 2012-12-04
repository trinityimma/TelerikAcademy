using System;

class Program
{
    static void Main()
    {
        int n = 4, x = 2;
        double sum = 1, current = 1;
        for (double i = 1; i <= n; i++) sum += current *= i / x;
    }
}
