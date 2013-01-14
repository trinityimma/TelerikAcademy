using System;

class Program
{
    static void Main()
    {
        int n = 5;
        int min = int.MaxValue;
        int max = int.MinValue;

        // NOTE: There exists an algorithm with complexity of O(3n/2)
        while (n-- != 0)
        {
            int number = int.Parse(Console.ReadLine());

            min = Math.Min(number, min);
            max = Math.Max(number, max);
        }
    }
}
