using System;

class Program
{
    static int[] G = new int[8];
    static int[,] directions = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, 1 } };
    static int direction = 0, length = 0, turns = 0;

    static bool IsTraversable(int row, int col)
    {
        return 0 <= row && row < G.Length && 0 <= col && col < G.Length && ((G[row] >> col) & 1) == 0;
    }

    static void DFS(int row, int col)
    {
        length++;

        if (row == 7 && col == 7) Console.WriteLine(length + " " + turns);
        else if (!IsTraversable(row, col)) Console.WriteLine("No " + (length - 1));
        else
        {
            row += directions[direction, 0];
            col += directions[direction, 1];

            if (!IsTraversable(row, col))
            {
                turns++;
                row -= directions[direction, 0];
                col -= directions[direction, 1];
                direction = ++direction % directions.GetLength(0);
                row += directions[direction, 0];
                col += directions[direction, 1];
            }

            DFS(row, col);
        }
    }

    static void Main()
    {
        for (int row = 0; row < 8; row++) G[row] = int.Parse(Console.ReadLine());

        if (!IsTraversable(0, 0)) Console.WriteLine("No 0");
        else if (!IsTraversable(1, 0)) Console.WriteLine("No 1");
        else DFS(0, 0);
    }
}
