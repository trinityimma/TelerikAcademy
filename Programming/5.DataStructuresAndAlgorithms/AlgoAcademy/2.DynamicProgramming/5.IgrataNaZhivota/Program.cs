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
        return new Coordinates(
            a.Row + b.Row,
            a.Col + b.Col
        );
    }

    public static Coordinates operator -(Coordinates a, Coordinates b)
    {
        return new Coordinates(
            a.Row - b.Row,
            a.Col - b.Col
        );
    }

    public override string ToString()
    {
        return string.Format("Row: {0}, Col: {1}", this.Row, this.Col);
    }
}

class Program
{
    static readonly ICollection<Coordinates> Directions = new[]
    {
        new Coordinates(-1, -1),
        new Coordinates(-1,  0),
        new Coordinates(-1,  1),

        new Coordinates( 0, -1),
        new Coordinates( 0,  1),
        
        new Coordinates( 1, -1),
        new Coordinates( 1,  0),
        new Coordinates( 1,  1),
    };

    static int n = 0;
    static IList<IList<bool>> field = null;

    static ICollection<bool> GetNeighbors(Coordinates coordinates)
    {
        return Directions
            .Select(d => coordinates + d)
            .Where(p => IsInRange(field, p))
            .Select(p => field[p.Row][p.Col])
            .Where(p => p)
            .ToArray();
    }

    static void SimulateCell(IList<IList<bool>> cloned, Coordinates coordinates)
    {
        var neighbors = GetNeighbors(coordinates);

        if (!field[coordinates.Row][coordinates.Col])
            if (neighbors.Count == 3)
                cloned[coordinates.Row][coordinates.Col] = true;

        if (field[coordinates.Row][coordinates.Col])
            if (!(neighbors.Count == 2 || neighbors.Count == 3))
                cloned[coordinates.Row][coordinates.Col] = false;
    }

    static void Simulate()
    {
        Print();

        for (int generation = 0; generation < n; generation++)
        {
            var cloned = Clone(field);

            for (int row = 0; row < field.Count; row++)
                for (int col = 0; col < field[row].Count; col++)
                    SimulateCell(cloned, new Coordinates(row, col));

            field = cloned;
            Print();
        }
    }

    static IList<IList<T>> Clone<T>(IList<IList<T>> matrix)
        where T : struct
    {
        return matrix.Select(row => row.Select(cell => cell).ToArray()).ToArray();
    }

    static bool IsInRange<T>(IList<IList<T>> matrix, Coordinates coordinates)
    {
        return (0 <= coordinates.Row) && (coordinates.Row < matrix.Count) &&
               (0 <= coordinates.Col) && (coordinates.Col < matrix[0].Count);
    }

    static void Print()
    {
#if DEBUG
        //for (int row = 0; row < field.Count; row++)
        //{
        //    for (int col = 0; col < field[row].Count; col++)
        //        Console.Write(field[row][col] ? 1 : 0);

        //    Console.WriteLine();
        //}

        //Console.WriteLine();
#endif
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        n = int.Parse(Console.ReadLine());

        int rows = int.Parse(Console.ReadLine().Split()[0]);

        field = Enumerable.Range(0, rows)
            .Select(i =>
                Console.ReadLine().Split().Select(x => int.Parse(x) == 1).ToArray()
            ).ToArray();

        Simulate();

        Console.WriteLine(field.SelectMany(p => p).Count(p => p));
    }
}
