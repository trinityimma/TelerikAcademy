using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static IDictionary<long, long> Bfs(long start, HashSet<long> target, IList<Func<long, long>> operations)
    {
        var result = new Dictionary<long, long>();

        var visited = new HashSet<long>();

        var currentWave = new Queue<long>();

        visited.Add(start);
        currentWave.Enqueue(start);

        if (target.Contains(start))
            result[start] = 0;

        long level = 0;

        while (currentWave.Count != 0)
        {
            var nextWave = new Queue<long>();

            level++;

            while (currentWave.Count != 0)
            {
                long currentNumber = currentWave.Dequeue();

                foreach (var op in operations)
                {
                    long nextNumber = op(currentNumber);

                    if (nextNumber < 0)
                        continue; 
                    
                    if (visited.Contains(nextNumber))
                        continue;

                    if (target.Contains(nextNumber))
                        result[nextNumber] = level;

                    if (result.Count == target.Count)
                        return result;

                    visited.Add(nextNumber);
                    nextWave.Enqueue(nextNumber);
                }
            }

            currentWave = nextWave;
        }

        throw new ArgumentException();
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var date = DateTime.Now;

        Func<long, long>[] operations =
        {
            x => x + 1,
            x => x - 1,
            x => (long)Math.Pow(x, 2),
            x => (long)Math.Pow(x, 3),
            x => (long)Math.Pow(x, 4),
            x => (long)Math.Pow(x, 5),
            x => (long)Math.Pow(x, 6),
            x => (long)Math.Pow(x, 7),
            x => (long)Math.Pow(x, 8),
            x => (long)Math.Pow(x, 9),
            x => (long)Math.Pow(x, 10),
            x => (long)Math.Pow(x, 11),
            x => (long)Math.Pow(x, 12),
            x => (long)Math.Pow(x, 13),
            x => (long)Math.Pow(x, 14),
            x => (long)Math.Pow(x, 15),
            x => (long)Math.Pow(x, 16),
            x => (long)Math.Pow(x, 17),
            x => (long)Math.Pow(x, 18),
            x => (long)Math.Pow(x, 19),
            x => (long)Math.Pow(x, 20),
            x => (long)Math.Pow(x, 21),
            x => (long)Math.Pow(x, 22),
            x => (long)Math.Pow(x, 23),
            x => (long)Math.Pow(x, 24),
            x => (long)Math.Pow(x, 25),
            x => (long)Math.Pow(x, 26),
            x => (long)Math.Pow(x, 27),
            x => (long)Math.Pow(x, 28),
            x => (long)Math.Pow(x, 29),
            x => (long)Math.Pow(x, 30),
            x => (long)Math.Pow(x, 31),
            x => (long)Math.Pow(x, 32),
            x => (long)Math.Pow(x, 33),
            x => (long)Math.Pow(x, 34),
            x => (long)Math.Pow(x, 35),
            x => (long)Math.Pow(x, 36),
            x => (long)Math.Pow(x, 37),
            x => (long)Math.Pow(x, 38),
            x => (long)Math.Pow(x, 39),
            x => (long)Math.Pow(x, 40),
            x => (long)Math.Pow(x, 41),
            x => (long)Math.Pow(x, 42),
            x => (long)Math.Pow(x, 43),
            x => (long)Math.Pow(x, 44),
            x => (long)Math.Pow(x, 45),
            x => (long)Math.Pow(x, 46),
            x => (long)Math.Pow(x, 47),
            x => (long)Math.Pow(x, 48),
            x => (long)Math.Pow(x, 49),
            x => (long)Math.Pow(x, 50),
            x => (long)Math.Pow(x, 51),
            x => (long)Math.Pow(x, 52),
            x => (long)Math.Pow(x, 53),
            x => (long)Math.Pow(x, 54),
            x => (long)Math.Pow(x, 55),
            x => (long)Math.Pow(x, 56),
            x => (long)Math.Pow(x, 57),
            x => (long)Math.Pow(x, 58),
            x => (long)Math.Pow(x, 59),
            x => (long)Math.Pow(x, 60),
            x => (long)Math.Pow(x, 61),
            x => (long)Math.Pow(x, 62),
            x => (long)Math.Pow(x, 63),
        };

        var input = Enumerable.Range(0, 4)
            .Select(i => long.Parse(Console.ReadLine())).ToArray();

        var searched = new HashSet<long>(input);

        var results = Bfs(1, searched, operations);

        Console.WriteLine(string.Join(Environment.NewLine,
            input.Select(x => results[x])
        ));

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
#endif
    }
}
