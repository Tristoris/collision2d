using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math2D
{
    public class Square : Polygon
    {

        // Constructor
        public Square(Position position, Position[] points) : base(position, points)
        {
            if (points.Length == 3) { this.position = position; this.points = points; }
            else
            {
                this.position = new Position(0, 0);
                this.points = new Position[] { new Position(1, 1), new Position(2, 2), new Position(3,3) };
            }
        }
    }
}
