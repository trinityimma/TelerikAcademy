using System;
using System.Text.RegularExpressions;

class Program
{
    static string ToUpperCaseTags(string str)
    {
        return Regex.Replace(str, @"<upcase>([^<]*)</upcase>", matches => matches.Groups[1].Value.ToUpper());
    }

    static void Main()
    {
        string str = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        Console.WriteLine(ToUpperCaseTags(str));
    }
}
