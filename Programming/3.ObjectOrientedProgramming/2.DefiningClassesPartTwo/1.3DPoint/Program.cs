using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("# Testing distance");

        Console.WriteLine("Distance: {0}", Distance.Calculate(new Point3D(1, 1, 1), Point3D.Zero));

        Console.WriteLine("# Testing path");

        Path path = new Path(
            Point3D.Zero,
            new Point3D(1, 1, 1),
            new Point3D(1, 2, 1),
            new Point3D(1, 3, 1)
        );
        Console.WriteLine(path);

        Console.WriteLine("# Testing add/remove");

        Console.WriteLine(path.Add(new Point3D(1, 2, 4)).Remove(new Point3D(1, 1, 1)));

        Console.WriteLine("# Testing path storage");

        PathStorage.Write(path, "../../input.txt");
        Console.WriteLine(PathStorage.Load("../../input.txt"));
    }
}
