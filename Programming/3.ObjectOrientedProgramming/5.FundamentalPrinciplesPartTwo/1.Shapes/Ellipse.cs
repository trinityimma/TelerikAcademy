using System;

class Ellipse : Shape
{
    public Ellipse(double width, double height)
        : base(width, height)
    {
    }

    public override double CalculateSurface()
    {
        return base.CalculateSurface(Math.PI);
    }

    public override string ToString()
    {
        return base.ToString("Ellipse");
    }
}
