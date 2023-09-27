using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math2D
{
    // Position struct
    public struct Position
    {
        // Instance Variables
        public readonly double x;
        public readonly double y;

        // Constructor
        public Position(double x, double y) {
            this.x = x; this.y = y;
        }

        // get the array representation of the position
        public double[] toArray()
        {
            return new double[] { x, y };
        }
    }
}
