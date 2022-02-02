using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    abstract class Shape
    {
        protected Pixel position;

        protected Graphics graph;
        protected Pen pen;

        public Shape()
        {
            pen = new Pen(Color.Black);
        }

        public void SetGraphics(Graphics graph)
        {
            this.graph = graph;
        }

        public void SetPen(Pen pen)
        {
            this.pen = pen;
        }

        abstract public void Draw();

        virtual public void Move(Pixel position)
        {
            this.position = position;
        }
    }
}
