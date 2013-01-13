using System;

class Program
{
    static String[] digitNames = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    static string GetDigitName(int n)
    {
        return digitNames[n];
    }

    static int GetLastDigit(int n)
    {
        return n % 10;
    }

    static void Main()
    {
        Console.WriteLine(GetDigitName(GetLastDigit(1337)));
    }
}
