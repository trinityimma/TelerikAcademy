using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static IList<int> coins = null;

    static IList<int> dp = null;

    // https://en.wikipedia.org/wiki/Planar_graph#Maximal_planar_graphs
    static void Generate()
    {
        coins = new List<int> { 1, 8, 9 };

        for (int vertices = 3; vertices <= 35; vertices++)
        {
            int sum = (int)Math.Pow(vertices, 3);

            for (int edges = 0; edges <= (3 * vertices - 6); edges++)
            {
                int currentSum = sum + edges * edges;
                coins.Add(currentSum);
            }
        }
    }

    private static void Calc(int max)
    {
        dp = Enumerable.Repeat(int.MaxValue, max + 1).ToArray();
        dp[0] = 0;

        foreach (int coin in coins)
        {
            if (coin > max)
                break;

            for (int i = 0; i + coin <= max; i++)
                if (dp[i] + 1 < dp[i + coin])
                    dp[i + coin] = dp[i] + 1;

#if DEBUG
            //Console.WriteLine(string.Join(" ", dp));
#endif
        }
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var date = DateTime.Now;

        Generate();

        var tests = Enumerable.Range(0, int.Parse(Console.ReadLine()))
            .Select(i => Console.ReadLine())
            .Select(int.Parse)
            .ToArray();

        Calc(tests.Max());

        Console.WriteLine(string.Join(Environment.NewLine,
            tests.Select(test => dp[test])
        ));

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
#endif
    }
}
