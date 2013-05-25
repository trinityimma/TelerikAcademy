using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    //static OrderedMultiDictionary<int, int> neighbors = new OrderedMultiDictionary<int, int>(allowDuplicateValues: false);
    //static MultiDictionary<int, int> neighbors = new MultiDictionary<int, int>(allowDuplicateValues: false);

    static Dictionary<int, List<int>> neighbors = new Dictionary<int, List<int>>();

    static HashSet<int> visited = new HashSet<int>();

    static IEnumerable<int> FindLeaves()
    {
        return neighbors
            .Where(kvp => kvp.Value.Count == 1)
            .Select(kvp => kvp.Key);
    }

    static long Dfs(int start)
    {
        visited.Add(start);

        long sum = 0;

        foreach (int neighbor in neighbors[start])
        {
            if (visited.Contains(neighbor))
                continue;

            sum = Math.Max(sum, Dfs(neighbor));
        }

        return start + sum;
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif
        var date = DateTime.Now;

        foreach (int i in Enumerable.Range(0, int.Parse(Console.ReadLine()) - 1))
        {
            var match = Regex.Match(Console.ReadLine(), @"^\((\d+) <- (\d+)\)$");

            int edge1 = int.Parse(match.Groups[1].Value);
            int edge2 = int.Parse(match.Groups[2].Value);

            if (!neighbors.ContainsKey(edge1))
                neighbors[edge1] = new List<int>();

            neighbors[edge1].Add(edge2);

            if (!neighbors.ContainsKey(edge2))
                neighbors[edge2] = new List<int>();

            neighbors[edge2].Add(edge1);
        }

        long result = long.MinValue;
        foreach (int edge in FindLeaves())
        {
            result = Math.Max(Dfs(edge), result);
            visited.Clear();
        }

#if DEBUG
        //foreach (var neighbor in neighbors)
        //    Console.WriteLine("{0} -> {1}", neighbor.Key, string.Join(" ", neighbor.Value));

        Console.WriteLine(DateTime.Now - date);
#endif

        Console.WriteLine(result);
    }
}