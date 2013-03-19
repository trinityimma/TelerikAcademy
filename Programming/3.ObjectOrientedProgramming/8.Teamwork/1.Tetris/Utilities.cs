using System;

static class Utilities
{
    public static T[,] Rotate<T>(this T[,] matrix)
    {
        T[,] result = new T[matrix.GetLength(1), matrix.GetLength(0)];

        for (int row = 0; row < matrix.GetLength(0); row++)
            for (int col = 0; col < matrix.GetLength(1); col++)
                result[col, row] = matrix[matrix.GetUpperBound(0) - row, col];

        return result;
    }
}
