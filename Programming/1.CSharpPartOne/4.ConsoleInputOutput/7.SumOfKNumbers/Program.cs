using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int sum = 0;

        while (n-- != 0) sum += int.Parse(Console.ReadLine());

        Console.WriteLine(sum);
    }
}
