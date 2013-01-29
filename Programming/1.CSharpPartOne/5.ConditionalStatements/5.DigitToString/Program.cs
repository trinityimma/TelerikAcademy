using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string[] ones = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        Console.WriteLine(ones[n]);
    }
}
