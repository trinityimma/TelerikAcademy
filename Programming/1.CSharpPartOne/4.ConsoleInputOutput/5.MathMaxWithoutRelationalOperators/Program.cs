using System;

class Program
{
    static void Main()
    {
        int[] n = { int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()) };
        Console.WriteLine(n[n[0] - n[1] >> 31 & 1]); // 0 if positive, 1 if negative
    }
}
