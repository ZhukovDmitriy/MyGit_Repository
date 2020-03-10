using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_01
{
    class Program
    {
        static void Main(string[] args)
        {
            double pi = Math.PI;                                               // Задача 1
            Console.WriteLine("\tЗадача 1.\nВывести на экран число Пи.");
            Console.WriteLine("нажмите Enter чтобы получить ответ...");
            Console.ReadKey();
            Console.WriteLine("\nЧисло Пи = " + pi);
            Console.WriteLine("чтобы перейти к следующей задаче нажмите Enter...");
            Console.ReadKey();
            Console.WriteLine();

            double d = 7.15;                                                // Задача 2 
            int i = 100;
            Console.WriteLine("\tЗадача 2.\nВывести на одной строке числа 7,15 и 100 с двумя пробелами между ними.");
            Console.WriteLine("для продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.WriteLine("\n" + d + "  " + i);
            Console.WriteLine("перейти к следующей задаче нажмите Enter...");
            Console.ReadKey();
            Console.WriteLine();

            string surname = "Жуков";                                        // Задача 3
            string firstname = "Дмитрий";
            string patronymic = "Юрьевич";
            int age = 30;
            Console.WriteLine("\tЗадача 3.\nНаписать программу для отображения Ваших данных – ФИО, сколько лет и т.д.");
            Console.WriteLine("нажмиет Enter...");
            Console.ReadKey(); 
            Console.WriteLine("\nФИО студента:\n" + surname + "\n" + firstname + "\n" + patronymic);
            Console.WriteLine("\nВозраст:\n" + age + " лет");
            Console.WriteLine("ожидание Enter...");
            Console.ReadKey();
            Console.WriteLine();

            // Задача 4

            Console.WriteLine("\tЗадача 4.\nКласс System.Environment.Написать программу\nдля вывода на консоль сведений о компьютере.");
            Console.WriteLine("продолжить Enter...");
            Console.ReadKey();
            Console.WriteLine("\nСведения о компьютере:");
            Console.WriteLine(" - Версия Windows: {0}", Environment.OSVersion);
            Console.WriteLine(" - 64 Bit операционная система?: {0}", Environment.Is64BitOperatingSystem);
            Console.WriteLine(" - Имя компьютера: {0}", Environment.MachineName);
            Console.WriteLine(" - Число процессоров: {0}", Environment.ProcessorCount);
            Console.WriteLine(" - Системная папка: {0}", Environment.SystemDirectory);
            Console.WriteLine("перейти к следующей задаче, нажмите Enter...");
            Console.ReadKey();
            Console.WriteLine();

            // Задача 5

            Console.WriteLine("\tЗадача 5.\nСоставить программу вывода на экран числа, вводимого с клавиатуры." +
            "\nВыводимому числу должно предшествовать сообщение \"Вы ввели число\".");
            double num = 0;
            try
            {
                Console.WriteLine("\nВведите число: ");
                num = Convert.ToDouble(Console.ReadLine());                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }      
            Console.WriteLine("Вы ввели число: " + num);
            Console.WriteLine("\nВсе задачи решены, для выхода из программы нажмите любую клавишу...");
            Console.ReadKey();

        }
    }
}
