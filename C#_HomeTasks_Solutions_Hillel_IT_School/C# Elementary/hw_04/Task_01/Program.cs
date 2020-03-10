using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Создайте класс Printer.
 * В теле класса создайте метод void Print(string value),
 *  который выводит на экран значение аргумента.
 * Реализуйте возможность того,
 *  чтобы в случае наследования от данного класса других классов,
 *  и вызове соответствующего метода их экземпляра,
 *  строки, переданные в качестве аргументов методов, выводились разными цветами. 
 * Обязательно используйте приведение типов.
 */
namespace Task_01
{
    class Printer
    {
        public virtual void Print(string value)             // Виртуальный метод в базовом классе
        {
            Console.Write("Вызов метода Print() в базовом классе: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(value);
        }
    }

    class ColorRed : Printer
    {
        public override void Print(string value)            // Переопределенный метод Print() в производном классе
        {
            Console.ResetColor();
            Console.Write("Вызов метода Print() в классе ColorRed: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value);
        }
    }

    class ColorGreen : Printer
    {
        public override void Print(string value)            // Переопределенный метод Print() в производном классе
        {
            Console.ResetColor();
            Console.Write("Вызов метода Print() в классе ColorGreen: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(value);
        }
    }

    class ColorBlue : Printer
    {
        public override void Print(string value)            // Переопределенный метод Print() в производном классе
        {
            Console.ResetColor();
            Console.Write("Вызов метода Print() в классе ColorBlue: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(value);
        }
    }

    class OverrideDemo
    {
        static void Main(string[] args)
        {
            Printer colorPrint = new Printer();

            ColorRed red = new ColorRed();
            ColorGreen green = new ColorGreen();
            ColorBlue blue = new ColorBlue();

            Printer colorPrintRef;          // ссылка на базовый класс

            colorPrintRef = colorPrint;
            colorPrintRef.Print("Базовый класс");

            colorPrintRef = red;
            colorPrintRef.Print("Красный цвет");

            colorPrintRef = green;
            colorPrintRef.Print("Зеленый цвет");

            colorPrintRef = blue;
            colorPrintRef.Print("Синий цвет");

            Console.ReadKey();
        }
    }
}
