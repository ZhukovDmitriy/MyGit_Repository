using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "HW_07";
            // Задача 1
            Console.WriteLine("\tЗадача 1");
            Console.WriteLine("Найдите индексы первого вхождения максимального элемента." +
                "\nВыведите два числа: номер строки и номер столбца,\nв которых стоит наибольший элемент в двумерном массиве." +
                "\nЕсли таких элементов несколько, то выводится тот,\nу которого меньше номер строки," +
                "\nа если номера строк равны то тот,\nу которого меньше номер столбца.\n");

            int index1 = 5;
            int index2 = 5;
            int[,] arr = new int[index1, index2];
            Random random = new Random();
            int Max = arr[0, 0];

            for (int i = 0; i < index1; i++)
            {
                for (int j = 0; j < index2; j++)
                {
                    arr[i, j] = random.Next(1, 11);
                    Console.Write(arr[i, j] + "\t");
                }

                Console.WriteLine("\n");
            }

            int iMax = 0, jMax = 0;

            for (int i = 0; i < index1; i++)
            {
                for (int j = 0; j < index2; j++)
                {
                    if (arr[i, j] > Max)
                    {
                        Max = arr[i, j];
                        iMax = i + 1;
                        jMax = j + 1;
                    }
                }
            }

            Console.WriteLine("Номер строки максимального элемента: {0}\nНомер столбца максимального элемента: {1}", iMax, jMax);
            Console.WriteLine("Для перехода к следующей задаче нажмиете Enter...");

            // Задача 2 
            Console.WriteLine("\n\tЗадача 2");
            Console.WriteLine("Дано нечетное число n.\nСоздайте двумерный массив из n x n элементов, заполнив его символами \".\"" +
                "\n(каждый элемент массива является строкой из одного символа)." +
                "\nЗатем заполните символами \" * \" среднюю строку массива,\nсредний столбец массива, главную диагональ и побочную диагональ." +
                "\nВ результате единицы в массиве должны образовывать изображение звездочки." +
                "\nВыведите полученный массив на экран, разделяя элементы массива пробелами.");

            int n;
            do
            {
                Console.Write("\nЗадайте размерность квадратного массива (в интервале 5 - 25)\nВведите нечетное число: ");
                int.TryParse(Console.ReadLine(), out n);
            } while (n % 2 == 0);

            string[,] arr2 = new string[n, n];

            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j || i == n - 1 - j || i == n / 2 || j == n / 2)
                    {
                        arr2[i, j] = "*";
                        Console.Write(arr2[i, j] + "  ");
                    }
                    else
                    {
                        arr2[i, j] = ".";
                        Console.Write(arr2[i, j] + "  ");
                    }
                }

                Console.WriteLine("\n");
            }

            Console.WriteLine("\nДля перехода к следующей задаче нажмите Enter...");

            // Задача 3 
            Console.WriteLine("\n\tЗадача 3");
            Console.WriteLine("Дан квадратный массив.\nПоменяйте местами элементы, стоящие на главной и побочной диагонали," +
                "\nпри этом каждый элемент должен остаться в том же столбце" +
                "\n(то есть в каждом столбце нужно поменять местами элемент \nна главной диагонали и на побочной диагонали)");

            Console.Write("\nЗадайте размерность квадратного массива \n(для понятного отображение введите числа в интервале 3 - 8): ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            int[,] arr3 = new int[n2, n2];
            int num = 1;
            int buffer;

            Console.WriteLine("\nВаш массив: \n");

            for (int i = 0; i < n2; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    arr3[i, j] = num++;
                    Console.Write(arr3[i, j] + "\t");
                }

                Console.WriteLine("\n\n\n");
            }

            for (int i = 0; i < n2; i++)
            {
                buffer = arr3[i, i];                    // Значение по заданным координатам arr3[i, i] записываем во временную переменную buffer
                                                        // теперь можем присвоить arr3[i, i] новое значение.
                arr3[i, i] = arr3[n2 - 1 - i, i];       // присваиваем arr3[i, i] заначение по координатам arr3[n2 - 1 -i, i]
                arr3[n2 - 1 - i, i] = buffer;           // далее значению по координатам arr3[n2 - 1 -i, i] присваиваем значение из временной переменной buffer
                                                        // тоесть перестановка выполнена по правилу "трех стаканов"
                                                        // для двумерного массива размерностью n = 2 : 
                                                        // [0, 0] -> buffer 
                                                        // [1, 0] -> [0, 0]
                                                        // buffer -> [1, 0] ... аналогично и для второй итерации цикла i = 1; [1, 1] 
            }
            /*
            // Аналогичное решение для случая когда нужно помянять диагонали по строкам _ Оставил для себя _
            for (int i = 0; i < n2; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    if (i == j)
                    {
                        buffer = arr3[i, n2 - i - 1];
                        arr3[i, n2 - 1 - i] = arr3[i, j];
                        arr3[i, j] = buffer;
                    }
                }
            }
            */
            Console.WriteLine("\nИзмененный массив: \n");

            for (int i = 0; i < n2; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    Console.Write(arr3[i, j] + "\t");
                }

                Console.WriteLine("\n\n\n");
            }

            Console.WriteLine("Для перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();

            //Задача 4 
            Console.WriteLine("\n\tЗадача 4 ");
            Console.WriteLine("Дан прямоугольный массив размером n x m.\nПоверните его на 90 градусов по часовой стрелке," +
                "\nзаписав результат в новый массив размером m x n.");

            Console.WriteLine("\nЗадайте размерность прямоугольного массива");
            Console.Write("Введите n (количество строк): ");
            int n3 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите m (количество столбцов): ");
            int m3 = Convert.ToInt32(Console.ReadLine());

            int[,] arr4 = new int[n3, m3];                      // Создаем массив arr4 расположения n x m 
            int[,] arr5 = new int[m3, n3];                      // Создаем "повернутый" массив arr5 расположением m x n
            int num2 = 1;

            Console.WriteLine("\nВывод массива n x m: \n");

            for (int i = 0; i < n3; i++)                        // Заполняем массив arr4 (n x m) числами от 1-ого до ...num и выводим его
            {
                for (int j = 0; j < m3; j++)
                {
                    arr4[i, j] = num2++;
                    Console.Write(arr4[i, j] + "\t");
                }

                Console.WriteLine("\n");
            }

            for (int i = 0; i < n3; i++)
            {
                for (int j = 0; j < m3; j++)
                {
                    arr5[j, n3 - 1 - i] = arr4[i, j];   // Учитывая условия задачи заполняем массив arr5 (m x n) по определенным координатам [j, n3 - 1 - i] 
                                                        // числами из массива arr4 (n x m) по координатам [i, j]  
                }
            }

            Console.WriteLine("\nМассив повернутый на 90 градусов по часовой стрелке (m x n): \n");

            for (int i = 0; i < m3; i++)
            {
                for (int j = 0; j < n3; j++)
                {
                    Console.Write(arr5[i, j] + "\t");
                }

                Console.WriteLine("\n");
            }

            Console.WriteLine("Для завершения работы программы нажмите Enter...");
            Console.ReadKey();
        }
    }
}







