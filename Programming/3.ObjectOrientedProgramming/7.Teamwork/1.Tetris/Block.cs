using System;

class Block : GameObject
{
    public Block(Coordinates position)
        : base(new char[,] { { '#' } }, Color.Gray, position)
    {
        return;
    }
}
