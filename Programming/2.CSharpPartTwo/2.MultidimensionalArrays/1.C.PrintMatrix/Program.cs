using System;

class Program
{
    static void PrintMatrix(int[,] matrix)
    {
        int cellSize = (int)Math.Log10(matrix.Length) + 1;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(Convert.ToString(matrix[i, j]).PadRight(cellSize, ' ') + (j != matrix.GetLength(1) - 1 ? " " : "\n"));
    }

    static void Main()
    {
        int n = 4;

        int[,] matrix = new int[n, n];
        int counter = 1;

        for (int i = 0; i <= n - 1; i++)
            for (int j = 0; j <= i; j++) matrix[n - i + j - 1, j] = counter++;

        for (int i = n - 2; i >= 0; i--)
            for (int j = i; j >= 0; j--) matrix[i - j, n - j - 1] = counter++;

        PrintMatrix(matrix);
    }
}
