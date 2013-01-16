using System;

class Program
{
    static bool IsLeap(int year)
    {
        return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
    }

    static void Main()
    {
        Console.WriteLine(IsLeap(2100));
    }
}
