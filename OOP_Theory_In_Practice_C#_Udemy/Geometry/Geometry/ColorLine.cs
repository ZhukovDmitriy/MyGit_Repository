using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class ColorLine : Line
    {
        public ColorLine(int x1, int y1, int x2, int y2, Color color) 
            : this(new Pixel(x1, y1), new Pixel(x2, y2), color)
        {
        }

        public ColorLine(Pixel begin, Pixel ended, Color color)
            : base(begin, ended)
        {
            this.pen = new Pen(color);
        }
    }
}
