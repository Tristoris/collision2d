using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math2D
{
    // Abstract class shape
    public abstract class Shape
    {
        // Abstract methods for shapes
        public abstract bool isColliding(Polygon polygon);
        public abstract bool isColliding(Circle circle);
        public abstract bool isContained(Polygon polygon);
        public abstract bool isContained(Circle circle);
    }
}
