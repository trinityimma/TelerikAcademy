using System;

class Program
{
    static void Main()
    {
        Point3D point = new Point3D(1, 1, 1);

        Console.WriteLine("Distance: {0}", Distance.Calculate(point, Point3D.Zero));

        Path path = new Path();

        path.Add(point);
        path.Add(point);
        path.Add(Point3D.Zero);

        Console.WriteLine(path);
        Console.WriteLine();

        path.Remove(point);

        Console.WriteLine(path);
        Console.WriteLine();

        Console.WriteLine("# Testing Pathstorage");
        
        PathStorage.Write(path);
        path = PathStorage.Load();

        Console.WriteLine(path);
    }
}
