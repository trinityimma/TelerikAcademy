using System;
using System.Text;

static class StringBuilderExtensions
{
    public static StringBuilder Substring(this StringBuilder str, int startIndex, int length)
    {
        return new StringBuilder(str.ToString(startIndex, length));
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine(new StringBuilder("0123456").Substring(4, 3));
    }
}
