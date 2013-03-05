using System;

class Rectangle : Shape
{
    public Rectangle(double width, double height)
        : base(width, height)
    {
    }

    public override double CalculateSurface()
    {
        return base.CalculateSurface(1);
    }

    public override string ToString()
    {
        return base.ToString("Rectangle");
    }
}
