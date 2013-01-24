using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string str = "C#   is not C++, not PHP and not Delphi!  Test 1, 2,3.";

        string regex = @"\s+|,\s*|\.\s*|!\s*";
        List<string> words = new List<string>();      // Stack
        List<string> separators = new List<string>(); // Queue

        foreach (string word in Regex.Split(str, regex))
            words.Add(word);

        foreach (Match separator in Regex.Matches(str, regex))
            separators.Add(separator.Value);

        for (int i = 0; i < separators.Count; i++)
            Console.Write(words[words.Count - 2 - i] + separators[i]); // Without the last empty word

        Console.WriteLine();
    }
}
