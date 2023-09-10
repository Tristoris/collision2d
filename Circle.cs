using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math2D
{
    public class Circle : Shape
    {
        public Position position;
        public double radius;

        public Circle(Position position, double radius) {
            this.position = position;
            this.radius = radius;
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
