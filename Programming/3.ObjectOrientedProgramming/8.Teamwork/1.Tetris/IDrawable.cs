using System;

interface IDrawable
{
    Coordinates Position { get; }

    int Rows { get; }
    int Cols { get; }

    Color Color { get; }

    char this[int row, int col] { get; }
}