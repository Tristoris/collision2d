using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Math2D
{
    // just a triangle
    public sealed class Triangle : Polygon
    {

        // Constructor
        public Triangle(Position position, Vector2[] points) : base(position, points)
        {
            if (points.Length == 2) { this.position = position; this.points = points; }
            else
            {
                this.position = new Position(0, 0);
                this.points = new Vector2[] { new Vector2(1, 1), new Vector2(2, 2) };
            }
        }
    }
}
