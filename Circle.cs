using Math2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Math2D
{
    public sealed class Circle : Shape
    {
        // Instance variables
        public Position position;
        public double radius;
        public double currentRadius;

        // Constructor
        public Circle(Position position, double radius) {
            this.position = position;
            this.radius = radius;
            this.currentRadius = radius;
        }

        // Method to check if shape is colliding with another shape
        // checks the smallest distance of the closest segment of the shape
        // if it is smaller than the radius -> return colliding: true
        public override bool isColliding(Polygon polygon)
        {
            polygon.updateVertices();
            Vector2[] closestVectors = polygon.getClosest(this.position.x, this.position.y);

            double dx = Math.Pow(this.position.x - closestVectors[0].X, 2);
            double dy = Math.Pow(this.position.y - closestVectors[0].Y, 2);
            double distance = Math.Sqrt(dx + dy);

            if (this.radius >= distance) return true;

            double x = closestVectors[1].X - closestVectors[0].X;

            if (x == 0) {
                if (Math.Abs(closestVectors[0].X - this.position.x) < this.currentRadius) return true;
                else return false;
            }
            double yDelta = closestVectors[1].Y - closestVectors[0].Y;
            //Console.WriteLine("y: " + yDelta);
            double m = yDelta / x;
            //Console.WriteLine("m: " + m);
            double c = closestVectors[0].Y - (m * closestVectors[0].X);
            //Console.WriteLine("c: " + c);
            double a = m * m + 1;
            //Console.WriteLine("a: " + a);
            double p = 2 * (c * m + -this.position.x + m * -this.position.y) / a;
            //Console.WriteLine("p: " + p);
            double q = (c * c + 2 * c * -this.position.y +  this.position.y * this.position.y + this.position.x * this.position.x - this.currentRadius * this.currentRadius) / a;
            //Console.WriteLine("q: " + q);
            double determinant = p * p / 4 - q;

            //Console.WriteLine("determinant: " + determinant);

            if (determinant < 0) return false;

            double p2 = p / (-2);

            double x1 = p2 + Math.Sqrt(determinant);

            double x2 = p2 - Math.Sqrt(determinant);

            //Console.WriteLine(x1 + " " + x2);

            if (closestVectors[0].X < closestVectors[1].X )
            {
                //Console.WriteLine("uwu");
                if (x2 > closestVectors[0].X || x1 < closestVectors[1].X) return true;
                return false;
            }
            else {
                //Console.WriteLine("awa");
                if (x2 > closestVectors[1].X || x1 < closestVectors[0].X) return true;
                return false;
            }
            //for (int i = 0; i < closestVectors.Length; i++) { Console.WriteLine(closestVectors[i]); }        
            
            //return true;
        }

        // Method to check if shape is colliding with another shape
        public override bool isColliding(Circle circle)
        {
            double dx = Math.Pow(this.position.x - circle.position.x, 2);
            double dy = Math.Pow(this.position.y - circle.position.y, 2);
            double distance = Math.Sqrt(dx + dy);

            if (this.radius + circle.currentRadius >= distance) return true;

            return false;
        }

        // Method to check if shape is inside another shape
        public override bool isContained(Polygon polygon)
        {
            // TODO: WORKS ONLY IF POLYGON INSIDE CIRCLE, NOT OTHERWISE
            polygon.updateVertices();

            foreach (Vector2 v in polygon.vertices)
            {
                double dx = Math.Pow(this.position.x - v.X, 2);
                double dy = Math.Pow(this.position.y - v.Y, 2);
                double distance = Math.Sqrt(dx + dy);

                if (this.radius > distance) return false;
            }

            return true;
        }

        // Method to check if shape is inside another shape
        public override bool isContained(Circle circle)
        {
            if (this.radius == circle.radius) return false;

            double dx = Math.Pow(this.position.x - circle.position.x, 2);
            double dy = Math.Pow(this.position.y - circle.position.y, 2);
            double distance = Math.Sqrt(dx + dy);

            if (this.currentRadius > circle.currentRadius && this.currentRadius > circle.currentRadius + distance) return true;
            else if (circle.currentRadius > this.currentRadius + distance) return true;
            return false;
        }

        // resize the changed up radius of the circle by a percentage
        public override void resizeCurrent(double percentage)
        {
            this.currentRadius = percentage * this.currentRadius;
        }

        // resize the original by a percentage
        public override void resizeOriginal(double percentage)
        {
            this.currentRadius = percentage * this.radius;
        }

        // change the position of the circle
        public override void changePosition(double x, double y)
        {
            this.position = new Position(x, y);
        }

    }
}
