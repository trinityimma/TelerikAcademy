using System;

class Block : GameObject
{
    private const char Symbol = '#';

    public Block(Coordinates position)
        : base(new char[,] { { Symbol } }, Color.Gray, position)
    {
        return;
    }
}
