using System;

class Program
{
    static void Main()
    {
        int a = 2;
        int b = 4;
        int h = 5;
        int area = (a + (b - a) / 2) * h;
        Console.WriteLine("a: {0}, b: {1}, h: {2}, area: {3}", a, b, h, area);
    }
}
