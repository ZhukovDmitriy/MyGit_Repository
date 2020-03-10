using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Создать класс с именем Rectangle. 
 * В теле класса создать два поля, описывающие длины сторон double side1, side2.
 * Создать пользовательский конструктор Rectangle(double side1, double side2),
 * в теле которого поля side1 и side2 инициализируются значениями аргументов.
 * Создать два метода, вычисляющие площадь прямоугольника - double AreaCalculator()
 * и периметр прямоугольника - double PerimeterCalculator().
 * Создать два свойства double Area и double Perimeter с одним методом доступа get.
 * Написать программу, которая принимает от пользователя длины двух сторон прямоугольника
 * и выводит на экран периметр и площадь.
 */
namespace Task_04
{
    class Rectangle // Прямоугольник
    {
        private double side1;       // Длина первой стороны прямоугольника
        private double side2;       // Длина второй стороны прямоугольника

        public double Side1 { get => side1; }
        public double Side2 { get => side2; }

        public Rectangle(double side1, double side2)
        {
            this.side1 = side1;
            this.side2 = side2;
        }

        private double AreaCalculator()              // Метод вычисляющий площадь прямоугольника
        {
            return Side1 * Side2;
        }

        private double PeremeterCalculator()         // Метод вычисляющий периметр прямоугольника
        {
            return (Side1 + Side2) * 2;
        }

        public double Area { get => AreaCalculator(); }
        public double Perimeter { get => PeremeterCalculator(); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину двух сторон прямоугольника: ");
            Console.Write("\nСторона A: ");
            double side1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Сторона B: ");
            double side2 = Convert.ToDouble(Console.ReadLine());

            Rectangle rectangle = new Rectangle(side1, side2);

            Console.WriteLine("\nПлощадь прямоугльника: {0}", rectangle.Area);
            Console.WriteLine("\nПериметр прямоугольника: {0}", rectangle.Perimeter);

            Console.ReadKey();
        }
    }
}
