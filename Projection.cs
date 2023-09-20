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
        Position position;
        Vector2 distance;

        // Constructors
        public Projection(Position position, Vector2 distance) {
            this.position = position;
            this.distance = distance;
        }

        // Methods
        public bool overlap(Projection p) {
            return true;
        }
    }
}
