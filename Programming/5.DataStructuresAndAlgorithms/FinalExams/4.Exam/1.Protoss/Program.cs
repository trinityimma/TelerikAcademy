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

    public static int Distance(Coordinates a, Coordinates b)
    {
        return Math.Abs(a.Row - b.Row) + Math.Abs(a.Col - b.Col);
    }
}

public class Program
{
    static Dictionary<string, string> secretKeys = null;

    static Dictionary<string, Coordinates> coords = new Dictionary<string, Coordinates>();

    static string[][] matrix = null;

    static string Decode(string encoded)
    {
        return string.Join("-", encoded.Split('-').Select(part => secretKeys[part]).ToArray());
    }

    static void GenerateCoords()
    {
        for (int row = 0; row < matrix.Length; row++)
            for (int col = 0; col < matrix[row].Length; col++)
                coords[matrix[row][col]] = new Coordinates(row, col);
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var maxDistance = int.Parse(Console.ReadLine());

        secretKeys = Enumerable.Range(0, int.Parse(Console.ReadLine()))
            .Select(i => Console.ReadLine().Split())
            .ToDictionary(parts => parts[0], parts => parts[1]);

        var rows = int.Parse(Console.ReadLine().Split()[0]);

        matrix = Enumerable.Range(0, rows)
            .Select(row => Console.ReadLine().Split())
            .ToArray();

        GenerateCoords();

        var targetArea = Console.ReadLine();

        var encodedTemplars = Enumerable.Range(0, int.Parse(Console.ReadLine()))
            .Select(i => Console.ReadLine())
            .ToArray();

        var decodedTemplars = encodedTemplars.Select(Decode);
        var coordinatesTemplars = decodedTemplars.Select(coord => coords[coord]).ToArray();

        var center = coords[Decode(targetArea)];

        var result = coordinatesTemplars.Where(coord =>
            Coordinates.Distance(center, coord) <= maxDistance
        );

        Console.WriteLine(result.Count());
    }
}
