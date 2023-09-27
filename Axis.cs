using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace Math2D
{
    // the axis onto which a shape should be projected
    public sealed class Axis
    {
        public Vector2 axis;
        public Axis(Vector2 vector) {
            axis = new Vector2(vector.X / vector.Length(), vector.Y / vector.Length());
        }

        public double dot(Vector2 v) {
            //float vNorm = (float)Math.Pow(Math.Pow(v.X, 2) + Math.Pow(v.Y, 2), 0.5);

            //double angle = Math.Cos(Math.Sinh());

            return this.axis.X * v.X + this.axis.Y * v.Y; //temp
        }
    }
}
