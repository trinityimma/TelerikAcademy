using System;
using System.Collections.Generic;

class Path
{
    private List<Point3D> points = null;

    public Path()
    {
        this.points = new List<Point3D>();
    }

    public void Add(Point3D point)
    {
        this.points.Add(point);
    }

    public void Remove(Point3D point)
    {
        this.points.Remove(point);
    }

    public override string ToString()
    {
        List<string> info = new List<string>();

        foreach (Point3D point in this.points)
            info.Add(point.ToString());

        return String.Join(Environment.NewLine, info);
    }
}
