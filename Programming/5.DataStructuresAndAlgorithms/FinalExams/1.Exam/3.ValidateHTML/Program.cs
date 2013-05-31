using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static string[] separator = new string[] { "><" };

    static bool IsValid(string html)
    {
        var stack = new Stack<string>();

        var tokens = html.Substring(1, html.Length - 2).Split(separator, StringSplitOptions.None);

        foreach (var token in tokens)
        {
            if (token[0] != '/')
                stack.Push(token);

            else if (stack.Count == 0)
                return false;

            else if (stack.Pop() != token.Substring(1))
                return false;
        }

        return stack.Count == 0;
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var date = DateTime.Now;

        Console.WriteLine(string.Join(Environment.NewLine,
            Enumerable.Range(0, int.Parse(Console.ReadLine()))
                .Select(i => Console.ReadLine())
                .Select(line => IsValid(line) ? "VALID" : "INVALID")
        ));

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
#endif
    }
}
