using System;
using System.Text;

public static class StringBuilderSubString
{
    public static StringBuilder SubString(this StringBuilder input, int index, int length)
    {
        StringBuilder subString = new StringBuilder();

        if (index + length >= input.Length + 1)
        {
            throw new ArgumentOutOfRangeException("Out of range");
        }

        int endIndex = index + length;

        for (int i = index; i < endIndex; i++)
        {
            subString.Append(input[i]);
        }

        return subString;
    }
}

public class Program
{
    static void Main()
    {
        StringBuilder testing = new StringBuilder();
        testing.AppendLine("SOME words");
        Console.WriteLine(testing.SubString(5, 5).ToString());
    }
}