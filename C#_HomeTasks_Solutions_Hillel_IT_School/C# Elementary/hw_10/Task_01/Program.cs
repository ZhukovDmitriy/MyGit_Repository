using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Создайте анонимный метод,
 * который принимает в качестве параметров
 * три целочисленных аргумента
 * и возвращает среднее арифметическое этих аргументов.
 */
namespace Task_01
{
    delegate double AverageValue(int a, int b, int c);

    class Program
    {
        static void Main(string[] args)
        {
            double result;

            AverageValue averageValue = delegate (int a, int b, int c)
            {
                double aV = 0;

                aV = a + b + c;
                aV = aV / 3;

                return aV;
            };

            result = averageValue(1, 1, 3);

            Console.WriteLine("Среднее арифметическое = " + result);

            Console.ReadKey();
        }
    }
}
