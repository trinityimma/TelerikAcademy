using System;

class Program
{
    static void Main()
    {
        int n = 5, a = 0, b = 1, sum = 0;

        while (n-- != 0)
        {
            sum += a;
            b = a + b;
            a = b - a;
        }
    }
}
