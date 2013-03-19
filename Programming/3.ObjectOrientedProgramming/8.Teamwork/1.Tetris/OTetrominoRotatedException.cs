using System;

class OTetrominoRotatedException : Exception
{

    public OTetrominoRotatedException(string message = "O Tetromino can not be rotated!", Exception innerException = null)
        : base(message, innerException)
    {
        return;
    }
}
