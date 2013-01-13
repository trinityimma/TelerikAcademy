using System;

class Program
{
    // GetNumber("F3", 0) -> 15, GetNumber("F3", 1) -> 3
    static int GetNumber(string s, int i)
    {
        if (s[i] >= 'A') return s[i] - 'A' + 10;
        else return s[i] - '0';
    }

    static int Base16ToBase10(string h)
    {
        int d = 0;

        for (int i = h.Length - 1, p = 1; i >= 0; i--, p *= 16)
            d += GetNumber(h, i) * p;

        return d;
    }

    static void Main()
    {
        Console.WriteLine(Base16ToBase10("FD"));
    }
}
