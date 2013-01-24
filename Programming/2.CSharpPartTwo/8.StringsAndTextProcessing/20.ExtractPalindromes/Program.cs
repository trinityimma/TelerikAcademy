using System;
using System.Text.RegularExpressions;

class Program
{
    static bool IsPalindrome(string str)
    {
        for (int i = 0; i < str.Length / 2; i++)
            if (str[i] != str[str.Length - 1 - i])
                return false;

        return true;
    }

    static void Main()
    {
        string str = "Static void Main() ABBA, using System lamal, exe.";

        foreach (Match item in Regex.Matches(str, @"\w+"))
            if (IsPalindrome(item.Value)) Console.WriteLine(item);
    }
}
