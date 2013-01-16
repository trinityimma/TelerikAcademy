using System;

class Program
{
    static string Base10ToBase2(int d)
    {
        string b = String.Empty;

        for (; d != 0; d /= 2) b = d % 2 + b;

        return b;
    }

    static string RecursionBase10ToBase2(int d, string b = "")
    {
        return d == 0 ? b : RecursionBase10ToBase2(d / 2, d % 2 + b);
    }

    static void Main()
    {
        Console.WriteLine(Base10ToBase2(253));
        Console.WriteLine(RecursionBase10ToBase2(253));
    }
}
