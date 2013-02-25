using System;
using System.Text;

class Matrix<T>
{
    private int rows, cols;
    private T[,] matrix;

    // Public Properties
    public int Rows
    {
        get { return this.rows; }
    }

    public int Cols
    {
        get { return this.cols; }
    }

    // Constructor
    public Matrix(int x, int y)
    {
        this.matrix = new T[x, y];
        this.rows = x;
        this.cols = y;
    }

    // Indexer
    public T this[int x, int y]
    {
        get { return matrix[x, y]; }
        set { matrix[x, y] = value; }
    }

    // Addition
    public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
    {
        Matrix<T> result = new Matrix<T>(m1.rows, m1.cols);

        for (int i = 0; i < m1.rows; i++)
            for (int j = 0; j < m1.cols; j++)
                result[i, j] = (dynamic)m1[i, j] + m2[i, j];

        return result;
    }

    // Subtraction
    public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
    {
        Matrix<T> result = new Matrix<T>(m1.rows, m1.cols);

        for (int i = 0; i < m1.rows; i++)
            for (int j = 0; j < m1.cols; j++)
                result[i, j] = (dynamic)m1[i, j] - m2[i, j];

        return result;
    }

    // Naive multiplication
    public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
    {
        Matrix<T> result = new Matrix<T>(m1.rows, m2.cols);

        for (int i = 0; i < result.rows; i++)
            for (int j = 0; j < result.cols; j++)
                for (int k = 0; k < m1.cols; k++)
                    result[i, j] += (dynamic)m1[i, k] * m2[k, j];

        return result;
    }

    // Print
    public override string ToString()
    {
        StringBuilder s = new StringBuilder();

        for (int i = 0; i < this.Rows; i++)
            for (int j = 0; j < this.Cols; j++)
                s.Append(this.matrix[i, j] + (j != this.Cols - 1 ? " " : Environment.NewLine));

        return s.ToString();
    }

    public static bool operator true(Matrix<T> m)
    {
        for (int i = 0; i < m.Rows; i++)
            for (int j = 0; j < m.Cols; j++)
                if ((dynamic)m[i, j] != 0)
                    return true;

        return false;
    }

    public static bool operator false(Matrix<T> m)
    {
        for (int i = 0; i < m.Rows; i++)
            for (int j = 0; j < m.Cols; j++)
                if ((dynamic)m[i, j] == 0)
                    return true;

        return false;
    }
}

class Program
{
    static void Main()
    {
        Matrix<int> m1 = new Matrix<int>(3, 3);
        Matrix<int> m2 = new Matrix<int>(3, 3);

        // Fill with random numbers
        Random randomGenerator = new Random();
        for (int i = 0; i < m1.Rows; i++)
        {
            for (int j = 0; j < m1.Cols; j++)
            {
                m1[i, j] = randomGenerator.Next(20);
                m2[i, j] = randomGenerator.Next(20);
            }
        }

        Console.WriteLine("Matrix 1");
        Console.WriteLine(m1);

        Console.WriteLine("Matrix 2");
        Console.WriteLine(m2);

        Console.WriteLine("Matrix 1 + Matrix 2");
        Console.WriteLine(m1 + m2);

        Console.WriteLine("Matrix 1 - Matrix 2");
        Console.WriteLine(m1 - m2);

        Console.WriteLine("Matrix 1 * Matrix 2");
        Console.WriteLine(m1 * m2);

        Console.WriteLine(m1 ? "Not empty" : "Empty");

        if (new Matrix<int>(3, 3)) ;
        else Console.WriteLine("Empty");
    }
}
