using System;

class Program
{
    static void Main()
    {
        int n = 10;
        double number = 1;
        for (int i = 1; i < n; i++) number *= ((4 * i - 2) / (i + 1.0));
        Console.WriteLine(number);
    }
}
