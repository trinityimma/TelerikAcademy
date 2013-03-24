using System;

public class Cylinder : Figure, IAreaMeasurable, IVolumeMeasurable
{
    public double Radius { get; set; }
    public double Height { get; set; }

    public Cylinder(Vector3D bottom, Vector3D top, double radius)
        : base(bottom, top)
    {
        this.Radius = radius;
        this.Height = (vertices[0] - vertices[1]).Magnitude;
    }

    public override double GetPrimaryMeasure()
    {
        return this.GetVolume();
    }

    public double GetArea()
    {
        return 2 * Math.PI * this.Radius * (this.Radius + this.Height);
    }

    public double GetVolume()
    {
        return Math.PI * this.Radius * this.Radius * this.Height;
    }
}
