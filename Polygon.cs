using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Math2D
{
    // Polygon class
    public class Polygon : Shape
    {
        // Instance variables
        public Position position;
        public Vector2[] points;
        public double angle;
        public Vector2[] currentPoints;
        public Vector2[] vertices;

        // Constructor
        public Polygon(Position position, Vector2[] points, double angle = 0)
        {
            this.position = position;
            this.points = points;
            this.angle = angle;
            this.currentPoints = new Vector2[this.points.Length];
            for (int i = 0; i < points.Length; i++) this.currentPoints[i] = new Vector2(this.points[i].X, this.points[i].Y);
            this.vertices = new Vector2[this.points.Length + 1];
            //this.updateVertices();
        }

        // Method to check if shape is colliding with another shape
        public override bool isColliding(Polygon polygon)
        {
            this.updateVertices();
            polygon.updateVertices();
            //for (int i = 0; i < this.points.Length; i++) Console.WriteLine(this.points[i]);

            Axis[] axes1 = this.getAxes();
            Axis[] axes2 = polygon.getAxes();
            //Console.WriteLine("axes1");
            // loop over the axes1
            for (int i = 0; i < axes1.Length; i++)
            {
                //Console.WriteLine("i: " + i);
                Axis axis = axes1[i];
                // project both shapes onto the axis
                Projection p1 = this.project(axis);
                Projection p2 = polygon.project(axis);

                //Console.WriteLine("p1: " + p1.min + " " + p1.max);
                //Console.WriteLine("p2: " + p2.min + " " + p2.max);
                // do the projections overlap?
                int result = (int)p1.overlap(p2);
                if (result == (int)Result.outside)
                {
                    return false;
                }
            }

            //Console.WriteLine("axes2");
            // loop over the axes2
            for (int i = 0; i < axes2.Length; i++)
            {
                //Console.WriteLine("i: " + i);
                Axis axis = axes2[i];
                // project both shapes onto the axis
                Projection p1 = this.project(axis);
                Projection p2 = polygon.project(axis);

                // do the projections overlap?
                int result = (int)p1.overlap(p2);
                //Console.WriteLine("result: " + result);
                if (result == (int)Result.outside) {
                    return false;
                }
            }

            return true;
        }

        // Method to check if shape is colliding with another shape
        public override bool isColliding(Circle circle)
        {
            this.updateVertices();
            Vector2[] closestVectors = this.getClosest(circle.position.x, circle.position.y);

            double dx = Math.Pow(circle.position.x - closestVectors[0].X, 2);
            double dy = Math.Pow(circle.position.y - closestVectors[0].Y, 2);
            double distance = Math.Sqrt(dx + dy);

            if (circle.radius >= distance) return true;

            double x = closestVectors[1].X - closestVectors[0].X;

            if (x == 0) {
                if (Math.Abs(closestVectors[0].X - circle.position.x) < circle.currentRadius) return true;
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
            double p = 2 * (c * m + -circle.position.x + m * -circle.position.y) / a;
            //Console.WriteLine("p: " + p);
            double q = (c * c + 2 * c * -circle.position.y +  circle.position.y * circle.position.y + circle.position.x * circle.position.x - circle.currentRadius * circle.currentRadius) / a;
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
        }

        // Method to check if shape is inside another shape
        public override bool isContained(Polygon polygon)
        {
            this.updateVertices();
            polygon.updateVertices();
            //for (int i = 0; i < this.points.Length; i++) Console.WriteLine(this.points[i]);

            Axis[] axes1 = this.getAxes();
            Axis[] axes2 = polygon.getAxes();
            //Console.WriteLine("axes1");
            // loop over the axes1
            for (int i = 0; i < axes1.Length; i++)
            {
                //Console.WriteLine("i: " + i);
                Axis axis = axes1[i];
                // project both shapes onto the axis
                Projection p1 = this.project(axis);
                Projection p2 = polygon.project(axis);

                //Console.WriteLine("p1: " + p1.min + " " + p1.max);
                //Console.WriteLine("p2: " + p2.min + " " + p2.max);
                // do the projections overlap?
                int result = (int)p1.overlap(p2);
                if (result == (int)Result.outside || result == (int)Result.overlaps)
                {
                    return false;
                }
            }

            //Console.WriteLine("axes2");
            // loop over the axes2
            for (int i = 0; i < axes2.Length; i++)
            {
                //Console.WriteLine("i: " + i);
                Axis axis = axes2[i];
                // project both shapes onto the axis
                Projection p1 = this.project(axis);
                Projection p2 = polygon.project(axis);

                // do the projections overlap?
                int result = (int)p1.overlap(p2);
                //Console.WriteLine("result: " + result);
                if (result == (int)Result.outside || result == (int)Result.overlaps)
                {
                    return false;
                }
            }

            return true;
        }

        // Method to check if shape is inside another shape
        public override bool isContained(Circle circle)
        {
            return true;
        }

        public Axis[] getAxes () {
            // temporary
            Axis[] axes = new Axis[this.vertices.Length];
            // loop over the vertices
            for (int i = 0; i < this.vertices.Length; i++)
            {
                // get the current vertex
                Vector2 p1 = this.vertices[i];
                // get the next vertex
                Vector2 p2 = this.vertices[i + 1 == this.vertices.Length ? 0 : i + 1];
                // subtract the two to get the edge vector
                Vector2 edge = p1 - p2;
                // get either perpendicular vector
                Vector2 normal = new Vector2(-edge.Y, edge.X);
                // the perp method is just (x, y) =&gt; (-y, x) or (y, -x)
                axes[i] = new Axis(normal);
            }
            return axes;
        }

        public Projection project (Axis axis)
        {
            // temporary
            double min = axis.dot(this.vertices[0]);
            double max = min;
            for (int i = 1; i < this.vertices.Length; i++)
            {
                // NOTE: the axis must be normalized to get accurate projections
                double p = axis.dot(this.vertices[i]);
                if (p < min)
                {
                    min = p;
                }
                else if (p > max)
                {
                    max = p;
                }
                //Console.WriteLine(p);
            }
            Projection proj = new Projection(min, max);
            return proj;
        }

        public void setAngle(double angle) {
            this.angle = angle % 360;
            //Console.WriteLine("angle " + this.angle);
            if (this.angle == 0)
            {
                for (int i = 0; i < this.points.Length; i++)
                {
                    this.currentPoints[i].X = this.points[i].X;
                    this.currentPoints[i].Y = this.points[i].Y;
                }
            }
            else
            {
                for (int i = 0; i < this.points.Length; i++)
                {
                    double currentAngle = 180 / Math.PI * (this.points[i].Y / Math.Abs(this.points[i].Y)) * Math.Acos(this.points[i].X / this.points[i].Length());
                    //Console.WriteLine(currentAngle);
                    this.currentPoints[i].X = (float)(this.points[i].Length() * Math.Cos(this.degreesToRadians(this.angle + currentAngle)));
                    this.currentPoints[i].Y = (float)(this.points[i].Length() * Math.Sin(this.degreesToRadians(this.angle + currentAngle)));
                    //Console.WriteLine(this.currentPoints[i].X + " " + currentPoints[i].Y);
                }
            }
        }

        public override void resizeCurrent(double percentage) {
            for (int i = 0; i < this.points.Length; i++)
            {
                this.currentPoints[i].X = (float)(percentage * this.currentPoints[i].Y);
                this.currentPoints[i].Y = (float)(percentage * this.currentPoints[i].Y);
            }
        }

        public override void resizeOriginal(double percentage)
        {
            for (int i = 0; i < this.points.Length; i++)
            {
                this.currentPoints[i].X = (float)(percentage * this.points[i].Y);
                this.currentPoints[i].Y = (float)(percentage * this.points[i].Y);
            }
        }

        public override void changePosition(double x, double y) {
            this.position = new Position(x, y);
        }

        public void updateVertices() {
            vertices[0] = new Vector2((float)this.position.x, (float)this.position.y);
            //Console.WriteLine("vertice " + vertices[0]);
            for (int i = 0; i < this.currentPoints.Length; i++) {
                vertices[i + 1] = new Vector2(this.vertices[0].X + this.currentPoints[i].X, this.vertices[0].Y + this.currentPoints[i].Y);
                //Console.WriteLine("vertice " + vertices[i + 1]);
            }
        }

        private double degreesToRadians(double angle) {
            return Math.PI / 180 * angle;
        }

        public Vector2[] getClosest(double x, double y) {
            Vector2[] vectors = new Vector2[2];

            Vector2 pos = new Vector2((float)x, (float)y);

            Vector2 min = new Vector2(0,0);
            Vector2 secondMin = new Vector2(0, 0);

            double minLength = Double.MaxValue;
            double secondMinLength = minLength;

            for (int i = 0; i < this.vertices.Length; i++)
            {
                // NOTE: the axis must be normalized to get accurate projections
                double length = (this.vertices[i] - pos).Length();
                if (length < secondMinLength)
                {
                    if (length < minLength) {
                        secondMin = new Vector2(min.X, min.Y);
                        secondMinLength = minLength;
                        min = this.vertices[i];
                        minLength = length;
                    } else
                    {
                        secondMin = this.vertices[i];
                        secondMinLength = length;
                    }
                }
                //Console.WriteLine(p);
            }

            vectors[0] = min;
            vectors[1] = secondMin;

            return vectors;
        } 
    }
}
