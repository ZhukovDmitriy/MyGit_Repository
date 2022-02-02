using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometry
{
    public struct Pixel
    {
        public int x;
        public int y;

        public Pixel(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int distance(Pixel pixel)
        {
            return Convert.ToInt32(Math.Sqrt(
                (this.x - pixel.x) * (this.x - pixel.x) +
                (this.y - pixel.y) * (this.y - pixel.y)));
        }
    }

    public partial class Form1 : Form
    {
        Sprite snowman1;
        Sprite snowman2;

        Circle circle;
        Line line;
        Box box;

        Bitmap bmp;
        Graphics graph;
        Pen pen;

        Pixel A, B, C, D, E, F, G, H, I, J, K, L, M, O;

        public Form1()
        {
            InitializeComponent();
            Init();
            //Demo();
            InitSnowman1();
            InitSnowman2();
            Draw();
        }

        private void Init()
        {
            bmp = new Bitmap(picture.Width, picture.Height);
            graph = Graphics.FromImage(bmp);
            pen = new Pen(Color.Blue);
        }

        private void Demo()
        {
            Pixel P = new Pixel(100, 100);

            A = new Pixel(0, 0);
            circle = new Circle(A, 20);
            //circle = new Circle(new Pixel(0, 0), 20);

            circle.SetGraphics(graph);
            circle.Move(P);
            circle.Draw();

            line = new Line(0, 20, 0, 100);
            line.SetGraphics(graph);
            line.Move(P);
            line.Draw();

            box = new Box(-20, -20, 20, -40);
            box.SetGraphics(graph);
            box.Move(P);
            box.Draw();

            picture.Image = bmp;
        }

        private void InitSnowman1()
        {
            A = new Pixel(219, 63);
            B = new Pixel(220, 177);
            C = new Pixel(223, 401);
            D = new Pixel(218, 98);
            E = new Pixel(221, 259);
            F = new Pixel(158, 129);
            G = new Pixel(64, 200);
            H = new Pixel(282, 131);
            I = new Pixel(366, 200);
            J = new Pixel(140, 493);
            K = new Pixel(188, 537);
            L = new Pixel(242, 492);
            M = new Pixel(283, 534);

            snowman1 = new Sprite();

            snowman1.SetGraphics(graph);

            snowman1.AddShape(new Circle(A, D));
            snowman1.AddShape(new Circle(B, D));
            snowman1.AddShape(new Circle(C, E));
            snowman1.AddShape(new Line(F, G));
            snowman1.AddShape(new Line(H, I));
            snowman1.AddShape(new Box(J, K));
            snowman1.AddShape(new Box(L, M));
        }

        private void InitSnowman2()
        {
            A = new Pixel(219, 63);
            B = new Pixel(220, 177);
            C = new Pixel(223, 401);
            D = new Pixel(218, 98);
            E = new Pixel(221, 259);
            F = new Pixel(158, 129);
            G = new Pixel(64, 200);
            H = new Pixel(282, 131);
            I = new Pixel(366, 200);
            J = new Pixel(140, 493);
            K = new Pixel(188, 537);
            L = new Pixel(242, 492);
            M = new Pixel(283, 534);

            snowman2 = new Sprite();

            snowman2.SetGraphics(graph);

            snowman2.AddShape(new ColorCircle(A, D, Color.Red));
            snowman2.AddShape(new ColorCircle(B, D, Color.Green));
            snowman2.AddShape(new ColorCircle(C, E, Color.Yellow));
            snowman2.AddShape(new ColorLine(F, G, Color.Blue));
            snowman2.AddShape(new ColorLine(H, I, Color.Brown));
            snowman2.AddShape(new ColorBox(J, K, Color.Orange));
            snowman2.AddShape(new ColorBox(L, M, Color.Gold));

            snowman2.Move(new Pixel(150, 0));
        }

        private void Draw()
        {
            snowman1.Draw();
            snowman2.Draw();
            picture.Image = bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void picture_Click(object sender, EventArgs e)
        {

        }

        private void buttonMoveMe_Click(object sender, EventArgs e)
        {
            Pixel P = new Pixel(100, 50);
            snowman1.Move(P);
            snowman2.Move(new Pixel(350, 2));
            Draw();
        }
    }
}
