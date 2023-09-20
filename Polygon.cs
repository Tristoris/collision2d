using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            this.currentPoints = this.points;
            this.vertices = new Vector2[this.points.Length + 1];
            this.updateVertices();
        }

        // Method to check if shape is colliding with another shape
        public override bool isColliding(Polygon polygon)
        {
            this.updateVertices();

            Axis[] axes1 = this.getAxes();
            Axis[] axes2 = this.getAxes();

            // loop over the axes1
            for (int i = 0; i < axes1.Length; i++)
            {
                Axis axis = axes1[i];
                // project both shapes onto the axis
                Projection p1 = this.project(axis);
                Projection p2 = polygon.project(axis);
                // do the projections overlap?
                if (!p1.overlap(p2))
                {
                    // then we can guarantee that the shapes do not overlap
                    return false;
                }
            }

            // loop over the axes2
            for (int i = 0; i < axes2.Length; i++)
            {
                Axis axis = axes2[i];
                // project both shapes onto the axis
                Projection p1 = this.project(axis);
                Projection p2 = polygon.project(axis);
                // do the projections overlap?
                if (!p1.overlap(p2))
                {
                    // then we can guarantee that the shapes do not overlap
                    return false;
                }
            }

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
            this.angle = angle;

            for (int i = 0; i < this.points.Length; i++)
            {
                this.currentPoints[i].X = (float)Math.Cos(angle * this.points[i].X) - (float)Math.Sin(angle * this.points[i].Y);
                this.currentPoints[i].Y = (float)Math.Sin(angle * this.points[i].X) + (float)Math.Cos(angle * this.points[i].Y);
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

        private void updateVertices() {
            vertices[0] = new Vector2((float)this.position.x, (float)this.position.y);

            for (int i = 0; i < this.points.Length; i++) {
                vertices[i + 1] = new Vector2(this.vertices[0].X + this.points[i].X, this.vertices[0].Y + this.points[i].Y);
            }
        }
    }
}
