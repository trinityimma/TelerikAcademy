using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static string[][] field = null;

    static int CalcDistance(int algaeRow, int algaeCol)
    {
        if (field[algaeRow][algaeCol] != "*")
            return 0;

        int result = int.MaxValue;

        for (int row = 0; row < field.Length; row++)
            for (int col = 0; col < field[row].Length; col++)
                if (field[row][col] == "#")
                    result = Math.Min(result, Math.Abs(algaeRow - row) + Math.Abs(algaeCol - col));

        return result;
    }

    // The test results in BGCoder are incorrect.
    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var splitted = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int n = splitted[0];
        int kmin = splitted[1];
        int kmax = splitted[2];

        var results = new List<KeyValuePair<int, double>>();

        foreach (int i in Enumerable.Range(0, n))
        {
            int length = Console.ReadLine().Split().Select(int.Parse).ElementAt(0);
            field = Enumerable.Range(0, length).Select(_ => Console.ReadLine().Split()).ToArray();

            int foods = field.Select(row => row.Where(cell => cell == "#").Count()).Sum();
            int algae = field.Select(row => row.Where(cell => cell == "*").Count()).Sum();

            double result = 0;

            if (algae * 2 < foods)
            {
                result = double.NegativeInfinity;
            }
            else if (algae > foods * 2)
            {
                result = double.PositiveInfinity;
            }
            else
            {
                result = field.Select((row, r) => row.Select((cell, c) =>
                    CalcDistance(r, c)).Sum()).Sum() / (double)algae;
            }

            var pair = new KeyValuePair<int, double>(i + 1, result);

#if DEBUG
            Console.WriteLine(pair);
#endif

            results.Add(pair);
        }

        var sorted = results.OrderBy(result => result.Value).ThenBy(result => result.Key).Select(result => result.Key);

        Console.WriteLine(string.Join(" ", sorted.Take(kmin).OrderBy(x => x)));
        Console.WriteLine(string.Join(" ", sorted.Reverse().Take(kmax).OrderBy(x => x)));
    }
}
