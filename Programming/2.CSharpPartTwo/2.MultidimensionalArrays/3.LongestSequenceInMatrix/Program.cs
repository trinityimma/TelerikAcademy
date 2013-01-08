using System;

class Program
{
    static void PrintMatrix(string[,] matrix)
    {
        int cellSize = matrix[0, 0].Length;
        foreach (string cell in matrix) cellSize = Math.Max(cellSize, cell.Length);

        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j].PadRight(cellSize, ' ') + (j != matrix.GetLength(1) - 1 ? " " : "\n"));
    }

    static bool IsTraversable(string[,] matrix, int x, int y)
    {
        return x >= 0 && x < matrix.GetLength(0) && y >= 0 && y < matrix.GetLength(1);
    }

    static int maxSum = 0;
    static string maxValue;

    static int[,] directions = { { 0, 1 }, { 1, 0 }, { 1, 1 } };
    static void DFS(string[,] matrix, int[,] used, int row, int col)
    {
        // Go in all directions
        for (int direction = 0; direction < directions.GetLength(0); direction++)
        {
            if (((used[row, col] >> direction) & 1) != 0) continue; // Already visited in this direction

            int currentSum = 0;
            int _row = row, _col = col;

            while (IsTraversable(matrix, _row, _col) && matrix[row, col] == matrix[_row, _col])
            {
                currentSum++;

                used[_row, _col] |= (1 << direction);

                _row += directions[direction, 0];
                _col += directions[direction, 1];
            }

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                maxValue = matrix[row, col];
            }
        }
    }

    static void Main()
    {
        string[,] matrix = { { "ha", "fifi", "ho", "hi" }, { "fo", "ha", "hi", "xx" }, { "xxx", "ho", "ha", "xx" } };
        // string[,] matrix = { { "s", "qq", "s" }, { "pp", "pp", "s" }, { "pp", "qq", "s" } };

        int[,] used = new int[matrix.GetLength(0), matrix.GetLength(1)];

        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                DFS(matrix, used, i, j);

        PrintMatrix(matrix);
        Console.WriteLine(maxValue + " " + maxSum);
    }
}
