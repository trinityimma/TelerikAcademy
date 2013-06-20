using System;
using System.Linq;
using System.Diagnostics;

class Program
{
    static int n = 0;
    static int[][] field = null;

    static int GetNeighbors(int row, int col)
    {
        var result = 0;
        if (row > 0)
        {
            if (col > 0) result += field[row - 1][col - 1];
            result += field[row - 1][col];
            if (col + 1 < field[row].Length) result += field[row - 1][col + 1];
        }

        if (col > 0) result += field[row][col - 1];
        if (col + 1 < field[row].Length) result += field[row][col + 1];

        if (row + 1 < field.Length)
        {
            if (col > 0) result += field[row + 1][col - 1];
            result += field[row + 1][col];
            if (col + 1 < field[row].Length) result += field[row + 1][col + 1];
        }

        return result;
    }

    private static void SimulateCell(int[][] cloned, int row, int col)
    {
        var neighbors = GetNeighbors(row, col);

        if (field[row][col] == 0)
            if (neighbors == 3)
                cloned[row][col] = 1;

        if (field[row][col] == 1)
            if (!(neighbors == 2 || neighbors == 3))
                cloned[row][col] = 0;
    }

    static void Simulate()
    {
        Print();

        for (int generation = 0; generation < n; generation++)
        {
            var cloned = Clone(field);

            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    SimulateCell(cloned, row, col);
                }
            }

            field = cloned;
            Print();
        }
    }
    static T[][] Clone<T>(T[][] matrix)
        where T : struct
    {
        var result = new T[matrix.Length][];

        for (int row = 0; row < field.Length; row++)
        {
            result[row] = new T[matrix[row].Length];

            for (int col = 0; col < field[row].Length; col++)
            {
                result[row][col] = matrix[row][col];
            }
        }

        return result;
    }

    static void Print()
    {
#if DEBUG
        //for (int row = 0; row < field.Length; row++)
        //{
        //    for (int col = 0; col < field[row].Length; col++)
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
        Debug.Listeners.Add(new ConsoleTraceListener());
#endif

        var date = DateTime.Now;

        n = int.Parse(Console.ReadLine());

        int rows = int.Parse(Console.ReadLine().Split()[0]);

        field = Enumerable.Range(0, rows)
            .Select(i =>
                Console.ReadLine().Split().Select(int.Parse).ToArray()
            ).ToArray();

        Simulate();

        Console.WriteLine(field.SelectMany(p => p).Count(p => p == 1));

        Debug.WriteLine(DateTime.Now - date);
    }
}
