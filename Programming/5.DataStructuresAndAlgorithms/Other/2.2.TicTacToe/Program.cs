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

    public override string ToString()
    {
        return string.Format("{0} {1}", this.Row, this.Col);
    }
}

class Program
{
    static char[][] tictactoe = null;

    static IList<Coordinates> empty = null;

    static IDictionary<char, int> result = new Dictionary<char, int>
    {
        { 'X', 0 },
        { 'E', 0 },
        { 'O', 0 },
    };

    static bool AreEqualPlayer(char a, char b, char c)
    {
        return a == b && b == c && c != '-';
    }

    static char GetWinner()
    {
        for (int row = 0; row < 3; row++)
            if (AreEqualPlayer(tictactoe[row][0], tictactoe[row][1], tictactoe[row][2]))
                return tictactoe[row][0];

        for (int col = 0; col < 3; col++)
            if (AreEqualPlayer(tictactoe[0][col], tictactoe[1][col], tictactoe[2][col]))
                return tictactoe[0][col];

        if (AreEqualPlayer(tictactoe[0][0], tictactoe[1][1], tictactoe[2][2]))
            return tictactoe[1][1];

        if (AreEqualPlayer(tictactoe[0][2], tictactoe[1][1], tictactoe[2][0]))
            return tictactoe[1][1];

        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                if (tictactoe[row][col] == '-')
                    return '-';

        return 'E';
    }

    static IList<Coordinates> GetEmpty()
    {
        var result = new List<Coordinates>();

        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                if (tictactoe[row][col] == '-')
                    result.Add(new Coordinates(row, col));

        return result;
    }

    static void Permutation(bool previousPlayer)
    {
        var winner = GetWinner();

        if (winner != '-')
        {
            result[winner]++;

#if DEBUG
            //Print();
            //Console.WriteLine(winner);
            //Console.WriteLine();
#endif

            return;
        }

        foreach (var cell in empty)
        {
            if (tictactoe[cell.Row][cell.Col] != '-')
                continue;

            tictactoe[cell.Row][cell.Col] = previousPlayer ? 'O' : 'X';
            Permutation(!previousPlayer);
            tictactoe[cell.Row][cell.Col] = '-';
        }
    }

    static void Print()
    {
        Console.WriteLine(string.Join(Environment.NewLine,
            tictactoe.Select(row => string.Concat(row))
        ));
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var date = DateTime.Now;

        tictactoe = Enumerable.Range(0, 3)
            .Select(i => Console.ReadLine().ToCharArray())
            .ToArray();

        empty = GetEmpty();

        Permutation(empty.Count % 2 == 0);

        Console.WriteLine(string.Join(Environment.NewLine,
            result.Select(kvp => kvp.Value)
        ));

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
#endif
    }
}
