using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math2D
{
    public class Circle : Shape
    {
        // Instance variables
        public Position position;
        public double radius;

        // Constructor
        public Circle(Position position, double radius) {
            this.position = position;
            this.radius = radius;
        }

        // Method to check if shape is colliding with another shape
        public override bool isColliding(Polygon polygon)
        {
            return true;
        }

        // Method to check if shape is colliding with another shape
        public override bool isColliding(Circle circle)
        {
            return true;
        }

        // Method to check if shape is inside another shape
        public override bool isContained(Polygon polygon)
        {
            return true;
        }

        // Method to check if shape is inside another shape
        public override bool isContained(Circle circle)
        {
            return true;
        }
    }
}
