using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

class Program
{
    static int n = 0;

    static ICollection<string> words = null;

    static string[] crossword = null;

    static bool Check()
    {
        for (int col = 0; col < n; col++)
        {
            var sb = new StringBuilder();

            for (int row = 0; row < n; row++)
                sb.Append(crossword[row][col]);

            if (!words.Contains(sb.ToString()))
                return false;
        }

        return true;
    }

    static void Variations(int start)
    {
        if (start == n)
        {
            if (Check())
                throw new NotImplementedException(); // TODO

            return;
        }

        foreach (string word in words)
        {
            crossword[start] = word;
            Variations(start + 1);
        }
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
        Debug.Listeners.Add(new ConsoleTraceListener());
#endif

        var date = DateTime.Now;

        n = int.Parse(Console.ReadLine());

        words = new HashSet<string>(Enumerable.Range(0, 2 * n)
            .Select(i => Console.ReadLine())
            .OrderBy(line => line)
        );

        crossword = new string[n];

        try
        {
            Variations(0);

            Console.WriteLine("NO SOLUTION!");
        }
        catch (NotImplementedException)
        {
            Console.WriteLine(string.Join(Environment.NewLine, crossword));
        }

        Debug.WriteLine(DateTime.Now - date);
    }
}
