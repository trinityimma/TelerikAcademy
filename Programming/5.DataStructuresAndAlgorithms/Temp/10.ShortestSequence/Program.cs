using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

static class Program
{
    static IList<T> Clone<T>(this IList<T> list)
        where T : struct
    {
        return list.Select(item => item).ToList();
    }

    static void Main()
    {
        int start = 5;
        int end = 5000;

        Func<int, int>[] operations =
        {
            x => x + 1,
            x => x + 2,
            x => x * 2,
        };

        Debug.Assert(end > start);

        var results = new List<IList<int>>();

        var visited = new HashSet<int>();

        var sequences = new Queue<IList<int>>();
        sequences.Enqueue(new List<int>() { start });

        while (sequences.Count != 0)
        {
            var nextSequences = new Queue<IList<int>>();
            var currentVisited = new HashSet<int>();

            while (sequences.Count != 0)
            {
                var currentSequence = sequences.Dequeue();

                foreach (var operation in operations)
                {
                    int currentNumber = operation(currentSequence.Last());

                    if (currentNumber > end || visited.Contains(currentNumber))
                        continue;

                    currentVisited.Add(currentNumber);

                    var nextSequence = currentSequence.Clone();
                    nextSequence.Add(currentNumber);
                    nextSequences.Enqueue(nextSequence);

                    if (currentNumber == end)
                        results.Add(nextSequence);
                }
            }

            foreach (var number in currentVisited)
                visited.Add(number);

            if (currentVisited.Contains(end))
                nextSequences.Clear();

            sequences = nextSequences;
        }

        foreach (var sequence in results)
            Console.WriteLine(string.Join(" ", sequence));
    }
}
