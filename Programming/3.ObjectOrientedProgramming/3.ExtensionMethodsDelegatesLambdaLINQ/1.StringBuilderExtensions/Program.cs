using System;
using System.Text;

static class StringBuilderExtensions
{
    public static StringBuilder SubString(this StringBuilder str, int startIndex, int length)
    {
        StringBuilder result = new StringBuilder();

        if (startIndex + length > str.Length)
            throw new ArgumentOutOfRangeException();

        for (int i = 0; i < length; i++)
            result.Append(str[startIndex + i]);

        return result;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine(new StringBuilder("0123456").SubString(4, 3));
    }
}
