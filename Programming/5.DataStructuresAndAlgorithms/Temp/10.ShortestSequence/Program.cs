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
        Func<int, int>[] operations =
        {
            x => x + 1,
            x => x + 2,
            x => x * 2,
        };

        int start = 5;
        int end = 5000;

        Debug.Assert(end > start);

        Queue<IList<int>> sequences = new Queue<IList<int>>();
        sequences.Enqueue(new List<int>() { start });

        IList<IList<int>>[] dp = new List<IList<int>>[end - start + 1];

        while (sequences.Count != 0)
        {
            IList<int> currentSequence = sequences.Dequeue();

            foreach (Func<int, int> op in operations)
            {
                int currentNumber = op(currentSequence.Last());

                if (currentNumber > end)
                    continue;

                IList<IList<int>> dp1 = dp[currentNumber - start];

                if (dp1 != null && dp1[0].Count < currentSequence.Count + 1)
                    continue;

                IList<int> nextSequence = currentSequence.Clone();
                nextSequence.Add(currentNumber);

                sequences.Enqueue(nextSequence);

                if (dp1 == null)
                    dp1 = dp[currentNumber - start] = new List<IList<int>>();

                else if (dp1[0].Count > currentSequence.Count + 1)
                    dp1.Clear();

                dp1.Add(nextSequence);
            }
        }

        foreach (var sequence in dp.Last())
        {
            var result = sequence.Select((n, i) =>
                n.ToString().PadLeft(
                    dp.Last().Max(list => list[i]).ToString().Length
                )
            );

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
