using System;
using System.Text;

class Matrix<T>
{
    // Private Fields
    private readonly int rows, cols;
    private readonly T[,] matrix;

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
    public Matrix(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;

        this.matrix = new T[rows, cols];
    }

    // Indexer
    public T this[int x, int y]
    {
        get { return matrix[x, y]; }
        set { matrix[x, y] = value; }
    }

    // Plus / Minus Operator
    private static Matrix<T> PlusMinus(Matrix<T> m1, Matrix<T> m2, bool plus)
    {
        if (!(m1.Rows == m2.Rows && m1.Cols == m2.Cols))
            throw new ArgumentException("Matrix size is not the same!");

        Matrix<T> result = new Matrix<T>(m1.rows, m1.cols);

        for (int i = 0; i < m1.rows; i++)
            for (int j = 0; j < m1.cols; j++)
                result[i, j] = m1[i, j] + (plus ? m2[i, j] : -(dynamic)m2[i, j]);

        return result;
    }

    public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
    {
        return PlusMinus(m1, m2, true);
    }

    public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
    {
        return PlusMinus(m1, m2, false);
    }

    // Naive multiplication
    public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
    {
        if (!(m1.Cols == m2.Rows))
            throw new ArgumentException("Matrix size is not the same!");

        Matrix<T> result = new Matrix<T>(m1.rows, m2.cols);

        for (int i = 0; i < result.rows; i++)
            for (int j = 0; j < result.cols; j++)
                for (int k = 0; k < m1.cols; k++)
                    result[i, j] += (dynamic)m1[i, k] * m2[k, j];

        return result;
    }

    // To string
    public override string ToString()
    {
        StringBuilder s = new StringBuilder();

        for (int i = 0; i < this.Rows; i++)
            for (int j = 0; j < this.Cols; j++)
                s.Append(this.matrix[i, j] + (j != this.Cols - 1 ? " " : Environment.NewLine));

        return s.ToString();
    }

    // True / False
    private static bool BoolOperator(Matrix<T> m, bool value)
    {
        for (int i = 0; i < m.Rows; i++)
            for (int j = 0; j < m.Cols; j++)
                if ((dynamic)m[i, j] != 0)
                    return value;

        return !value;
    }

    public static bool operator true(Matrix<T> m)
    {
        return BoolOperator(m, true);
    }

    public static bool operator false(Matrix<T> m)
    {
        return BoolOperator(m, false);
    }
}
