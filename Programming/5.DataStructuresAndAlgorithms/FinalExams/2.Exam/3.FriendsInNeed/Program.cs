using System;
using System.Linq;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class PriorityQueue<T> where T : IComparable<T>
{
    private readonly OrderedBag<T> bag = null;

    public int Count
    {
        get { return bag.Count; }
    }

    public PriorityQueue()
    {
        this.bag = new OrderedBag<T>();
    }

    public void Enqueue(T element)
    {
        this.bag.Add(element);
    }

    public T Dequeue()
    {
        return this.bag.RemoveFirst();
    }

    public void Clear()
    {
        this.bag.Clear();
    }

    public T Peek()
    {
        return this.bag.GetFirst();
    }
}

struct Node : IComparable<Node>
{
    public int To { get; set; }
    public int Distance { get; set; }

    public Node(int vertex, int distance)
        : this()
    {
        this.To = vertex;
        this.Distance = distance;
    }

    public int CompareTo(Node other)
    {
        return this.Distance.CompareTo(other.Distance);
    }
}

class Program
{
    static IList<IList<Node>> graph = null;

    private static int[] Dijkstra(int start)
    {
        var distances = Enumerable.Range(0, graph.Count)
            .Select(i => int.MaxValue)
            .ToArray();

        var visited = new HashSet<int>();

        var queue = new PriorityQueue<Node>();

        distances[start] = 0;
        visited.Add(start);
        queue.Enqueue(new Node(start, 0));

        while (queue.Count != 0)
        {
            var u = queue.Dequeue();
            visited.Add(u.To);

            foreach (var v in graph[u.To])
            {
                int newDistance = distances[u.To] + v.Distance;

                if (distances[v.To] > newDistance)
                {
                    distances[v.To] = newDistance;

                    var next = new Node(v.To, newDistance);
                    queue.Enqueue(next);
                }
            }

            while (queue.Count != 0 && visited.Contains(queue.Peek().To))
            {
                queue.Dequeue();
            }
        }

        return distances;
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var date = DateTime.Now;

        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var hospitals = new HashSet<int>(
            Console.ReadLine().Split().Select(line => int.Parse(line) - 1)
        );

        var edges = Enumerable.Range(0, numbers[1])
            .Select(i =>
                Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray()
            ).ToArray();

        graph = Enumerable.Range(0, numbers[0])
            .Select(i => new List<Node>())
            .ToArray();

        foreach (var edge in edges)
        {
            graph[edge[0] - 1].Add(new Node(edge[1] - 1, edge[2]));
            graph[edge[1] - 1].Add(new Node(edge[0] - 1, edge[2]));
        }

        var results = hospitals.Select(Dijkstra);

        int min = results.Select(distances =>
            distances.Where((distance, i) =>
                !hospitals.Contains(i)
            ).Sum()
        ).Min();

        Console.WriteLine(min);

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
#endif
    }
}
