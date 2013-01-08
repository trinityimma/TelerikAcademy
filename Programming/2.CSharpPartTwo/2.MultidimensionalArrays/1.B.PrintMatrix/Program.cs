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
        for (int i = 0, counter = 1; i < n; i++)
            if (i % 2 == 0) for (int j = 0; j < n; j++) matrix[j, i] = counter++;
            else for (int j = n - 1; j >= 0; j--) matrix[j, i] = counter++;

        PrintMatrix(matrix);
    }
}
