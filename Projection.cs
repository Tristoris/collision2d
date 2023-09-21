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
        public enum Result {
             overlaps = 0,
             contains,
             outside
        }

        // Variables
        double min;
        double max;

        // Constructors
        public Projection(double min, double max) {
            this.min = min;
            this.max = max;
        }

        // Methods
        public Result overlap(Projection p) {
            if (p.min < this.max && this.max < p.max) return Result.overlaps;
            else if (this.min < p.max && p.max < this.max) return Result.overlaps;
            else if (p.min < this.max && p.max < this.max) return Result.contains;
            else if (this.min < p.max && this.max < p.max) return Result.contains;
            return Result.outside;
        }
    }
}
