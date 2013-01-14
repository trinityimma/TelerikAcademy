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
        else if (!IsTraversable(row, col)) Console.WriteLine("No {0}", length - 1);
        else
        {
            int _row = row + directions[direction, 0];
            int _col = col + directions[direction, 1];

            if (!IsTraversable(_row, _col))
            {
                turns++;

                direction = ++direction % directions.GetLength(0);

                _row = row + directions[direction, 0];
                _col = col + directions[direction, 1];
            }

            DFS(_row , _col);
        }
    }

    static void Main()
    {
        for (int row = 0; row < 8; row++) G[row] = int.Parse(Console.ReadLine());

        DFS(0, 0);
    }
}
