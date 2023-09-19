using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Math2D
{
    // Polygon class
    public class Polygon : Shape
    {
        // Instance variables
        public Position position;
        public Vector<double>[] points;
        public double angle;

        // Constructor
        public Polygon(Position position, Vector<double>[] points, double angle = 0)
        {
            this.position = position;
            this.points = points;
            this.angle = angle;
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
