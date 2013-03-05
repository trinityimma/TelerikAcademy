using System;

abstract class Shape : IShape
{
    public double Width { get; private set; }
    public double Height { get; private set; }

    public Shape(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    protected double CalculateSurface(double c)
    {
        return this.Width * this.Height * c;
    }

    public abstract double CalculateSurface();

    protected string ToString(string type)
    {
        return String.Format("Rectangle: {0}; Width: {1}; Height: {2}; Surface: {3}",
            type, this.Width, this.Height, this.CalculateSurface());
    }
}
