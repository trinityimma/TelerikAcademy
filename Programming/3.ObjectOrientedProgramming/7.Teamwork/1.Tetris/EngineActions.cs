using System;

partial class Engine
{
    public void MoveLeft(object sender, EventArgs e)
    {
        if (GetCollidedObject(this.controlledObject, Coordinates.Left) == null)
            this.controlledObject.MoveLeft();
    }

    public void MoveRight(object sender, EventArgs e)
    {
        if (GetCollidedObject(this.controlledObject, Coordinates.Right) == null)
            this.controlledObject.MoveRight();
    }

    public void Rotate(object sender, EventArgs e)
    {
        this.controlledObject.Rotate();

        // Reverse move
        if (GetCollidedObject(this.controlledObject) != null)
        {
            this.controlledObject.Rotate();
            this.controlledObject.Rotate();
            this.controlledObject.Rotate();
        }
    }

    private void ResetAnimationDelay(object sender, EventArgs e)
    {
        this.animationDelay = Engine.DefaultDelay;
    }

    public void Drop(object sender, EventArgs e)
    {
        this.animationDelay = Engine.TurboDelay;
    }
}
