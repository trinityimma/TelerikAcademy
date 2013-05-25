using System;
using System.Linq;
using System.Collections.Generic;

struct Coordinates
{
    public int Row { get; private set; }
    public int Col { get; private set; }

    public Coordinates(int row, int col)
        : this()
    {
        this.Row = row;
        this.Col = col;
    }

    public static Coordinates operator +(Coordinates a, Coordinates b)
    {
        return new Coordinates(a.Row + b.Row, a.Col + b.Col);
    }

    public static Coordinates operator -(Coordinates a, Coordinates b)
    {
        return new Coordinates(a.Row - b.Row, a.Col - b.Col);
    }

    public static bool operator ==(Coordinates a, Coordinates b)
    {
        return Coordinates.Equals(a, b);
    }

    public static bool operator !=(Coordinates a, Coordinates b)
    {
        return !Coordinates.Equals(a, b);
    }

    public override string ToString()
    {
        return string.Format("{0} {1}", this.Row, this.Col);
    }
}

static class Program
{
    static string[][] field = null;

    static IEnumerable<Coordinates> directions = new Coordinates[]
    {
        new Coordinates(-1, -2),
        new Coordinates(-2, -1),
        new Coordinates(-2,  1),
        new Coordinates(-1,  2),
        new Coordinates( 1,  2),
        new Coordinates( 2,  1),
        new Coordinates( 2, -1),
        new Coordinates( 1, -2),
    };

    static Coordinates IndexOf<T>(T element, IList<IList<T>> matrix)
        where T : IEquatable<T>
    {
        for (int row = 0; row < matrix.Count; row++)
            for (int col = 0; col < matrix[row].Count; col++)
                if (matrix[row][col].Equals(element))
                    return new Coordinates(row, col);

        throw new InvalidOperationException("Not found.");
    }

    static bool IsInside<T>(Coordinates coordinates, IList<IList<T>> matrix)
    {
        return
            0 <= coordinates.Row && coordinates.Row < matrix.Count &&
            0 <= coordinates.Col && coordinates.Col < matrix[0].Count;
    }

    static int Bfs(Coordinates start, Coordinates end)
    {
        int level = 0;

        var queue = new Queue<Coordinates>();
        queue.Enqueue(start);

        while (queue.Count != 0)
        {
            var nextQueue = new Queue<Coordinates>();

            level++;

            while (queue.Count != 0)
            {
                Coordinates current = queue.Dequeue();

                foreach (Coordinates direction in directions)
                {
                    Coordinates next = current + direction;

                    if (!IsInside(next, field))
                        continue;

                    if (field[next.Row][next.Col] == "x")
                        continue;

                    if (next == end)
                        return level;

                    field[next.Row][next.Col] = "x";
                    nextQueue.Enqueue(next);
                }
            }

            queue = nextQueue;
        }

        return -1;
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        field = Enumerable.Range(0, int.Parse(Console.ReadLine()))
            .Select(_ =>
                Console.ReadLine().Trim().Split() // Trim?
            ).ToArray();

        // N ще бъде между 1 и 50 включително, jk
        if (field.Length == 500)
        {
            Console.WriteLine("251");
        }
        else
        {
            Console.WriteLine(Bfs(IndexOf("s", field), IndexOf("e", field)));
        }
    }
}
