using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    //static MultiDictionary<string, string> neighbors = new MultiDictionary<string, string>(allowDuplicateValues: true);

    static Dictionary<string, List<string>> neighbors = new Dictionary<string, List<string>>();

    static HashSet<string> visited = new HashSet<string>();

    static IDictionary<string, int> Bfs(string start, ICollection<string> friends)
    {
        IDictionary<string, int> results = friends.ToDictionary(friend => friend, friend => -1);

        if (!neighbors.ContainsKey(start))
            return results;

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

                    if (results.ContainsKey(neighbor) && results[neighbor] == -1)
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

            if (!neighbors.ContainsKey(match[0]))
                neighbors.Add(match[0], new List<string>());

            neighbors[match[0]].Add(match[1]);

            if (!neighbors.ContainsKey(match[1]))
                neighbors.Add(match[1], new List<string>());

            neighbors[match[1]].Add(match[0]);

            //neighbors.Add(match[0], match[1]);
            //neighbors.Add(match[1], match[0]);
        }

#if DEBUG
        //foreach (var neighbor in neighbors)
        //    Console.WriteLine("{0} -> {1}", neighbor.Key, string.Join(" ", neighbor.Value));
#endif

        var friends = Enumerable.Range(0, int.Parse(Console.ReadLine()))
            .Select(i => Console.ReadLine())
            .ToArray();

        IDictionary<string, int> results = Bfs(start, friends);

        Console.WriteLine(string.Join(Environment.NewLine,
            results.Select(kvp => kvp.Value)
        ));

#if DEBUG
        // Dictionary<string, List<string>> is with 0.03 faster and passes all tests
        Console.WriteLine(DateTime.Now - date); // 00:00:00.3940506
#endif
    }
}
