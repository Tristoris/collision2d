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
        public double min;
        public double max;

        // Constructors
        public Projection(double min, double max) {
            this.min = min;
            this.max = max;
        }

        // Methods
        public Result overlap(Projection p) {
            //Console.WriteLine("\nstart of overlaptest");
            //Console.WriteLine(this.min + " " + this.max + " " + p.min + " " + p.max + " ");
            if (p.min < this.max && this.max < p.max) return Result.overlaps;
            else if (this.min < p.max && p.max < this.max) return Result.overlaps;
            else if (p.min <= this.max && p.max >= this.max) return Result.contains;
            else if (this.min <= p.max && this.max >= p.max) return Result.contains;
            else if (this.max == p.max && this.min == p.min) return Result.overlaps;
            return Result.outside;
        }
    }
}
