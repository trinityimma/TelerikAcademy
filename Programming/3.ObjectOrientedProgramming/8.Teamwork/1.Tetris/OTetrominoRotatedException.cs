using System;

class OTetrominoRotatedException : Exception
{
    public OTetrominoRotatedException(string message = "O Tetromino Rotated!", Exception innerException = null)
        : base(message, innerException)
    {
        return;
    }
}
