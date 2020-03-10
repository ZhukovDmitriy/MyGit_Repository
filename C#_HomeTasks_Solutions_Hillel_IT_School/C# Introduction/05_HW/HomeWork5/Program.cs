using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "05_HW";
            
            // Задача 1 
            Console.WriteLine("\tЗадача 1");
            Console.WriteLine("В алгоритмах иногда требуется найти" +
                "\nминимальную целую неотрицательную степень двойки, превосходящую данное число."
                + "\nРешите эту задачу с помощью цикла while.");

            Console.Write("\nВведите целое положительное число: ");
            int num = Convert.ToInt32(Console.ReadLine());
            int pow = 0;

            while (Math.Pow(2, pow) <= num) pow++;
            Console.WriteLine("Минимальная степень двойки превосходящее заданное вами число равна: {0}", pow);

            Console.WriteLine("\nПроверка: ");                                          // Проверка
            Console.WriteLine("2 в степени {0} = {1}", pow - 1, Math.Pow(2, pow - 1));
            Console.WriteLine("2 в степени {0} = {1}", pow, Math.Pow(2, pow));
            Console.WriteLine("Для перехода к следующей задаче нажмите Enter... ");
            Console.ReadKey();

            // Задача 2 
            Console.WriteLine("\n\tЗадача 2");
            Console.WriteLine("Напишите программу, которая текст печатает на экран в рамочке" + "\nиз символов +, - и |" +
                "\nДля красоты текст должен отделяться от рамки слева и справа пробелом.\n");

            Console.Write("Введите слово, предложение, любой символ: ");
            string str = Console.ReadLine();
            int strLenght = str.Length;

            Console.Write("+");

            for (int i = 0; i < strLenght + 2; i++)
            {
                Console.Write("-");
            }

            Console.Write("+");
            Console.WriteLine("\n| " + str + " |");
            Console.Write("+");

            for (int i = 0; i < strLenght + 2; i++)
            {
                Console.Write("-");
            }

            Console.Write("+");
            Console.WriteLine("\nДля перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();

            // Задача 3 
            Console.WriteLine("\n\tЗадача 3");
            Console.WriteLine("Дано целое неотрицательное число N." +
                "\nНайти число, составленное теми же десятичными цифрами, что и N," + "\nно в обратном порядке." +
                "\nЗапрещено использовать массивы.");

            Console.Write("\nВведите целое положительное число: ");
            int N = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nВведенное вами число в обратном порядке: ");

            for (; N > 0; N /= 10)
            {
                Console.Write(N % 10);
            }

            Console.WriteLine("\nДля перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();

            //  Задача 3 - Альтернативное решение через цикл While
            /*
            Console.Write("\nВведите целое положительное число: ");
            int Nalt = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nВведенное вами число в обратном порядке: {0}", Nalt % 10);

            while ((Nalt /= 10) != 0)
            {
                Console.Write(Nalt % 10);
            }

            Console.WriteLine("\nДля перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            */
            
            // Задача 4
            Console.WriteLine("\n\tЗадача 4");
            Console.WriteLine("Дано N (1 <= N <= 27)." +
                "\nНайти количество трехзначных натуральных чисел, сумма цифр которых равна N." +
                "\nОперации деления (/, %) не использовать.");

            int N1, count = 0;

            do
            {
                Console.Write("\nВведите число в интервале 1 - 27 : ");
                int.TryParse(Console.ReadLine(), out N1);

            } while ((N1 < 1) || (N1 > 27));

            Console.WriteLine("\nТрёхзначные числа сумма цифр которых равна {0}: ", N1);

            for (int i = 1; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        if (i + j + k == N1)
                        {
                            count++;
                            Console.WriteLine("{0}{1}{2}", i, j, k);
                        }
                    }
                }
            }

            Console.WriteLine("Общее количесво трёхзначных чисел: {0}", count);
            Console.WriteLine("Для перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            
            // Задача 6
            Console.WriteLine("\n\tЗадача 6");
            Console.WriteLine("Имитация алгоритма для работы СТЕКа. Дана строка из символов '(' и ')'." +
                "\nОпределить, является ли она корректным скобочным выражением.\nОпределить максимальную глубину вложенности скобок.");

            Console.WriteLine("\nВведите скобочное выражение: ");
            string str1 = Console.ReadLine();
            int str1length = str1.Length;
            int a = 0;
            int aMax = 0;
            
            for (int i = 0; i <= str1.Length - 1; i++)
            {
                {
                    if (a < 0)          // Если a = -1; это будет означать что введена недопустимая ')' без предшествующей ей '('                                 
                        break;
                }

                if (str1[i] == '(')
                {
                    a++;
                    if (aMax < a)               
                    {
                        aMax++;         // Самое большое зафиксированное значение переменной а ( аналог максимально зафиксированного размера условного стека.)
                    }
                }

                else if (str1[i] == ')')
                {
                    a--;
                }
            }

            if (a == 0)
            {
                Console.WriteLine("Выражение верное ");             
                Console.WriteLine("Максимальная вложенность скобок: {0}", aMax);
            }
            else
                Console.WriteLine("Выражение ложное ");             // Для ложного выражения, глубину вложенности не показываем
            Console.WriteLine("Для завершения работы программы нажмите Enter...");
            Console.ReadKey();

        }
    }
}











