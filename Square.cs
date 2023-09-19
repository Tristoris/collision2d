using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Math2D
{
    public class Square : Polygon
    {

        // Constructor
        public Square(Position position, Vector<double>[] points) : base(position, points)
        {
            if (points.Length == 3) { this.position = position; this.points = points; }
            else
            {
                this.position = new Position(0, 0);
                this.points = new Vector<double>[] { new Vector<double>( new double[] { 1, 1 }), new Vector<double>( new double[] { 2, 2 }), new Vector<double>( new double[] { 3, 3 }) };
            }
        }
    }
}
