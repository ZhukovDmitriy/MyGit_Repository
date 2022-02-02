using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        struct StructPixel
        {
            public int x;
            public int y;

            public StructPixel(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        class ClassPixel
        {
            public int x;
            public int y;

            public ClassPixel(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        static void Main(string[] args)
        {
            StructPixel sp;
            ClassPixel cp;

            sp = new StructPixel(10, 20);
            cp = new ClassPixel(100, 200);

            //MovePixel(ref sp);
            MovePixel(sp, out sp);
            MovePixel(cp);

            Console.WriteLine("Struct value: {0}, {1}", sp.x, sp.y);
            Console.WriteLine("Class value: {0}, {1}", cp.x, cp.y);
            Console.ReadKey();
        }

        //static void MovePixel(ref StructPixel sp)
        //{
        //    sp.x++;
        //    sp.y++;
        //}

        static void MovePixel(StructPixel sp, out StructPixel sp1)
        {
            sp1 = sp;
            sp1.x++;
            sp1.y++;
        }

        static void MovePixel(ClassPixel cp)
        {
            cp.x++;
            cp.y++;
        }
    }
}
