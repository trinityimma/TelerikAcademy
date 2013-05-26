using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var nodes = new HashSet<int>();
        var edges = new List<KeyValuePair<Tuple<int, int>, int>>();

        foreach (int i in Enumerable.Range(0, int.Parse(Console.ReadLine())))
        {
            int[] parts = Console.ReadLine().Split().Select(int.Parse).ToArray();

            nodes.Add(parts[0]);
            nodes.Add(parts[1]);

            edges.Add(new KeyValuePair<Tuple<int, int>, int>(
                new Tuple<int, int>(parts[0], parts[1]),
                parts[2]
            ));
        }

        var trees = new HashSet<HashSet<int>>();

        foreach (int node in nodes)
        {
            var tree = new HashSet<int>();
            tree.Add(node);

            trees.Add(tree);
        }

        int result = 0;

        foreach (var currentEdge in edges.OrderBy(kvp => kvp.Value))
        {
            var tree1 = trees.First(tree => tree.Contains(currentEdge.Key.Item1));
            var tree2 = trees.Last(tree => tree.Contains(currentEdge.Key.Item2));

            if (tree1 == tree2)
                continue;

            tree1.UnionWith(tree2);
            trees.Remove(tree2);

            result += currentEdge.Value;

            if (trees.Count == 1)
                break;
        }

        Console.WriteLine(result);
    }
}
