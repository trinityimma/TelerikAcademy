using System;
using System.Linq;
using System.Collections.Generic;

static class Program
{
    static Queue<T> Clone<T>(this Queue<T> queue)
        where T : struct
    {
        return new Queue<T>(queue.Select(x => x));
    }

    static void Main()
    {
        int n = 5;
        int m = 16;

        Func<int, int>[] operations = {
            x => x + 1,
            x => x + 2,
            x => x * 2
        };

        Queue<Queue<int>> results = new Queue<Queue<int>>();

        Queue<Queue<int>> sequences = new Queue<Queue<int>>();
        sequences.Enqueue(new Queue<int>(new int[] { n }));

        // TODO: Optimize
        while (sequences.Count != 0)
        {
            Queue<int> currentSequence = sequences.Dequeue();

            foreach (Func<int, int> op in operations)
            {
                int currentNumber = op(currentSequence.Last());

                Queue<int> nextSequence = currentSequence.Clone();
                nextSequence.Enqueue(currentNumber);

                if (currentNumber < m)
                    sequences.Enqueue(nextSequence);

                else if (currentNumber == m)
                    results.Enqueue(nextSequence);
            }
        }

        Queue<int> first = results.OrderBy(list => list.Count).ElementAt(0);
        Console.WriteLine(string.Join(" ", first));
    }
}
