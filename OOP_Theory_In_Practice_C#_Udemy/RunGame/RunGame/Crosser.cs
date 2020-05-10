using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunGame
{
    class Crosser
    {
        public bool Cross(Игрок o1, Игрок o2)
        {
            if (o1.GetType() == typeof(Circle))
                return Cross((Circle)o1, o2);
            if (o1.GetType() == typeof(Box))
                return Cross((Box)o1, o2);
            return false;
        }

        public bool Cross(Circle circle, Игрок o2)
        {
            if (o2.GetType() == typeof(Circle))
                return Cross(circle, (Circle)o2);
            if (o2.GetType() == typeof(Box))
                return Cross(circle, (Box)o2);
            return false;
        }

        public bool Cross(Box box, Игрок o2)
        {
            if (o2.GetType() == typeof(Circle))
                return Cross(box, (Circle)o2);
            if (o2.GetType() == typeof(Box))
                return Cross(box, (Box)o2);
            return false;
        }

        public bool Cross(Circle c1, Circle c2)
        {
            return distance(c1.center, c2.center) <=
                            c1.radius + c2.radius;
        }

        public bool Cross(Circle circle, Box box)
        {
            if (!Cross(new Rectangle(
                circle.center.X - circle.radius, circle.center.Y - circle.radius,
                2 * circle.radius, 2 * circle.radius),
                box.box))
                return false;
            return
                circle.radius >= distance(circle.center, new Point(box.box.Left, box.box.Top)) ||
                circle.radius >= distance(circle.center, new Point(box.box.Left, box.box.Bottom)) ||
                circle.radius >= distance(circle.center, new Point(box.box.Right, box.box.Top)) ||
                circle.radius >= distance(circle.center, new Point(box.box.Right, box.box.Bottom));
        }

        public bool Cross(Box box1, Circle circle2)
        {
            return Cross(circle2, box1);
        }

        public bool Cross(Box box1, Box box2)
        {
            return Cross(box1.box, box2.box);
        }

        private int distance(Point p, Point q)
        {
            return Convert.ToInt16(Math.Sqrt((p.X - q.X) * (p.X - q.X) + (p.Y - q.Y) * (p.Y - q.Y)));
        }

        private bool Cross(Rectangle RectA, Rectangle RectB)
        {
            return (RectA.Left <= RectB.Right &&
                RectA.Right >= RectB.Left &&
                RectA.Bottom >= RectB.Top &&
                RectA.Top <= RectB.Bottom);
        }
    }
}
