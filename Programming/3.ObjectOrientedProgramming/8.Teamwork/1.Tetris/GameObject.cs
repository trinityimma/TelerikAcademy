using System;

abstract class GameObject : IDrawable
{
    protected char[,] Image { get; set; }

    public Coordinates Position { get; protected set; }
    public Color Color { get; protected set; }

    public int Rows { get { return this.Image.GetLength(0); } }
    public int Cols { get { return this.Image.GetLength(1); } }

    public bool IsDestroyed { get; protected set; }

    protected GameObject(char[,] image, Color color, Coordinates position)
    {
        this.Image = image;
        this.Position = position;
        this.Color = color;
    }

    public char this[int row, int col]
    {
        get { return this.Image[row, col]; }
    }

    public void DestroyRow(int destroyedRow)
    {
        char[,] destroyed = new char[this.Rows - 1, this.Cols];

        for (int row = 0; row < destroyedRow; row++)
            for (int col = 0; col < this.Cols; col++)
                destroyed[row, col] = this.Image[row, col];

        for (int row = destroyedRow + 1; row < this.Rows; row++)
            for (int col = 0; col < this.Cols; col++)
                destroyed[row - 1, col] = this.Image[row, col];

        if (this.Rows == 0)
            this.IsDestroyed = true;

        this.Image = destroyed;
    }
}
