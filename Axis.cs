using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace Math2D
{
    public class Axis
    {
        public Vector2 axis;
        public Axis(Vector2 vector) {
            float norm = (float)Math.Pow(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2), 0.5);
            axis = new Vector2(vector.X / norm, vector.Y / norm);
        }

        public double dot(Vector2 v) {
            //float vNorm = (float)Math.Pow(Math.Pow(v.X, 2) + Math.Pow(v.Y, 2), 0.5);

            //double angle = Math.Cos(Math.Sinh());

            return this.axis.X * v.X + this.axis.Y * v.Y; //temp
        }
    }
}
