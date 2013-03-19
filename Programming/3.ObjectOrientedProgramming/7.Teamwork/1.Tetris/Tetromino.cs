using System;

partial class Tetromino : MovingObject
{
    public TetrominoType Type { get; private set; }

    private Tetromino(char[,] image, Color color, Coordinates position, TetrominoType type)
        : base(image, color, position)
    {
        this.Type = type;
    }

    public override void Rotate()
    {
        if (this.Type == TetrominoType.O)
            throw new OTetrominoRotatedException();

        base.Rotate();
    }
}
