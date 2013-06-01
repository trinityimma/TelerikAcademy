using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, int> decoded = null;
    static KeyValuePair<int, int>[] coords = null;

    static HashSet<int>[] graph = null;

    static HashSet<int> visited = new HashSet<int>();

    static int ParseCoordinate(string encoded)
    {
        int result = Enumerable.Range(0, encoded.Length / 4)
            .Select(i =>
                encoded.Substring(i * 4, 4)
            ).Select(chunk => decoded[chunk])
            .Sum();

        return result;
    }

    static double Distance(KeyValuePair<int, int> coords1, KeyValuePair<int, int> coords2)
    {
        return Math.Sqrt(
            (coords1.Key - coords2.Key) * (coords1.Key - coords2.Key) +
            (coords1.Value - coords2.Value) * (coords1.Value - coords2.Value)
        );
    }

    static void Dfs(int start)
    {
        visited.Add(start);

        foreach (int neighbor in graph[start])
        {
            if (visited.Contains(neighbor))
                continue;

            Dfs(neighbor);
        }
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var date = DateTime.Now;

        double maxRange = double.Parse(Console.ReadLine());

        decoded = Enumerable.Range(0, int.Parse(Console.ReadLine()))
            .Select(i => Console.ReadLine().Split())
            .ToDictionary(parts => parts[0], parts => int.Parse(parts[1]));

        coords = Enumerable.Range(0, int.Parse(Console.ReadLine()))
            .Select(i => Console.ReadLine().Split())
            .Select(parts =>
                new KeyValuePair<int, int>(
                    ParseCoordinate(parts[0]),
                    ParseCoordinate(parts[1])
                )
            ).ToArray();

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
#endif

        graph = Enumerable.Range(0, coords.Length)
            .Select(i => new HashSet<int>()).ToArray();

        for (int i = 0; i < graph.Length; i++)
        {
            for (int j = 0; j < graph.Length; j++)
            {
                if (i == j) continue;

                if (Distance(coords[i], coords[j]) <= maxRange)
                {
                    graph[i].Add(j);
                    graph[j].Add(i);
                }
            }
        }

        var remaining = new HashSet<int>(Enumerable.Range(0, graph.Length));

        int groups = 0;
        while (remaining.Count != 0)
        {
            int next = remaining.First();

            Dfs(next);

            remaining.SymmetricExceptWith(visited);
            visited.Clear();

            groups++;
        }

        Console.WriteLine(groups);

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
#endif
    }
}
