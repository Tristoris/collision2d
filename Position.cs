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
        public double x;
        public double y;

        // Constructor
        public Position(double x, double y) {
            this.x = x; this.y = y;
        }

        public double[] toArray()
        {
            return new double[] { x, y };
        }
    }
}
