using System;

class Program
{
    // TODO: Learn OOP in C#
    static int[,] G;
    static int[,] signs = new int[,] { { 0, 1 }, { 1, 0 }, { -1, 0 }, { 0, -1 } };
    static int direction = 0;

    static void PrintMatrix(int[,] m, int cellSize)
    {
        for (int i = 0; i < m.GetLength(0); i++)
            for (int j = 0; j < m.GetLength(1); j++)
                Console.Write(Convert.ToString(m[i, j]).PadRight(cellSize, ' ') + (j != m.GetLength(1) - 1 ? " " : "\n"));
    }

    static bool IsTraversable(int x, int y)
    {
        return x >= 0 && x < G.GetLength(0) && y >= 0 && y < G.GetLength(1) && G[x, y] == 0; // In range of matrix and not visited
    }

    static void DFS(int x, int y, int level)
    {
        G[x, y] = level; // Set level
        if (level == G.GetLength(0) * G.GetLength(0)) return; // End of recursion

        // Find the next cell, we should visit
        int xx = x, yy = y;
        x = xx + signs[direction, 0];
        y = yy + signs[direction, 1];

        // Check if the next cell is traversable
        // Reset the direction and find the first free one if it isn't
        if (!IsTraversable(x, y)) direction = -1;
        while (!IsTraversable(x, y))
        {
            direction++;
            x = xx + signs[direction, 0];
            y = yy + signs[direction, 1];
        }

        DFS(x, y, level + 1); // Go to the next cell and increment level
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        G = new int[n, n];
        DFS(0, 0, 1); // We start depth-first search from cell(0, 0) with level 1
        PrintMatrix(G, (int)Math.Log10(n * n) + 1); // Make all cells equal width
    }
}
