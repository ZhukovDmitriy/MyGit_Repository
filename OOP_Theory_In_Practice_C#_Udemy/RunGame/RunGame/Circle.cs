using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RunGame
{
    class Circle : Игрок
    {
        public Point center { get; private set; }
        public int radius { get; private set; }
        public Color color { get; private set; }
        int sx;
        int sy;

        public Circle(int x, int y, int r)
            : this (x, y, r, 0, 0)
        {
        }

        public Circle(int x, int y, int r, int sx, int sy)
        {
            center = new Point(x, y);
            radius = r;
            color = Color.Blue;
            this.sx = sx;
            this.sy = sy;
        }

        public void Беги()
        {
            int x = center.X + sx;
            int y = center.Y + sy;
            if (x < radius || x > Arena.Range.Width - radius)
                sx = -sx;
            if (y < radius || y > Arena.Range.Height - radius)
                sy = -sy;
            center = new Point(center.X + sx, center.Y + sy);
        }

        public void Голя()
        {
            color = Color.Red;
        }

        public void НеГоля()
        {
            color = Color.Blue;
        }

        public bool Поймал(Игрок that)
        {
            Crosser crosser = new Crosser();
            return crosser.Cross(this, that);
        }
    }
}
