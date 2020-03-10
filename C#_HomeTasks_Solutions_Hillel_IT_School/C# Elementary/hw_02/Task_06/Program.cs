using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Создать классы Point и Figure.
 * Класс Point должен содержать два целочисленных поля и одно строковое поле.
 * Создать три свойства с одним методом доступа get.
 * Создать пользовательский конструктор, в теле которого проинициализируйте поля значениями аргументов.
 * Класс Figure должен содержать конструкторы, которые принимают от 3-х до 5-ти аргументов типа Point.
 * Создать два метода: 
 * double LengthSide(Point A, Point B), который рассчитывает длину стороны многоугольника;
 * void PerimeterCalculator(), который рассчитывает периметр многоугольника.
 * Написать программу, которая выводит на экран название и периметр многоугольника.
 */
namespace Task_06
{
    class Point // Точка
    {
        private int coordX = 0;                     // Координаты точки по оси X
        private int coordY = 0;                     // Координаты точки по оси Y
        private string figureName = string.Empty;   // Название фигуры

        public int CoordX { get => coordX; }
        public int CoordY { get => coordY; }
        public string FigureName { get => figureName; }

        public Point(int x, int y, string Name)
        {
            coordX = x;
            coordY = y;
            figureName = Name;
        }
    }

    class Figure // Фигура
    {
        Point point1, point2, point3, point4, point5;                            // Обьекты класса Point содержащие аргументы для конструкторов
        string FigureName = string.Empty;

        public Figure(Point p1, Point p2, Point p3)                              // Конструктор с тремя параметрами - triangle 
        {
            point1 = p1;
            point2 = p2;
            point3 = p3;
            FigureName = "triangle";
        }

        public Figure(Point p1, Point p2, Point p3, Point p4)                    // Конструктор с четырмя параметрами - tetragon 
        {
            point1 = p1;
            point2 = p2;
            point3 = p3;
            point4 = p4;
            FigureName = "tetragon";
        }

        public Figure(Point p1, Point p2, Point p3, Point p4, Point p5)          // Конструктор с пятью параметрами - pentagon
        {
            point1 = p1;
            point2 = p2;
            point3 = p3;
            point4 = p4;
            point5 = p5;
            FigureName = "pentagon";
        }

        public double LenghtSide(Point A, Point B)                               // Метод расчета длины одной стороны многоугольника
        {
            return Math.Sqrt(Math.Pow((A.CoordX - B.CoordX), 2) + Math.Pow((A.CoordY - B.CoordY), 2));
        }

        public void PerimeterCalculator()                                        // Метод рассчета периметра многоугольника
        {
            if (FigureName == "triangle")                                        // Расчет периметра для треугольника
            {
                double trianglePerimeter = LenghtSide(point1, point2) + LenghtSide(point2, point3) + LenghtSide(point3, point1);
                Console.WriteLine("Периметр фигуры {0} равен {1}", FigureName, trianglePerimeter);
            }

            else if (FigureName == "tetragon")                                   // Расчет периметра для четырёхугольника
            {
                double trianglePerimeter = LenghtSide(point1, point2) + LenghtSide(point2, point3) + LenghtSide(point3, point4) + LenghtSide(point4, point1);
                Console.WriteLine("Периметр фигуры {0} равен {1}", FigureName, trianglePerimeter);
            }

            else if (FigureName == "pentagon")                                   // Расчет периметра для пятиугольника     
            {
                double pentagonPerimeter = LenghtSide(point1, point2) + LenghtSide(point2, point3) + LenghtSide(point3, point4) + LenghtSide(point4, point5) + LenghtSide(point5, point1);
                Console.WriteLine("Периметр фигуры {0} равен {1}", FigureName, pentagonPerimeter);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(5, 10, "a");
            Point point2 = new Point(15, 20, "b");
            Point point3 = new Point(25, 30, "c");
            Point point4 = new Point(35, 40, "d");
            Point point5 = new Point(45, 50, "f");

            Figure triangle = new Figure(point1, point2, point3);
            Figure tetragon = new Figure(point1, point2, point3, point4);
            Figure pentagon = new Figure(point1, point2, point3, point4, point5);

            triangle.PerimeterCalculator();
            tetragon.PerimeterCalculator();
            pentagon.PerimeterCalculator();

            Console.ReadKey();
        }
    }
}
