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
        var current = this.Last;

        while (current != null)
        {
            yield return current.Value;
            current = current.Previous;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

static class Program
{
    static Func<int, int>[] operations = { x => x + 1, x => x + 2, x => x * 2, };

    static void Main()
    {
        int start = 5;
        int end = 16;

        Debug.Assert(end > start);

        var results = new List<IEnumerable<int>>();

        var visited = new HashSet<int>();
        var currentQueue = new Queue<Node<int>>();

        visited.Add(start);
        currentQueue.Enqueue(new Node<int>(start));

        int level = 1;

        while (currentQueue.Count != 0)
        {
            var nextQueue = new Queue<Node<int>>();
            var currentVisited = new HashSet<int>();

            level++;

            while (currentQueue.Count != 0)
            {
                var currentNode = currentQueue.Dequeue();

                foreach (var operation in operations)
                {
                    int nextNumber = operation(currentNode.Value);

                    if (nextNumber > end)
                        continue;

                    if (visited.Contains(nextNumber))
                        continue;

                    var nextNode = new Node<int>(nextNumber);
                    nextNode.Previous = currentNode;

                    currentVisited.Add(nextNumber);
                    nextQueue.Enqueue(nextNode);

                    if (nextNumber == end)
                        results.Add(new ReversedLinkedList<int>(nextNode).Reverse());
                }
            }

            visited.UnionWith(currentVisited);

            if (results.Count != 0)
                nextQueue.Clear();

            currentQueue = nextQueue;
        }

        Console.WriteLine("Sequence length: {0}", level);

        foreach (var sequence in results)
            Console.WriteLine(string.Join(" -> ", sequence));
    }
}
