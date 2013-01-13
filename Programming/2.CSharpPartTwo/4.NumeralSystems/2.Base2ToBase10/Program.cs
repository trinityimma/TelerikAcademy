using System;

class Program
{
    static int GetNumber(string s, int i)
    {
        return s[i] - '0';
    }

    static int Base2ToBase10(string b)
    {
        int d = 0;

        for (int i = b.Length - 1, p = 1; i >= 0; i--, p *= 2)
            d += GetNumber(b, i) * p;

        return d;
    }

    static void Main()
    {
        Console.WriteLine(Base2ToBase10("11111101"));
    }
}
