using System;

/*
    + =========================== +
    |   I   |       |       |     |
    |   I   | J     |     L | O O |
    |   I   | J J J | L L L | O O |
    |   I   |       |       |     |
    + ---------------------------+
    |   S S |   T   | Z Z   |     |
    | S S   | T T T |   Z Z |     |
    + =========================== +
*/

enum TetrominoType
{
    I = 0,
    J = 1,
    L = 2,
    O = 3,
    S = 4,
    T = 5,
    Z = 6
}

partial class Tetromino
{
    private const char X = '■';
    private const char O = '\0';

    // In the same order
    private static readonly char[][,] images =
    {
        new char[,]
        {
            { X },
            { X },
            { X },
            { X }
        },

        new char[,]
        {
            { X, O, O },
            { X, X, X }
        },

        new char[,]
        {
            { O, O, X },
            { X, X, X }
        },

        new char[,]
        {
            { X, X },
            { X, X }
        },

        new char[,]
        {
            { O, X, X },
            { X, X, O }
        },

        new char[,]
        {
            { O, X, O },
            { X, X, X }
        },

        new char[,]
        {
            { X, X, O },
            { O, X, X }
        }
    };

    // In the same order
    private static readonly Color[] colors =
    {
        Color.Red,
        Color.Yellow,
        Color.Magenta,
        Color.Blue,
        Color.Cyan,
        Color.Green,
        Color.White
    };
}
