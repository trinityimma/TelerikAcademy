using System;

class Program
{
    static int ReadNumber(int start, int end)
    {
        int n = int.Parse(Console.ReadLine());

        if (!(start < n && n < end)) throw new ArgumentOutOfRangeException();

        return n;
    }

    static void Main()
    {
        int min = 1, max = 100;

        for (int i = 0; i < 10; i++) min = ReadNumber(min, max);
    }
}
