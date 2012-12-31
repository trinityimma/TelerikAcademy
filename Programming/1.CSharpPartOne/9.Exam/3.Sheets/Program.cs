using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i <= 10; i++) if ((n >> i & 1) == 0) Console.WriteLine("A{0}", 10 - i);
    }
}
