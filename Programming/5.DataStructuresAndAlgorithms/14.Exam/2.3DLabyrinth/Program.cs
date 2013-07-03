using System;
using System.Linq;
using System.Collections.Generic;

struct Coordinates
{
    public int Row { get; private set; }
    public int Col { get; private set; }
    public int Level { get; private set; }

    public Coordinates(int row, int col, int level)
        : this()
    {
        this.Row = row;
        this.Col = col;
        this.Level = level;
    }

    public static Coordinates operator +(Coordinates a, Coordinates b)
    {
        return new Coordinates(
            a.Row + b.Row,
            a.Col + b.Col,
            a.Level + b.Level
        );
    }

    public override string ToString()
    {
        return string.Format("Row: {0}, Col: {1}, Level: {2}", this.Row, this.Col, this.Level);
    }
}

class Field
{
    private char[, ,] data = null;

    public int Rows { get { return this.data.GetLength(0); } }
    public int Cols { get { return this.data.GetLength(1); } }
    public int Levels { get { return this.data.GetLength(2); } }

    public Field(char[, ,] data)
    {
        this.data = data;
    }

    public bool IsInside(Coordinates coordinates)
    {
        return
            0 <= coordinates.Row && coordinates.Row < this.Rows &&
            0 <= coordinates.Col && coordinates.Col < this.Cols &&
            0 <= coordinates.Level && coordinates.Level < this.Levels
        ;
    }

    public char this[Coordinates coordinates]
    {
        get
        {
            var result = this.data[coordinates.Row, coordinates.Col, coordinates.Level];
            return result;
        }
    }
}

static class Program
{
    static readonly ICollection<Coordinates> Directions = new[]
        {
            new Coordinates( 0,  1,  0),
            new Coordinates( 1,  0,  0),
            new Coordinates( 0, -1,  0),
            new Coordinates(-1,  0,  0),
            new Coordinates( 0,  0,  1),
            new Coordinates( 0,  0, -1),
        };

    static int Bfs(Field field, Coordinates start)
    {
        var queue = new Queue<Coordinates>();
        var visited = new HashSet<Coordinates>();

        queue.Enqueue(start);
        visited.Add(start);

        var level = 0;

        while (queue.Count != 0)
        {
            var nextQueue = new Queue<Coordinates>();

            level++;

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();

                foreach (var direction in Directions)
                {
                    var neighbor = current + direction;

                    if (direction.Level == 1 && field[current] != 'U')
                        continue;

                    if (direction.Level == -1 && field[current] != 'D')
                        continue;

                    if (field[current] == 'U' || field[current] == 'D')
                        if (!(0 <= neighbor.Level && neighbor.Level < field.Levels))
                            return level;

                    if (!field.IsInside(neighbor))
                        continue;

                    if (field[neighbor] == '#')
                        continue;

                    if (visited.Contains(neighbor))
                        continue;

                    visited.Add(neighbor);
                    nextQueue.Enqueue(neighbor);
                }
            }

            queue = nextQueue;
        }

        throw new InvalidOperationException("Exit not found.");
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var line1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var line2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var start = new Coordinates(level: line1[0], row: line1[1], col: line1[2]);

        var rows = line2[1];
        var cols = line2[2];
        var levels = line2[0];

        var field = new char[rows, cols, levels];

        for (var level = 0; level < levels; level++)
        {
            for (var row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();

                for (var col = 0; col < cols; col++)
                {
                    field[row, col, level] = line[col];
                }
            }
        }

        var result = Bfs(new Field(field), start);
        Console.WriteLine(result);
    }
}
