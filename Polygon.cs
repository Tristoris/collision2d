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

        // Constructor
        public Polygon(Position position, Vector2[] points, double angle = 0)
        {
            this.position = position;
            this.points = points;
            this.angle = angle;
            this.currentPoints = this.points;
        }

        // Method to check if shape is colliding with another shape
        public override bool isColliding(Polygon polygon)
        {
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
            return new Axis[1]; // temporary
        }

        public Projection project (Axis axis)
        {
            // temporary
            return new Projection(new Position(0,0), new Vector2(1, 1));
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
    }
}
