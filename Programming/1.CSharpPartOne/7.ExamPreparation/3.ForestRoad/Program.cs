using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int x = 0, y = 0; y < 2 * n - 1; y++, x += (y < n ? 1 : -1))
            Console.WriteLine(new String('.', x) + '*' + new String('.', n - x - 1));
    }
}
