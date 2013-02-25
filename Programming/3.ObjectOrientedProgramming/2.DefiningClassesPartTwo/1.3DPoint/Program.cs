using System;

class Program
{
    static void Main()
    {
        {
            Console.WriteLine("# Testing distance");

            Console.WriteLine("Distance: {0}", Distance.Calculate(new Point3D(1, 1, 1), Point3D.Zero));
            Console.WriteLine();
        }

        {
            Console.WriteLine("# Testing path");

            Point3D point = new Point3D(1, 1, 1);

            Path path = new Path();

            path.Add(point);
            path.Add(new Point3D(1, 2, 1));
            path.Add(new Point3D(1, 3, 1));
            path.Add(Point3D.Zero);

            Console.WriteLine(path);
            Console.WriteLine();

            {
                Console.WriteLine("# Testing remove");

                path.Remove(point);

                Console.WriteLine(path);
                Console.WriteLine();
            }

            {
                Console.WriteLine("# Testing path storage");

                PathStorage.Write(path);
                path = PathStorage.Load();

                Console.WriteLine(path);
            }
        }
    }
}
