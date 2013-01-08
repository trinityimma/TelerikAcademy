using System;

class Program
{
    static void PrintMatrix(string[,] matrix)
    {
        int cellSize = matrix[0, 0].Length;
        foreach (string cell in matrix) cellSize = Math.Max(cellSize, cell.Length);

        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(Convert.ToString(matrix[i, j]).PadRight(cellSize, ' ') + (j != matrix.GetLength(1) - 1 ? " " : "\n"));
    }

    static bool IsTraversable(int[,] matrix, int x, int y)
    {
        return x >= 0 && x < matrix.GetLength(0) && y >= 0 && y < matrix.GetLength(1) && matrix[x, y] == 0;
    }

    static int currentSum = 0, direction = 0;
    static int[,] directions = { { 0, 1 }, { 1, 0 }, { 1, 1 } };
    static void DFS(string[,] matrix, int[,] used, int row, int col)
    {

    }

    static void Main()
    {
        string[,] matrix = { { "ha", "fifi", "ho", "hi" }, { "fo", "ha", "hi", "xx" }, { "xxx", "ho", "ha", "xx" } };

        int[,] used = new int[matrix.GetLength(0), matrix.GetLength(1)];

        int maxSum = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (used[i, j] == 0)
                {
                    currentSum = 0;
                    DFS(matrix, used, i, j);

                    maxSum = Math.Max(currentSum, maxSum);

                    PrintMatrix(matrix);
                    Console.WriteLine(currentSum + "\n");
                }

        PrintMatrix(matrix);
        Console.WriteLine(maxSum);
    }
}
