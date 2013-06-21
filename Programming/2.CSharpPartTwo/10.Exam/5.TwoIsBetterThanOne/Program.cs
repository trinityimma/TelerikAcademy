using System;
using System.Collections.Generic;

class Program
{
    // 1
    static long a, b;
    static int p;

    // 2
    static List<int> numbers = new List<int>();
    static long luckyNumbers;
    static int smallestElement;

    static void Input()
    {
        // 1
        string[] parts = Console.ReadLine().Split();
        a = long.Parse(parts[0]);
        b = long.Parse(parts[1]);

        // 2
        foreach (var item in Console.ReadLine().Split(','))
            numbers.Add(int.Parse(item));

        p = int.Parse(Console.ReadLine());
    }

    static void SolveOne()
    {
        Generate(0, 0);
    }

    static void Generate(int start, long current)
    {
        if (current >= a && current <= b && IsPalindromeNumber(current))
            luckyNumbers++;

        if (start == 19)
        {
            return;
        }

        Generate(start + 1, current * 10 + 3);
        Generate(start + 1, current * 10 + 5);
    }

    static bool IsPalindromeNumber(long number)
    {
        string numberAsString = number.ToString();

        for (int i = 0; i < numberAsString.Length / 2; i++)
            if (numberAsString[i] != numberAsString[numberAsString.Length - i - 1])
                return false;

        return true;
    }

    static void SolveTwo()
    {
        numbers.Sort();

        smallestElement = numbers[(int)(numbers.Count * (p / 100.01))];
    }

    static void Output()
    {
        Console.WriteLine(luckyNumbers);
        Console.WriteLine(smallestElement);
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input1.txt"));
#endif

        Input();

        SolveOne();

        SolveTwo();

        Output();
    }
}
