using System;
using System.Linq;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class Program
{
    static MultiDictionary<int, KeyValuePair<int, int>> minTree = new MultiDictionary<int, KeyValuePair<int, int>>(true);

    static HashSet<int> hospitals = null;

    static int Bfs(int start)
    {
        int result = 0;

        var visited = new HashSet<int>();

        var queue = new Queue<Tuple<int, int>>();

        var first = new Tuple<int, int>(start, 0);

        visited.Add(first.Item1);
        queue.Enqueue(first);

        while (queue.Count != 0)
        {
            var current = queue.Dequeue();

            foreach (var neighbor in minTree[current.Item1])
            {
                if (visited.Contains(neighbor.Key))
                    continue;

                var next = new Tuple<int, int>(
                    neighbor.Key,
                    current.Item2 + neighbor.Value
                );

                if (!hospitals.Contains(neighbor.Key))
                    result += next.Item2;

                visited.Add(next.Item1);
                queue.Enqueue(next);
            }
        }

        return result;
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        hospitals = new HashSet<int>(
            Console.ReadLine().Split().Select(int.Parse)
        );

        var edges = new List<KeyValuePair<Tuple<int, int>, int>>();

        foreach (int i in Enumerable.Range(0, numbers[1]))
        {
            var parts = Console.ReadLine().Split().Select(int.Parse).ToArray();

            edges.Add(new KeyValuePair<Tuple<int, int>, int>(
                new Tuple<int, int>(parts[0], parts[1]),
                parts[2]
            ));
        }

        var trees = new HashSet<HashSet<int>>();

        foreach (int node in Enumerable.Range(1, numbers[0]))
        {
            var tree = new HashSet<int>();
            tree.Add(node);

            trees.Add(tree);
        }

        foreach (var currentEdge in edges.OrderBy(kvp => kvp.Value))
        {
            var tree1 = trees.First(tree => tree.Contains(currentEdge.Key.Item1));
            var tree2 = trees.Last(tree => tree.Contains(currentEdge.Key.Item2));

            if (tree1 == tree2)
                continue;

            tree1.UnionWith(tree2);
            trees.Remove(tree2);

            minTree.Add(currentEdge.Key.Item1,
                new KeyValuePair<int, int>(currentEdge.Key.Item2, currentEdge.Value)
            );

            minTree.Add(currentEdge.Key.Item2,
                new KeyValuePair<int, int>(currentEdge.Key.Item1, currentEdge.Value)
            );

            if (trees.Count == 1)
                break;
        }

        int result = int.MaxValue;

        foreach (int hospital in hospitals)
        {
            int currentResult = Bfs(hospital);
            result = Math.Min(currentResult, result);
        }

        Console.WriteLine(result);
    }
}
