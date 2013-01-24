using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string str = "aaaaabbbbbcdddeeeedssaa";

        Console.WriteLine(Regex.Replace(str, @"([a-z])\1+", "$1"));
    }
}
