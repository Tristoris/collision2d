using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math2D
{
    public abstract class Shape
    {
        public abstract bool isColliding(Polygon polygon);

        public abstract bool isColliding(Circle circle);
    }
}
