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
            this.points = points;
        }
    }

}
