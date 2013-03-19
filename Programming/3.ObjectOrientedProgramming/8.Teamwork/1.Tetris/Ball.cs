using System;

class Ball : MovingObject
{
    public Ball(Coordinates position)
        : base(new char[,] { { 'o' } }, Color.DarkGreen, position, Coordinates.Right)
    {
        return;
    }
}
