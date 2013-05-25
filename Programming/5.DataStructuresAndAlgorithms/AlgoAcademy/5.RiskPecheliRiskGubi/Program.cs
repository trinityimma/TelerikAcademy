using System;
using System.Linq;
using System.Collections.Generic;

static class Program
{
    const int MaxDigit = 10;
    const int Digits = 5;

    static int GetNextConfiguration(int currentConfiguration, int i, int step)
    {
        int powerOf10 = (int)Math.Pow(10, i);

        int digit = (currentConfiguration / powerOf10) % 10;
        int nextDigit = (digit + step + MaxDigit) % MaxDigit;

        int nextConfiguration = currentConfiguration;
        nextConfiguration -= digit * powerOf10;
        nextConfiguration += nextDigit * powerOf10;

        return nextConfiguration;
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        int combinations = (int)Math.Pow(MaxDigit, Digits);
        bool[] visited = new bool[combinations];
        bool[] forbidden = new bool[combinations];

        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());

        foreach (int i in Enumerable.Range(0, int.Parse(Console.ReadLine())))
            forbidden[int.Parse(Console.ReadLine())] = true;

        IEnumerable<int> steps = new int[] { 1, -1 };

        var queue = new Queue<int>();
        queue.Enqueue(start);

        int level = 0;

        while (queue.Count != 0)
        {
            level++;

            var nextQueue = new Queue<int>();

            while (queue.Count != 0)
            {
                int currentConfiguration = queue.Dequeue();

                for (int i = 0; i < Digits; i++)
                {
                    foreach (int step in steps)
                    {
                        int nextConfiguration = GetNextConfiguration(currentConfiguration, i, step);

                        if (nextConfiguration == end)
                        {
                            Console.WriteLine(level);
                            return;
                        }

                        if (!forbidden[nextConfiguration] && !visited[nextConfiguration])
                        {
                            visited[nextConfiguration] = true;
                            nextQueue.Enqueue(nextConfiguration);
                        }
                    }
                }
            }

            queue = nextQueue;
        }

        Console.WriteLine(-1);
    }
}
