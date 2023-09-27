using Math2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Math2D
{
    // a projection of a shape onto an axis
    public class Projection
    {

        // Variables
        public double min;
        public double max;

        // Constructors
        public Projection(double min, double max) {
            this.min = min;
            this.max = max;
        }

        // Methods
        // returns the result of the shape overlapping; an overlap, a containment or neither
        public Shape.Result overlap(Projection p) {
            if (p.min < this.max && this.max < p.max) return Shape.Result.overlaps;
            else if (this.min < p.max && p.max < this.max) return Shape.Result.overlaps;
            else if (p.min <= this.max && p.max >= this.max) return Shape.Result.contains;
            else if (this.min <= p.max && this.max >= p.max) return Shape.Result.contains;
            else if (this.max == p.max && this.min == p.min) return Shape.Result.overlaps;
            return Shape.Result.outside;
        }
    }
}
