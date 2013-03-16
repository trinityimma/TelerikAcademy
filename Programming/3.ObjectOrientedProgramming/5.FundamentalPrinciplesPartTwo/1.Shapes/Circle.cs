using System;

class Circle : Ellipsis
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
