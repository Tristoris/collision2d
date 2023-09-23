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
        public double min;
        public double max;

        // Constructors
        public Projection(double min, double max) {
            this.min = min;
            this.max = max;
        }

        // Methods
        public Shape.Result overlap(Projection p) {
            //Console.WriteLine("\nstart of overlaptest");
            //Console.WriteLine(this.min + " " + this.max + " " + p.min + " " + p.max + " ");
            if (p.min < this.max && this.max < p.max) return Shape.Result.overlaps;
            else if (this.min < p.max && p.max < this.max) return Shape.Result.overlaps;
            else if (p.min <= this.max && p.max >= this.max) return Shape.Result.contains;
            else if (this.min <= p.max && this.max >= p.max) return Shape.Result.contains;
            else if (this.max == p.max && this.min == p.min) return Shape.Result.overlaps;
            return Shape.Result.outside;
        }
    }
}
