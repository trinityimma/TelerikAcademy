using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static char[][] digits = new[]
    {
        new[] { '1', '1', '1', '1', '1', '1', '0' },
        new[] { '0', '1', '1', '0', '0', '0', '0' },
        new[] { '1', '1', '0', '1', '1', '0', '1' },
        new[] { '1', '1', '1', '1', '0', '0', '1' },
        new[] { '0', '1', '1', '0', '0', '1', '1' },
        new[] { '1', '0', '1', '1', '0', '1', '1' },
        new[] { '1', '0', '1', '1', '1', '1', '1' },
        new[] { '1', '1', '1', '0', '0', '0', '0' },
        new[] { '1', '1', '1', '1', '1', '1', '1' },
        new[] { '1', '1', '1', '1', '0', '1', '1' },
    };

    static int[][] numbers = null;

    static int[] current = null;

    static IList<string> results = new List<string>();

    static int[] FindPossible(char[] config)
    {
        return digits.Select((value, i) =>
            new { value, i }
        ).Where(digit =>
        {
            for (int i = 0; i < digit.value.Length; i++)
                if (config[i] == '1' && digit.value[i] == '0')
                    return false;

            return true;
        }).Select(x => x.i)
        .ToArray();
    }

    static void Variations(int start)
    {
        if (start == numbers.Length)
        {
            results.Add(string.Concat(current));
            return;
        }

        for (int i = 0; i < numbers[start].Length; i++)
        {
            current[start] = numbers[start][i];
            Variations(start + 1);
        }
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var input = Enumerable.Range(0, int.Parse(Console.ReadLine()))
            .Select(i => Console.ReadLine().ToCharArray())
            .ToArray();

        numbers = input.Select(FindPossible).ToArray();

        current = new int[numbers.Length];

        Variations(0);

        Console.WriteLine(results.Count);
        Console.WriteLine(string.Join(Environment.NewLine, results));
    }
}
