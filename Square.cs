using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Math2D
{
    public class Square : Polygon
    {

        // Constructor
        public Square(Position position, Vector[] points) : base(position, points)
        {
            if (points.Length == 3) { this.position = position; this.points = points; }
            else
            {
                this.position = new Position(0, 0);
                this.points = new Vector[] { new Vector(1, 1), new Vector(2, 2), new Vector(3,3) };
            }
        }
    }
}
