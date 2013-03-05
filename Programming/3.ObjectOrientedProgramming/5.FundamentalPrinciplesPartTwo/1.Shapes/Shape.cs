using System;

abstract class Shape
{
    public double Width { get; private set; }
    public double Height { get; private set; }

    public Shape(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public abstract double CalculateSurface();

    public override string ToString()
    {
        return String.Format("Type: {0}; Width: {1}; Height: {2}; Surface: {3}",
            this.GetType(), this.Width, this.Height, this.CalculateSurface());
    }
}
