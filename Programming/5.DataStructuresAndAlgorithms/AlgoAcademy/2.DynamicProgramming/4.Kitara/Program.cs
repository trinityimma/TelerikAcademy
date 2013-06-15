using System;
using System.Linq;

class Program
{
    static int[] deltas = null;
    static int[] current = null;

    static int startVolume = 0;
    static int maxVolume = 0;
    static int result = -1;

    static bool[,] visited = null;

    static void Solve(int start)
    {
        if (start == current.Length)
        {
            result = Math.Max(result, current.Last());
            return;
        }

        if (visited[current[start - 1], start])
            return;

        current[start] = current[start - 1] + deltas[start - 1];
        if (current[start] <= maxVolume)
            Solve(start + 1);

        current[start] = current[start - 1] - deltas[start - 1];
        if (0 <= current[start])
            Solve(start + 1);

        visited[current[start - 1], start] = true;
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        Console.ReadLine(); // C
        deltas = Console.ReadLine().Split().Select(int.Parse).ToArray();
        startVolume = int.Parse(Console.ReadLine());
        maxVolume = int.Parse(Console.ReadLine());

        current = new int[deltas.Length + 1];
        visited = new bool[maxVolume + 1, deltas.Length + 1];

        current[0] = startVolume;
        Solve(1);

        Console.WriteLine(result);

#if DEBUG
        for (int row = 0; row < visited.GetLength(0); row++)
        {
            for (int col = 0; col < visited.GetLength(1); col++)
                Console.Write("{0} ", visited[row, col] ? 1 : 0);

            Console.WriteLine();
        }
#endif
    }
}
