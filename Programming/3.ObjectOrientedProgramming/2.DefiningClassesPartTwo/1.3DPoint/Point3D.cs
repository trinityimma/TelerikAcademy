using System;

struct Point3D
{
    public double X, Y, Z;

    static readonly Point3D zero = new Point3D();

    public static Point3D Zero
    {
        get { return zero; }
    }

    public Point3D(int x, int y, int z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public override string ToString()
    {
        return String.Format("X: {0}, Y: {1}, Z: {2}", this.X, this.Y, this.Z);
    }
}
