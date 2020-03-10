using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Создать статический класс Calculator,
 * с методами для выполнения основных арифметических операций.
 * Написать программу, которая выводит на экран основные арифметические операции.
 */
namespace Task_01
{
    static class Calculator
    {
        static public double Addition(double numFirst, double numSecond)    // статический метод - Сложения
        {
            return numFirst + numSecond;
        }

        static public double Subtraction(double numFirst, double numSecond)     // статический метод - Вычетания
        {
            return numFirst - numSecond;
        }

        static public double Multiplication(double numFirst, double numSecond)  // статический метод - Умножения
        {
            return numFirst * numSecond;
        }

        static public double Division(double numFirst, double numSecond)    // статический метод - Деления
        {
            if (numSecond == 0)
            {
                Console.WriteLine("\nОперация невозможна!");                
            }

            return numFirst / numSecond;            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double numFirst;
            double numSecond;
            char operation;

            Console.Write("Введите первое значение: ");
            numFirst = double.Parse(Console.ReadLine());

            Console.Write("\nВыберите арифметическую оперцию '+' '-' '*' '/': ");
            operation = char.Parse(Console.ReadLine());

            Console.Write("\nВведите второе значение: ");
            numSecond = double.Parse(Console.ReadLine());

            if (operation == '+')
            {
                Console.Write("\nРезультат сложения равен: {0}", Calculator.Addition(numFirst, numSecond));
            }

            if (operation == '-')
            {
                Console.WriteLine("\nРезультат вычетания равен: {0}", Calculator.Subtraction(numFirst, numSecond));
            }

            if (operation == '*')
            {
                Console.WriteLine("\nРезультат умножения равен: {0}", Calculator.Multiplication(numFirst, numSecond));
            }

            if (operation == '/')
            {
                Console.WriteLine("\nРезультат деления равен: {0}", Calculator.Division(numFirst, numSecond));
            }
            
            Console.ReadKey();           
        }
    }
}
