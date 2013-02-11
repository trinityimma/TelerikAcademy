using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static int ConvertDigit(string durankulakDigit)
    {
        if (durankulakDigit.Length == 1) return (durankulakDigit[0] - 'A'); // [A-Z]
        else return (durankulakDigit[0] - 'a' + 1) * 26 + ConvertDigit(durankulakDigit.Substring(1)); // [a-z] + [A-Z]
    }

    static long ConvertNumber(string durankulakNumber)
    {
        // Make reversed durankulak digits
        Stack<string> durankulakDigits = new Stack<string>();

        foreach (Match digit in Regex.Matches(durankulakNumber, "[a-z]?[A-Z]"))
            durankulakDigits.Push(digit.Value);

        // Make decimal number
        long decimalNumber = 0;

        for (long power = 1; durankulakDigits.Count != 0; power *= 168)
            decimalNumber += ConvertDigit(durankulakDigits.Pop()) * power;

        return decimalNumber;
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input1.txt"));
#endif

        Console.WriteLine(ConvertNumber(Console.ReadLine()));
    }
}
