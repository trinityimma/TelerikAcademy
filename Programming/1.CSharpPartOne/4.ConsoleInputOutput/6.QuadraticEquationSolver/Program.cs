using System;

class Program
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int d = b * b - 4 * a * c;
        Console.WriteLine((-b + Math.Sqrt(d)) / (2 * a));
        Console.WriteLine((-b - Math.Sqrt(d)) / (2 * a));
    }
}
