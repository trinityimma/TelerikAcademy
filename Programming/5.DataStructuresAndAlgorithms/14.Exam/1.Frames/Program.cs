using System;
using System.Linq;
using System.Collections.Generic;
using Frame = System.Tuple<string, string>;

class Program
{
    static Frame[] frames = null;
    static bool[] used = null;

    static HashSet<string> data = new HashSet<string>();

    static Stack<Frame> stack = new Stack<Frame>();

    static void Generate(int start)
    {
        if (start == frames.Length)
        {
            data.Add(string.Join(" | ", stack));

            return;
        }

        for (int i = 0; i < frames.Length; i++)
        {
            if (used[i]) continue;

            used[i] = true;

            var current = frames[i];

            stack.Push(current);
            Generate(start + 1);
            stack.Pop();

            stack.Push(new Frame(current.Item2, current.Item1));
            Generate(start + 1);
            stack.Pop();

            used[i] = false;
        }
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        frames = Enumerable.Range(0, int.Parse(Console.ReadLine()))
            .Select(i => Console.ReadLine())
            .Select(line => line.Split())
            .Select(splitted => new Frame(splitted[0], splitted[1]))
            .ToArray();

        used = new bool[frames.Length];

        Generate(0);

        Console.WriteLine(data.Count);
        Console.WriteLine(string.Join(Environment.NewLine, data.OrderBy(x => x)));
    }
}
