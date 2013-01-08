using System;

class Matrix
{
    public int rows, cols;

    private int[,] matrix;

    public Matrix(int x, int y)
    {
        matrix = new int[x, y];
        rows = x;
        cols = y;
    }

    public int this[int x, int y]
    {
        get { return matrix[x, y]; }
        set { matrix[x, y] = value; }
    }

    // Addition
    public static Matrix operator +(Matrix m1, Matrix m2)
    {
        Matrix m = new Matrix(m1.rows, m1.cols);

        for (int i = 0; i < m1.rows; i++)
            for (int j = 0; j < m1.cols; j++)
                m[i, j] = m1[i, j] + m2[i, j];

        return m;
    }

    // Subtraction
    public static Matrix operator -(Matrix m1, Matrix m2)
    {
        Matrix m = new Matrix(m1.rows, m1.cols);

        for (int i = 0; i < m1.rows; i++)
            for (int j = 0; j < m1.cols; j++)
                m[i, j] = m1[i, j] - m2[i, j];

        return m;
    }

    // Naive multiplication
    public static Matrix operator *(Matrix m1, Matrix m2)
    {
        Matrix m = new Matrix(m1.rows, m2.cols);

        for (int i = 0; i < m.rows; i++)
            for (int j = 0; j < m.cols; j++)
                for (int k = 0; k < m1.cols; k++)
                    m[i, j] += m1[i, k] * m2[k, j];

        return m;
    }

    // Print
    public override string ToString()
    {
        int max = matrix[0, 0];
        foreach (int cell in matrix) max = Math.Max(max, cell);
        int cellSize = Convert.ToString(max).Length;

        string s = "";

        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                s += (Convert.ToString(matrix[i, j]).PadRight(cellSize, ' ') + (j != matrix.GetLength(1) - 1 ? " " : "\n"));

        return s;
    }
}

class Program
{
    static void Main()
    {
        int rows = 3, cols = 3;
        Matrix m1 = new Matrix(rows, cols);
        Matrix m2 = new Matrix(rows, cols);

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                m1[i, j] = m2[i, j] = i + j;

        Console.WriteLine(m1);
        Console.WriteLine(m2);

        Matrix m;

        m = m1 + m2;
        Console.WriteLine(m);

        m = m1 - m2;
        Console.WriteLine(m);

        m = m1 * m2;
        Console.Write(m);
    }
}
