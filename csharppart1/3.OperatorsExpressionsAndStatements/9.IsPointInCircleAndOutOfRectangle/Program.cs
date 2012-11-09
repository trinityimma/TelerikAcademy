// Write an expression that checks for given point (x, y) if it is within the
// circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6,
// height=2).

using System;

class Program
{
    static void Main()
    {
        int px = 0;
        int py = 2;

        int kx = 1;
        int ky = 1;
        int kr = 3;

        int rx = -1;
        int ry = 1;
        int rw = 6;
        int rh = 2;

        bool isInCircle = Math.Pow(px - kx, 2) + Math.Pow(py - ky, 2) < Math.Pow(kr, 2);
        bool isOutOfRectangle = 
            px < rx ||
            px > rx + rw ||
            py > ry ||
            py < ry - rh;

        Console.WriteLine("Is  is in circle: {0}", isInCircle);
        Console.WriteLine("Is out of rectangle: {0}", isOutOfRectangle);
        Console.WriteLine("In circle and out of rectangle: {0}", (isInCircle && isOutOfRectangle));
    }
}
