using System;
using System.Linq;
using System.Text.RegularExpressions;

struct Point3D
{
    private static readonly string separator = "-";

    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    private static readonly Point3D zero = new Point3D();

    public static Point3D Zero {
        get { return zero; }
    }

    public Point3D(double x, double y, double z)
        : this()
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public static Point3D Parse(string point)
    {
        double[] coordinates = Regex.Split(point, separator).Select(
            coordinate => double.Parse(coordinate)
        ).ToArray();

        return new Point3D(coordinates[0], coordinates[1], coordinates[2]);
    }

    public override string ToString()
    {
        return String.Join(separator, this.X, this.Y, this.Z);
    }
}
