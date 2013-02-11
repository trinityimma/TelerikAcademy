using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
        a = int.Parse(parts[0]);
        b = int.Parse(parts[1]);

        // 2
        foreach (var item in Regex.Split(Console.ReadLine(), ", "))
            numbers.Add(int.Parse(item));

        p = int.Parse(Console.ReadLine());
    }

    static void SolveOne()
    {
    }

    static void SolveTwo()
    {
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
