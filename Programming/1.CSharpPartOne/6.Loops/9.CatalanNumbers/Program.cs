using System;

class Program
{
    static void Main()
    {
        int n = 10; // 0, 1, 2 ...
        double number = 1;

        for (int i = 2; i <= n; i++)
            number *= (4 * i - 2) / (1.0 + i);

        Console.WriteLine(number);
    }
}
