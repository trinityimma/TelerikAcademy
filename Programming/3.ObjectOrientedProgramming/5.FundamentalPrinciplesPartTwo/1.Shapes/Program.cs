using System;

class Program
{
    static void Main()
    {
        Shape[] shapes = new Shape[]
        {
            new Triangle(3, 4),
            new Rectangle(3, 4),
            new Ellipse(3, 4),
            new Circle(3)
        };

        foreach (Shape shape in shapes)
            Console.WriteLine(shape);
    }
}
