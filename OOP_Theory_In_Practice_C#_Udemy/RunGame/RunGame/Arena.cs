using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace RunGame
{
    class Arena
    {
        static public Size Range { get; private set; }
        static Random random = new Random();

        PictureBox picture;
        Graphics graphics;

        public Arena(PictureBox picture)
        {
            this.picture = picture;
            Range = picture.Size;
            this.picture.Image = new Bitmap(Range.Width, Range.Height);
            graphics = Graphics.FromImage(this.picture.Image);
            Clear();
        }

        public void Clear()
        {
            graphics.Clear(picture.BackColor);
        }

        public void Show(Игрок obj)
        {
            if (obj.GetType() == typeof(Circle))
                Show((Circle)obj);
            if (obj.GetType() == typeof(Box))
                Show((Box)obj);
        }

        public void Show(Circle circle)
        {
            Pen pen = new Pen(circle.color);

            graphics.DrawEllipse(pen,
                circle.center.X - circle.radius, circle.center.Y - circle.radius,
             2*circle.radius, 2*circle.radius);
        }

        public void Show(Box box)
        {
            Pen pen = new Pen(box.color);
            graphics.DrawRectangle(pen, box.box);
        }

        public void Refresh()
        {
            picture.Refresh();
        }

        static public Circle NewCircle()
        {
            int r = random.Next(Range.Width / 50, Range.Width / 20);
            int x = random.Next(r, Range.Width - r);
            int y = random.Next(r, Range.Height - r);
            int sx = random.Next(-5, +6);
            int sy = random.Next(-5, +6);

            return new Circle(x, y, r, sx, sy);
        }

        static public Box NewBox()
        {
            int w = random.Next(8, 25);
            int h = random.Next(8, 25);
            int x = random.Next(0, Range.Width - w);
            int y = random.Next(0, Range.Height - h);
            int sx = random.Next(-5, +6);
            int sy = random.Next(-5, +6);

            return new Box(x, y, w, h, sx, sy);
        }
    }
}
