using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Box : Shape
    {
        public Pixel corner1;
        public Pixel corner2;
        public int width;
        public int height;

        public Box(int x1, int y1, int x2, int y2) : this(new Pixel(x1, y1), new Pixel(x2, y2))
        {
        }

        public Box(Pixel lu, Pixel rd)
        {
            this.corner1 = lu;
            this.corner2 = rd;
            this.width = Math.Abs(this.corner1.x - this.corner2.x);
            this.height = Math.Abs(this.corner1.y - this.corner2.y);
        }

        override public void Draw()
        {
            graph.DrawRectangle(pen, corner1.x + position.x, corner1.y + position.y,
                width, height);
        }
    }
}
