using System;
using System.Linq;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

class Node<T>
{
    public T Value { get; set; }

    public Node<T> Previous { get; set; }

    public Node(T value)
    {
        this.Value = value;
    }
}

class ReversedLinkedList<T> : IEnumerable<T>
{
    public Node<T> Last { get; set; }

    public ReversedLinkedList(Node<T> last)
    {
        this.Last = last;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (Node<T> current = this.Last; current != null; current = current.Previous)
            yield return current.Value;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static Func<int, int>[] operations =
    {
        x => x + 1,
        x => x + 2,
        x => x * 2,
    };

    static void Main()
    {
        int start = 5;
        int end = 16;

        Debug.Assert(end > start);

        var results = new List<IEnumerable<int>>();

        var visited = new HashSet<int>();
        var currentWave = new Queue<Node<int>>();

        visited.Add(start);
        currentWave.Enqueue(new Node<int>(start));

        int level = 1;

        while (currentWave.Count != 0)
        {
            var nextWave = new Queue<Node<int>>();

            var nextVisited = new HashSet<int>();

            level++;

            while (currentWave.Count != 0)
            {
                var currentNode = currentWave.Dequeue();

                foreach (var operation in operations)
                {
                    int nextNumber = operation(currentNode.Value);

                    if (nextNumber > end)
                        continue;

                    if (visited.Contains(nextNumber))
                        continue;

                    var nextNode = new Node<int>(nextNumber);
                    nextNode.Previous = currentNode;

                    nextVisited.Add(nextNumber);
                    nextWave.Enqueue(nextNode);

                    if (nextNumber == end)
                    {
                        var sequence = new ReversedLinkedList<int>(nextNode);
                        results.Add(sequence.Reverse());
                    }
                }
            }

            visited.UnionWith(nextVisited);

            if (results.Count != 0)
                nextWave.Clear();

            currentWave = nextWave;
        }

        Console.WriteLine("Sequence length: {0}", level);

        foreach (var sequence in results)
            Console.WriteLine(string.Join(" -> ", sequence));
    }
}
