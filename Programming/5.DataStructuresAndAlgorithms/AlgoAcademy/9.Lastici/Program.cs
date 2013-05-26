using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static bool[][] field = null;

    static HashSet<int> visited = new HashSet<int>();

    static bool CheckForSingle()
    {
        for (int row = 0; row < field.Length; row++)
            if (!field[row].Contains(true))
                return true;

        return false;
    }

    static bool CheckForEdges()
    {
        int edges = field.Select(row =>
            row.Where(cell => cell).Count()
        ).Sum() / 2;

        return edges >= field.Length - 1;
    }

    static void Dfs(int start)
    {
        visited.Add(start);

        var neighbors = field[start]
            .Select((cell, i) => i)
            .Where(edge =>
                field[start][edge] && !visited.Contains(edge)
            );

        foreach (int neighbor in neighbors)
            Dfs(neighbor);
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        foreach (int t in Enumerable.Range(0, int.Parse(Console.ReadLine())))
        {
            field = Enumerable.Range(0, int.Parse(Console.ReadLine()))
                .Select(_ =>
                    Console.ReadLine().Select(c => c == '1').ToArray()
                ).ToArray();

            if (CheckForSingle())
            {
                Console.WriteLine(-1);
                continue;
            }

            if (!CheckForEdges())
            {
                Console.WriteLine(-1);
                continue;
            }

            int result = 0;

            var edges = field
                .Select((row, i) => i)
                .Where(edge => !visited.Contains(edge));

            foreach (int edge in edges)
            {
                Dfs(edge);
                result++;
            }

            Console.WriteLine(result - 1);

            visited.Clear();
        }
    }
}
