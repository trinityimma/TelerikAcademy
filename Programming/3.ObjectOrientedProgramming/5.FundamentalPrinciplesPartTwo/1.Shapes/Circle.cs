using System;

class Circle : Ellipse
{
    public Circle(double width)
        : base(width, width)
    {
    }

    public override string ToString()
    {
        return base.ToString("Circle");
    }
}
