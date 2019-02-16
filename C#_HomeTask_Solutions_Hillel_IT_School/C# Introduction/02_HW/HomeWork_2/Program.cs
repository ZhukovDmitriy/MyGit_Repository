using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задача 1
            Console.WriteLine("\tЗадача 1.\nИмеется 3 переменные типа int x = 10, y = 12, и z = 3;\n" +
                       "Выполните и рассчитайте результат следующих операций для этих переменных: ");
            Console.WriteLine("(1)  x += y - x++ * z");
            Console.WriteLine("(2)  z = --x - y * 5");
            Console.WriteLine("(3)  y /= x + 5 % z");
            Console.WriteLine("(4)  z = x++ + y * 5");
            Console.WriteLine("(5)  x = y - x++ * z");

            int x = 10, y = 12, z = 3;
            Console.WriteLine("\nрезультат первой операции: x = {0}  ", x += y - x++ * z); // 10 * 3 = 30; 12 - 30 = -18; 10 + (-18) = - 8;  
            Console.WriteLine("результат второй операции: z = {0} ", z = --x - y * 5); // -(8) + (-1) = -9; 12 * 5 = 60; - 9 - 60 = -69 
            Console.WriteLine("результат третей операции: y = {0} ", y /= x + 5 % z); // 5 % -69 = 5; -9 + 5 = -4; 12 / -4 = -3;   
            Console.WriteLine("результат четвертой операции: z = {0} ", z = x++ + y * 5); // -9; -3 * 5 = -15; -9 -15 = -24;
            Console.WriteLine("результат пятой операции: x = {0} ", x = y - x++ * z); // -8(второй вызов) * -24 = -192; -3 - 192 = - 195; 

            Console.WriteLine("\nКонечные значения переменных: x, y, z: {0}; {1}; {2}", x, y, z); 
            Console.WriteLine("для перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();

            // Задача 2 
            Console.WriteLine("\n\tЗадача 2 (Без формулировки)");
            double num = 10, num2 = 15, num3 = 30;
            double result = (num + num2 + num3) / 3;
            Console.WriteLine("Среднее арифметическое: " + result);
            Console.WriteLine("нажмите Enter...");
            Console.ReadKey();

            // Задача 3
            Console.WriteLine("\n\tЗадача 3 (Без формулировки)");
            double pi = Math.PI ;
            double r = 20;
            double S = pi * (Math.Pow(r, 2));       // площадь круга s = πr2;
            Console.WriteLine("Площадь круга S = {0}", S);
            Console.WriteLine("переход к следующей задаче Enter...");
            Console.ReadKey();

            // Задача 4  
            Console.WriteLine("\n\tЗадача 4 (Без формулировки)");  
            double R = 20;
            double h = 55;
            double V = (Math.PI * Math.Pow(R, 2)) * h;        // объём цилиндра V = πr2 * h
                                                              // Площадь полной поверхности цилиндра S= 2 π rh+ 2 π r2; или 2 π r(h + r)
            double Scyl = (2 * Math.PI * R * h) + (2 * Math.PI * (Math.Pow(R, 2)));
            Console.WriteLine("Объём цилиндра V = {0}", V );
            Console.WriteLine("Площадь цилиндра S = {0}", Scyl );
            Console.ReadKey();
        }
    }
}
