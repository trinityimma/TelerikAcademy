using System;

class Program
{
    public class Shape
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
    }

    public static Shape Rotate(Shape shape, double angleInRadians)
    {
        double cos = Math.Abs(Math.Cos(angleInRadians));
        double sin = Math.Abs(Math.Sin(angleInRadians));

        return new Shape(
            cos * shape.Width + sin * shape.Height,
            sin * shape.Width + cos * shape.Height
        );
    }
}