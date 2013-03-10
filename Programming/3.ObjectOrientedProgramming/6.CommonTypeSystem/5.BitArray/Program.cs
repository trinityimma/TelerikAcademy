using System;

class Program
{
    static void Main()
    {
        BitArray visited = new BitArray(70);

        Console.WriteLine("Count: " + visited.Count);
        Console.WriteLine("Capacity: " + visited.Capacity);

        {
            visited[1] = true;
            Console.WriteLine(visited[1]);

            visited[1] = false;
            Console.WriteLine(visited[1]);
        }

        Console.WriteLine();

        {
            visited[0] = true;
            visited[visited.Count - 1] = true;
            Console.WriteLine(visited);
        }
    }
}
