using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RunGame
{
    class Box : Игрок
    {
        public Rectangle box { get; private set; }
        public Color color { get; private set; }
        int sx;
        int sy;

        public Box(int x, int y, int w, int h)
            : this(x, y, w, h, 0, 0)
        {
        }

        public Box(int x, int y, int w, int h, int sx, int sy)
        {
            box = new Rectangle(x, y, w, h);
            color = Color.Green;
            this.sx = sx;
            this.sy = sy;
        }

        public void Беги()
        {
            Move();
        }

        private void Move()
        {
            int x = box.X + sx;
            int y = box.Y + sy;
            if (x < 0 || x > Arena.Range.Width - box.Width)
                sx = -sx;
            if (y < 0 || y > Arena.Range.Height - box.Height)
                sy = -sy;
            box = new Rectangle(box.X + sx, box.Y + sy,
                box.Width, box.Height);
        }

        public void Голя()
        {
            color = Color.Red;
        }

        public void НеГоля()
        {
            color = Color.Green;
        }

        public bool Поймал(Игрок that)
        {
            Crosser crosser = new Crosser();
            return crosser.Cross(this, that);
        }
    }
}
