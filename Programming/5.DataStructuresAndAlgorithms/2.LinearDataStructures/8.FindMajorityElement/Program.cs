using System;
using System.Linq;

class Program
{
    // Moore's Voting Algorithm
    static void Main()
    {
        int[] numbers = { 2, 3, 2, 3, 2, 3, 4, 3, 3 };

        int? majorityElement = null;
        int count = 0;

        foreach (int n in numbers)
        {
            if (count == 0) majorityElement = n;
            count += (n == majorityElement) ? 1 : -1;
        }

        count = numbers.Where(n => n == majorityElement).Count();
        if (!(count > (numbers.Length / 2)))
            majorityElement = null;

        Console.WriteLine(majorityElement);
    }
}
