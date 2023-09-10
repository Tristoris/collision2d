using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Math2D
{
    public class Polygon : Shape
    {
        public Position[] points;

        public Polygon(Position[] points) {
            this.points = points;
        }

        public override bool isColliding(Polygon polygon)
        {
            return true;
        }

        public override bool isColliding(Circle circle)
        {
            return true;
        }
    }
}
