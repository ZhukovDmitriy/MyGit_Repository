using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "04_HW  \"Циклы\" (Часть 1)";
            // Задача 1
            Console.WriteLine("\tЗадача 1\nНайти сумму положительных нечетных чисел, меньших 50.\n");

            int sum = 0;
            for (int i = 0; i < 50; i++)
            {
                if (i % 2 == 1)
                    sum += i;
            }
            Console.WriteLine("Сумма нечетных чисел равна: {0}", sum);
            Console.WriteLine("Для перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();

            // Задача 2 
            Console.WriteLine("\n\tЗадача 2\nНайти сумму целых положительных чисел из промежутка от a до b, кратных четырем.\n");

            int a = 0, b = 20;
            int sum4 = 0;

            for (int i = a; i < b; i++)
            {
                if (i % 4 == 0)
                    sum4 += i;
            }
            Console.WriteLine("Сумма чисел кратных четырём равна: {0}", sum4);
            Console.WriteLine("Для перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();

            // Задача 3
            Console.WriteLine("\n\tЗадача 3\nНайти:\nа) все двузначные числа, сумма квадратов цифр которых делится на 13;" +
                "\nб) все двузначные числа, обладающие следующим свойством:" +
                "\nесли к сумме цифр числа прибавить квадрат этой суммы,\nто получится снова искомое число\n");

            int a1 = 0;         // Первая цифра 
            int a2 = 0;         // Вторая цифра 
            int sum1 = 0;

            Console.WriteLine("Выполнение условия а): ");
            for (int i = 10; i < 100; i++)
            {
                a1 = i / 10;
                a2 = i % 10;
                if ((Math.Pow(a1, 2) + Math.Pow(a2, 2)) % 13 == 0)
                    Console.Write(" " + i);
            }

            Console.WriteLine("\n\nВыполнение условия б): ");
            for (int i = 10; i < 100; i++)
            {
                a1 = i / 10;
                a2 = i % 10;
                sum1 = a1 + a2;
                if (sum1 + Math.Pow(sum1, 2) == i)
                    Console.Write(" " + i);
            }
            Console.WriteLine("\nДля перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();

            // Задача 4
            Console.WriteLine("\n\tЗадача 4");
            Console.WriteLine("Даны натуральное число n и вещественные числа\n" + "Найти:" +
                "\nа) максимальное из вещественных чисел;\nб) минимальное из вещественных чисел; " +
                "\nв) максимальное и минимальное из вещественных чисел." +
                "\nПримечание В задаче (в) использовать только один оператор цикла\n");

            int[] Array = new int[10] { 19, 23, 18, 32, 17, 11, 20, 40, 22, 31, };
            int max = Array[9];
            int min = Array[0];

            for (int i = 0; i < Array.Length; i++)          // Нахождние Максимального числа
            {
                if (Array[i] > max)
                    max = Array[i];
            }
            Console.WriteLine("Максимальное вещественное число: " + max);

            for (int i = 0; i < Array.Length; i++)          // Нахождение Минимального числа
            {
                if (Array[i] < min)
                    min = Array[i];
            }
            Console.WriteLine("\nМинимальное вещественное число: " + min);

            for (int i = 0; i < Array.Length; i++)          // Нахождение Максимального и Минимального значение в одном цикле for
            {
                if (Array[i] > max)
                    max = Array[i];
                else if (Array[i] < min)
                    min = Array[i];
            }
            Console.WriteLine("\nМаксимальное и Минимальное значения равны: {0}; {1} ", max, min);
            Console.WriteLine("Для перехода к следующей задача нажмите Enter...");
            Console.ReadKey();

            // Задача 5
            Console.WriteLine("\n\tЗадача 5");
            Console.WriteLine("Даны два целых числа A и B (A < B)." +
                "\nНайти сумму и произведение всех целых чисел от A до B включительно.");

            int a3 = 10, b3 = 40, sum2 = 0;
            long mult = 1;

            for (int i = a3; i <= b3; i++)
            {
                sum2 += i;
                mult *= i;
            }
            Console.WriteLine("\nСумма всех целых чисел равна: " + sum2);
            Console.WriteLine("\nПроизведение всех целых чисел: " + mult);
            Console.WriteLine("Для перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();

            // Задача 6
            Console.WriteLine("\n\tЗадача 6");
            Console.WriteLine("Даны два целых числа A и B (A < B)." +
            "\nВывести в порядке возрастания все целые числа,\nрасположенные между A и B (включая сами числа A и B)," +
                "\nа также количество N этих чисел.\n");

            int a5 = 25, b5 = 75, n = 0;

            Console.WriteLine("Числа между А и B: ");

            for (int i = a5; i <= b5; i++)
            {
                Console.Write(i + " ");
                n++;
            }
            Console.WriteLine("\n\nКоличество чисел между A и B: " + n);
            Console.WriteLine("Для перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();

            // Задача 7
            Console.WriteLine("\n\tЗадача 7");
            Console.WriteLine("Дано вещественное число — цена 1 кг конфет.\nВывести стоимость 1.2, 1.4, …, 2 кг конфет.");

            double price1kg = 10;   // стоимость за 1 кг конфет
            double price;

            Console.WriteLine("\nСтоимость за 1 кг конфет равна: {0} грн", price1kg);

            for (double i = 1.2; i <= 2; i += 0.2)
            {
                price = price1kg * i;
                Console.WriteLine("Стоимость за " + i + " кг конфет равна: " + price + " грн");
            }
            Console.WriteLine("Для перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();

            // Задача 8
            Console.WriteLine("\n\tЗадача 8");
            Console.WriteLine("Даны целые положительные числа A и B (A < B)." +
                "\nВывести все целые числа от A до B включительно;" +
                "\nпри этом каждое число должно выводиться столько раз," +
                "\nкаково его значение (например, число 3 выводится 3 раза).\n");

            int a7 = 5, b7 = 15;

            for (int i = a7; i <= b7; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < i; j++)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine("\nДля завершения работы программы нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}


