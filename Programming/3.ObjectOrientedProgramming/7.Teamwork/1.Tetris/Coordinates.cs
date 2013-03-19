using System;

struct Coordinates
{
    public int Row { get; private set; }
    public int Col { get; private set; }

    // Directions
    private static readonly Coordinates zero = new Coordinates(0, 0);
    public static Coordinates Zero { get { return zero; } }

    private static readonly Coordinates down = new Coordinates(1, 0);
    public static Coordinates Down { get { return down; } }

    private static readonly Coordinates up = new Coordinates(-1, 0);
    public static Coordinates Up { get { return up; } }

    private static readonly Coordinates left = new Coordinates(0, -1);
    public static Coordinates Left { get { return left; } }

    private static readonly Coordinates right = new Coordinates(0, 1);
    public static Coordinates Right { get { return right; } }

    private static readonly Random random = new Random();
    public static Coordinates Random {
        get { return new Coordinates(random.Next(3) - 1, random.Next(3) - 1); }
    }

    public Coordinates(int row, int col)
        : this()
    {
        this.Row = row;
        this.Col = col;
    }

    // Go in direction
    public static Coordinates operator +(Coordinates a, Coordinates b)
    {
        return new Coordinates(a.Row + b.Row, a.Col + b.Col);
    }

    public static Coordinates operator -(Coordinates a, Coordinates b)
    {
        return new Coordinates(a.Row - b.Row, a.Col - b.Col);
    }

    public override string ToString()
    {
        return string.Format("Coordinates({0}, {1})", this.Row, this.Col);
    }
}
