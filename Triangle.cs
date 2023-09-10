using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math2D
{
    public class Triangle : Polygon
    {

        // Constructor
        public Triangle(Position[] points) : base(points)
        {
            if (points.Length == 3) this.points = points;
            else {
                this.points = new Position[] { new Position(0,0), new Position(1,1), new Position (2,2) };
            }
        }
    }
}
