using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Geometry
{
    class ColorCircle : Circle
    {
        public ColorCircle(int x, int y, int radius, Color color) 
            : this(new Pixel(x, y), radius, color)
        {
        }

        public ColorCircle(Pixel center, int radius, Color color) 
            : base (center, radius)
        {
            this.pen = new Pen(color);
        }

        public ColorCircle(Pixel center, Pixel point, Color color)
            : this(center, center.distance(point), color)
        {
        }
    }
}
