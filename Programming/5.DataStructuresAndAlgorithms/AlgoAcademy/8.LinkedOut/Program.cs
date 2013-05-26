using System;
using System.Linq;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class Program
{
    static MultiDictionary<string, string> neighbors = new MultiDictionary<string, string>(allowDuplicateValues: false);

    //static Dictionary<string, List<string>> neighbors = new Dictionary<string, List<string>>();

    static HashSet<string> visited = new HashSet<string>();

    static IDictionary<string, int> Bfs(string start, HashSet<string> friends)
    {
        IDictionary<string, int> results = new Dictionary<string, int>();

        var queue = new Queue<string>();

        visited.Add(start);
        queue.Enqueue(start);

        int level = 0;

        while (queue.Count != 0)
        {
            var nextQueue = new Queue<string>();

            level++;

            while (queue.Count != 0)
            {
                string current = queue.Dequeue();

                foreach (string neighbor in neighbors[current])
                {
                    if (visited.Contains(neighbor))
                        continue;

                    if (friends.Contains(neighbor))
                        results[neighbor] = level;

                    visited.Add(neighbor);
                    nextQueue.Enqueue(neighbor);
                }
            }

            queue = nextQueue;
        }

        return results;
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var date = DateTime.Now;

        string start = Console.ReadLine();

        foreach (int i in Enumerable.Range(0, int.Parse(Console.ReadLine())))
        {
            string[] match = Console.ReadLine().Split();

            neighbors.Add(match[0], match[1]);
            neighbors.Add(match[1], match[0]);
        }

#if DEBUG
        //foreach (var neighbor in neighbors)
        //    Console.WriteLine("{0} -> {1}", neighbor.Key, string.Join(" ", neighbor.Value));
#endif

        var friends = new HashSet<string>();
        foreach (int i in Enumerable.Range(0, int.Parse(Console.ReadLine())))
            friends.Add(Console.ReadLine());

        IDictionary<string, int> results = Bfs(start, friends);

        Console.WriteLine(string.Join(Environment.NewLine,
            friends.Select(friend => results.ContainsKey(friend) ? results[friend] : -1))
        );

#if DEBUG
        // Dictionary<string, List<string>> is with 0.03 faster and passes all tests
        Console.WriteLine(DateTime.Now - date);
#endif
    }
}
