using System;

namespace CohesionAndCoupling
{
    class RectangularCuboid
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }

        public double Volume
        {
            get { return Width * Height * Depth; }
        }

        public double CalcDiagonalXY()
        {
            return GeometryUtils.CalcDistance2D(0, 0, Width, Height);
        }

        public double CalcDiagonalYZ()
        {
            return GeometryUtils.CalcDistance2D(0, 0, Height, Depth);
        }

        public double CalcDiagonalZX()
        {
            return GeometryUtils.CalcDistance2D(0, 0, Depth, Width);
        }

        public double CalcDiagonalXYZ()
        {
            return GeometryUtils.CalcDistance3D(0, 0, 0, Width, Height, Depth);
        }
    }
}
