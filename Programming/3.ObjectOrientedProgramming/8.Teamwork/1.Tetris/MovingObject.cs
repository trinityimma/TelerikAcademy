using System;

class MovingObject : GameObject
{
    protected static readonly Coordinates Gravitation = Coordinates.Down;

    public Coordinates Direction { get; protected set; }

    public MovingObject(char[,] image, Color color, Coordinates position, Coordinates direction)
        : base(image, color, position)
    {
        this.Direction = direction;
    }

    public MovingObject(char[,] image, Color color, Coordinates position)
        : this(image, color, position, Gravitation)
    {
        return;
    }

    public virtual void Update()
    {
        this.Position += this.Direction;
    }

    public virtual void MoveLeft()
    {
        this.Position += Coordinates.Left;
    }

    public virtual void MoveRight()
    {
        this.Position += Coordinates.Right;
    }

    public virtual void Rotate()
    {
        this.Image = this.Image.Rotate();
    }
}
