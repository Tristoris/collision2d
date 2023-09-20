using Math2D;
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
            double dx = Math.Pow(this.position.x - circle.position.x, 2);
            double dy = Math.Pow(this.position.y - circle.position.y, 2);
            double distance = Math.Sqrt(dx + dy);

            if (this.radius + circle.radius >= distance) return true;

            return false;
        }

        // Method to check if shape is inside another shape
        public override bool isContained(Polygon polygon)
        {
            return true;
        }

        // Method to check if shape is inside another shape
        public override bool isContained(Circle circle)
        {
            if (this.radius == circle.radius) return false;

            double dx = Math.Pow(this.position.x - circle.position.x, 2);
            double dy = Math.Pow(this.position.y - circle.position.y, 2);
            double distance = Math.Sqrt(dx + dy);

            if (this.radius > circle.radius && this.radius > circle.radius + distance) return true;
            else if (circle.radius > this.radius + distance) return true;
            return false;
        }
    }
}
