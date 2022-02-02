using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Создайте четыре лямбда оператора для выполнения арифметических действий:
 * (Add – сложение, Sub – вычитание, Mul – умножение, Div – деление).
 * Каждый лямбда оператор должен принимать два аргумента и возвращать результат вычисления.
 * Лямбда оператор деления должен делать проверку деления на ноль.
 * Написать программу, которая будет выполнять арифметические действия указанные пользователем.
 */
namespace Task_02
{
    delegate double MathAction(double num1, double num2);

    class Program
    {
        static void Main(string[] args)
        {
            MathAction add = (double num1, double num2) => num1 + num2;
            MathAction sub = (double num1, double num2) => num1 - num2;
            MathAction mul = (double num1, double num2) => num1 * num2;
            MathAction div = (double num1, double num2) =>
            {
                double result = 0;

                if (num2 == 0)
                {
                    Console.WriteLine("Деление на ноль невозможно!");

                    return num1 / num2;
                }

                else
                {
                    result = num1 / num2;

                    return result;
                }
            };

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
                Console.Write("\nРезультат сложения равен: {0}", add(numFirst, numSecond));
            }

            if (operation == '-')
            {
                Console.WriteLine("\nРезультат вычетания равен: {0}", sub(numFirst, numSecond));
            }

            if (operation == '*')
            {
                Console.WriteLine("\nРезультат умножения равен: {0}", mul(numFirst, numSecond));
            }

            if (operation == '/')
            {
                Console.WriteLine("\nРезультат деления равен: {0}", div(numFirst, numSecond));
            }

            Console.ReadKey();
        }
    }
}
