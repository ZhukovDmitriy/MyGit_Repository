using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Circle : Shape
    {
        public Pixel center;
        public int radius;
        public Pixel corner; // Координаты левого верхнего угла
        public int width;
        public int heigth;

        public Circle(int x, int y, int radius) : this(new Pixel(x, y), radius)
        {
        }

        public Circle(Pixel center, int radius)
        {
            this.center = center;
            this.radius = radius;
            this.corner = new Pixel(
                this.center.x - this.radius,
                this.center.y - this.radius);
            this.width = this.heigth = this.radius * 2;
        }

        public Circle(Pixel center, Pixel point) 
            : this(center, center.distance(point))
        {
        }

        override public void Draw()
        {
            graph.DrawEllipse(pen, corner.x + position.x, corner.y + position.y, width, heigth);
        }
    }
}
