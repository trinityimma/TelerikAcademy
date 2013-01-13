using System;

class Program
{
    static string Base10ToBase2(int d)
    {
        string b = String.Empty;

        for (; d != 0; d /= 2) b = d % 2 + b;

        return b;
    }

    static void Main()
    {
        Console.WriteLine(Base10ToBase2(253));
    }
}
