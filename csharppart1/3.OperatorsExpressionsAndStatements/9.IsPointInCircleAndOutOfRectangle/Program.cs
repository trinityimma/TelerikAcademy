using System;

class Program
{
    static void Main()
    {
        int px = 0, py = 2;
        int kx = 1, ky = 1, kr = 3;
        int rx = -1, ry = 1, rw = 6, rh = 2;

        bool isInCircle = Math.Pow(px - kx, 2) + Math.Pow(py - ky, 2) < Math.Pow(kr, 2);
        bool isOutOfRectangle = px < rx || px > rx + rw || py > ry || py < ry - rh;

        Console.WriteLine("In circle and out of rectangle: {0}", (isInCircle && isOutOfRectangle));
    }
}
