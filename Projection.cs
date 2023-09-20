using Math2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Math2D
{
    public class Projection
    {
        // Variables
        double min;
        double max;

        // Constructors
        public Projection(double min, double max) {
            this.min = min;
            this.max = max;
        }

        // Methods
        public bool overlap(Projection p) {
            return true;
        }
    }
}
