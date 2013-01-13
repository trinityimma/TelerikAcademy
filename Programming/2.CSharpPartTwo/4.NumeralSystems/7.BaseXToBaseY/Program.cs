using System;

class Program
{
    // GetChar(15) -> 'F'
    static char GetChar(int i)
    {
        if (i >= 10) return (char)('A' + i - 10);
        else return (char)('0' + i);
    }

    // GetNumber("587", 2) -> 7
    static int GetNumber(string s, int i)
    {
        if (s[i] >= 'A') return s[i] - 'A' + 10;
        else return s[i] - '0';
    }

    // Exercise 1
    static string Base10ToBaseX(int d, int x)
    {
        string h = String.Empty;

        for (; d != 0; d /= x) h = GetChar(d % x) + h;

        return h;
    }

    // Exercise 2
    static int BaseXToBase10(string h, int x)
    {
        int d = 0;

        for (int i = h.Length - 1, p = 1; i >= 0; i--, p *= x)
            d += GetNumber(h, i) * p;

        return d;
    }

    static string BaseXToBaseY(string n, int x, int y)
    {
        return Base10ToBaseX(BaseXToBase10(n, x), y); // Use base 10 as proxy
    }

    static void Main()
    {
        Console.WriteLine(BaseXToBaseY("2273417", 8, 36));
    }
}
