using System;

/*
    + =========================== +
    |   I   |       |       |     |
    |   I   | J     |     L | O O |
    |   I   | J J J | L L L | O O |
    |   I   |       |       |     |
    + -------------------------- +
    |   S S |   T   | Z Z   |     |
    | S S   | T T T |   Z Z |     |
    + =========================== +
*/

partial class Tetromino
{
    public enum Shape
    {
        I = 0,
        J = 1,
        L = 2,
        O = 3,
        S = 4,
        T = 5,
        Z = 6
    }

    // In the same order
    private static readonly char[][,] images =
    {
        new char[,]
        {
            { 'I' },
            { 'I' },
            { 'I' },
            { 'I' }
        },

        new char[,]
        {
            { 'J', ' ', ' ' },
            { 'J', 'J', 'J' }
        },

        new char[,]
        {
            { ' ', ' ', 'L' },
            { 'L', 'L', 'L' }
        }
    };
}
