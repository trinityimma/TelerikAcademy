using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Wintellect.PowerCollections;

class Program
{
    static OrderedMultiDictionary<int, int> neighbors = new OrderedMultiDictionary<int, int>(allowDuplicateValues: false);
    //static MultiDictionary<int, int> neighbors = new MultiDictionary<int, int>(allowDuplicateValues: false);
    static HashSet<int> visited = new HashSet<int>();

    static long result = long.MinValue;

    static IEnumerable<int> FindLeaves()
    {
        return neighbors
            .Where(kvp => kvp.Value.Count == 1)
            .Select(kvp => kvp.Key);
    }

    static void Dfs(int start, long sum = 0)
    {
        visited.Add(start);

        sum += start;
        if (sum > result) result = sum;

        foreach (int neighbor in neighbors[start].Where(edge => !visited.Contains(edge)))
            Dfs(neighbor, sum);
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        foreach (int i in Enumerable.Range(0, int.Parse(Console.ReadLine()) - 1))
        {
            var match = Regex.Match(Console.ReadLine(), @"(\d+) <- (\d+)");

            int edge1 = int.Parse(match.Groups[1].Value);
            int edge2 = int.Parse(match.Groups[2].Value);

            neighbors.Add(edge1, edge2);
            neighbors.Add(edge2, edge1);
        }

        foreach (int leaf in FindLeaves())
        {
            Dfs(leaf);
            visited.Clear();
        }

#if DEBUG
        foreach (var item in neighbors)
            Console.WriteLine("{0} -> {1}", item.Key, string.Join(" ", item.Value));
#endif

        Console.WriteLine(result);
    }
}
