using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Geometry
{
    class ColorBox : Box
    {
        public ColorBox(int x1, int y1, int x2, int y2, Color color)
            : this(new Pixel(x1, y1), new Pixel(x2, y2), color)
        {
        }

        public ColorBox(Pixel lu, Pixel rd, Color color) 
            : base (lu, rd)
        {
            this.pen = new Pen(color);
        }
    }
}
