using System;
using System.Text;

static class Program
{
    static StringBuilder Substring(this StringBuilder str, int startIndex, int length)
    {
        return new StringBuilder(str.ToString(startIndex, length));
    }

    static void Main()
    {
        Console.WriteLine(new StringBuilder("0123456").Substring(4, 3));
    }
}
