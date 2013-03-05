using System;

class Ellipse : Shape
{
    public Ellipse(double width, double height)
        : base(width, height)
    {
    }

    public override double CalculateSurface()
    {
        return Math.PI * this.Width * this.Height;
    }
}
