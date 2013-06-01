using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = { 2, 3, 2, 3, 2, 3, 4, 3, 3 };

        int? majorityElement = null;
        int stack = 0;

        foreach (int n in numbers)
        {
            if (stack == 0) majorityElement = n;
            stack += (n == majorityElement) ? 1 : -1;
        }

        int count = numbers.Count(n => n == majorityElement);
        if (!(count > (numbers.Length / 2)))
            majorityElement = null;

        Console.WriteLine(majorityElement);
    }
}
