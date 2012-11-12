using System;

class Program
{
    static void Main()
    {
        double sum = 0;
        for (int i = 1, j = 1; i < 1001; i++, j *= -1)
        {
            sum += 1.0 / i * j;
        }
        Console.WriteLine(sum);
    }
}
