using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("\tЗадача 1");            // Задача 1 
            Console.WriteLine("Дано целое число.\nЕсли оно является положительным, то прибавить к нему 1;\n" +
                "если отрицательным, то вычесть из него 2;\nесли нулевым, то заменить его на 10.\nВывести полученное число.");
            Console.WriteLine("\nВведите целое число: ");
            int i = Convert.ToInt32(Console.ReadLine());

            if (i > 0)
                Console.WriteLine("Число является положительным: {0}", i + 1);
            else if (i < 0)
                Console.WriteLine("Число является отрицательным: {0}", i - 2);
            else if (i == 0)
                Console.WriteLine("Число равно нолю: {0}", i = 10);
            Console.WriteLine("Для перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            

            
            Console.WriteLine("\n\tЗадача 2 ");           // Задача 2 
            Console.WriteLine("Даны три целых числа.\nНайти количество положительных чисел в исходном наборе");
            Console.WriteLine("\nВведите три целых числа: ");
            Console.WriteLine("Введите первое число: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите третее число: ");
            int num3 = Convert.ToInt32(Console.ReadLine());

            int positive = 0;
            if (num1 > 0)
                positive += 1;
            if (num2 > 0)
                positive += 1;
            if (num3 > 0)
                positive += 1;
            Console.WriteLine("Количество положительных чисел: {0}", positive);
            Console.WriteLine("Для продолжения нажмите Enter...");
            Console.ReadKey();
            

            
            Console.WriteLine("\n\tЗадача 3");          // Задача 3
            Console.WriteLine("Даны три целых числа.\nНайти количество положительных\nи количество отрицательных чисел в исходном наборе.");
            Console.WriteLine("\nВведите три целых числа: ");
            Console.WriteLine("Введите первое число: ");
            int num4 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            int num5 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите третее число: ");
            int num6 = Convert.ToInt32(Console.ReadLine());

            int positive1 = 0;
            int negative = 0;
            if (num4 > 0)           // первый блок 
                positive1 += 1;
            else if (num4 < 0)
                negative += 1;
            if (num5 > 0)           // второй блок 
                positive1 += 1;
            else if (num5 < 0)
                negative += 1;
            if (num6 > 0)           // третий блок 
                positive1 += 1;
            else if (num6 < 0)
                negative += 1;
            Console.WriteLine("Количество положительных чисел: {0}", positive1);
            Console.WriteLine("Количество отрицательных чисел: {0}", negative);
            Console.WriteLine("Для продолжение нажмите Enter...");
            Console.ReadKey();
            

            
            Console.WriteLine("\n\tЗадача 4");          // Задача 4
            Console.WriteLine("Даны две переменные целого типа: A и B.\nЕсли их значения не равны, то присвоить каждой переменной сумму этих значений," +
                "\nа если равны, то присвоить переменным нулевые значения.\nВывести новые значения переменных A и B.");
            Console.WriteLine("\nВведите два целых числа: ");
            Console.WriteLine("Введите первое число: ");
            int A = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            int B = Convert.ToInt32(Console.ReadLine());

            if (A == B)   // Если равны - присвоить переменным нулевые значения
                Console.WriteLine("Вы ввели равные значение двух переменных: A = {0}; B = {1};", A = 0, B = 0);
            else          // Если не равны - присвоить каждой переменной сумму этих значений
                Console.WriteLine("Вы ввели не равные значения двух переменных: A = {0}; B = {1};", A = A + B, B = A);
            Console.WriteLine("Для продолжения нажмите Enter...");
            Console.ReadKey();
            

            
            Console.WriteLine("\n\tЗадача 5");          // Задача 5
            Console.WriteLine("Напишите программу, проверяющую число на четность.");
            Console.WriteLine("Введите целое число: ");
            int val = Convert.ToInt32(Console.ReadLine());

            if (val % 2 == 0)
                Console.WriteLine("Вы ввели четное число");
            else
                Console.WriteLine("Вы ввели не четное число");
            Console.WriteLine("Для продолжения нажмите Enter...");
            Console.ReadKey();
            

            
            Console.WriteLine("\n\tЗадача 6");          // Задача 6
            Console.WriteLine("Единицы длины пронумерованы следующим образом:");
            Console.WriteLine("1 — дециметр\n2 — километр\n3 — метр\n4 — миллиметр\n5 — сантиметр");
            Console.WriteLine("Дан номер единицы длины (целое число в диапазоне 1–5)\nи длина отрезка в этих единицах (вещественное число).");
            Console.WriteLine("Найти длину отрезка в метрах.");
            Console.WriteLine("\nВведите номер единицы длины (1-5): ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите длину отрезка в этих единицах: ");
            double lenght = Convert.ToDouble(Console.ReadLine());

            switch (number)
            {
                case 1:
                    Console.WriteLine( lenght + " дециметр(ов) = " +  (lenght / 10) + " метров");      
                    break;
                case 2:
                    Console.WriteLine( lenght + " километр(ов) = " + (lenght * 1000) + " метров");    
                    break;
                case 3:
                    Console.WriteLine( lenght + " метр(ов) = " + lenght + " метров");
                    break;
                case 4:
                    Console.WriteLine( lenght + "  миллиметр(ов) = " +  (lenght / 1000) + " метров");    
                    break;
                case 5:
                    Console.WriteLine( lenght + " сантиматр(ов) = " +  (lenght / 100) + " метров");
                    break;

            }
            Console.WriteLine("Для перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            

            
            Console.WriteLine("\n\t Задача 7");          // Задача 7
            Console.WriteLine("Робот может перемещаться в четырех направлениях: ");
            Console.WriteLine("«С» — север\n«Ю» — юг\n«З» — запад\n«В» — восток");
            Console.WriteLine("и принимать три цифровые команды: ");
            Console.WriteLine(" 0 — продолжать движение\n 1 — поворот налево\n–1 — поворот направо.");
            Console.WriteLine("Дан символ D — исходное направление робота\nи целое число N — посланная ему команда.");
            Console.WriteLine("Вывести направление робота после выполнения полученной команды.");
            Console.WriteLine("\nВведите начальное направление робота (русские символы: С, Ю, З, В): ");
            char D = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Пошлите команду роботу 0, 1, -1: ");
            int N = Convert.ToInt32(Console.ReadLine());

            switch (D)
            {

                case 'С':
                    switch (N)
                    {
                        case 0:
                            D = 'С';
                            break;
                        case 1:
                            D = 'З';
                            break;
                        case -1:
                            D = 'В';
                            break;
                    }
                    break;
                case 'Ю':
                    switch (N)
                    {
                        case 0:
                            D = 'Ю';
                            break;
                        case 1:
                            D = 'В';
                            break;
                        case -1:
                            D = 'З';
                            break;
                    }
                    break;
                case 'З':
                    switch (N)
                    {
                        case 0:
                            D = 'З';
                            break;
                        case 1:
                            D = 'Ю';
                            break;
                        case -1:
                            D = 'С';
                            break;
                    }
                    break;
                case 'В':
                    switch (N)
                    {
                        case 0:
                            D = 'В';
                            break;
                        case 1:
                            D = 'С';
                            break;
                        case -1:
                            D = 'Ю';
                            break;
                    }
                    break;
            }
            Console.WriteLine("Робот движется на: {0}", D);
            Console.WriteLine("Для перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            

            
            Console.WriteLine("\n\tЗадача 8 (Без формулировки)");           // Задача 8
            Console.WriteLine("Введите возраст (целое число от 20 до 69): ");
            int age = Convert.ToInt32(Console.ReadLine());
            int calc = age / 10;
            int calc2 = age % 10;
            string firstage = "";
            string secondage = "";

            switch (calc)
            {
                case 2:
                    firstage = "Двадцать";
                    break;
                case 3:
                    firstage = "Тридцать";
                    break;
                case 4:
                    firstage = "Сорок";
                    break;
                case 5:
                    firstage = "Пятьдесят";
                    break;
                case 6:
                    firstage = "Шестьдесят";
                    break;

            }
            switch (calc2)
            {
                case 0:
                    secondage = "лет";
                    break;
                case 1:
                    secondage = "один год";
                    break;
                case 2:
                    secondage = "два года";
                    break;
                case 3:
                    secondage = "три года";
                    break;
                case 4:
                    secondage = "четыре года";
                    break;
                case 5:
                    secondage = "пять лет";
                    break;
                case 6:
                    secondage = "шесть лет";
                    break;
                case 7:
                    secondage = "семь лет";
                    break;
                case 8:
                    secondage = "восемь лет";
                    break;
                case 9:
                    secondage = "девять лет";
                    break;
            }
            Console.WriteLine(firstage + " " + secondage);
            Console.WriteLine("Для перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            

            Console.WriteLine("\n\tЗадача 9\n Камень - Ножницы - Бумага");          // Задача 9
            Console.WriteLine("Данны три метода:\nК - Камень\nН - Ножницы\nБ - Бумага");
            Console.WriteLine("Для начала игры выберете любой из методов (русские символы: К, Н, Б) :");
            char choice = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Выберете еще один вариант: ");
            char choice2 = Convert.ToChar(Console.ReadLine());
            string answer = "";
            switch (choice)
            {
                case 'К':
                    switch (choice2)
                    {
                        case 'К':
                            answer = "Ничья";
                            break;
                        case 'Н':
                            answer = "Камень";
                            break;
                        case 'Б':
                            answer = "Бумага";
                            break;
                    }
                    break;
                case 'Н':
                    switch (choice2)
                    {
                        case 'К':
                            answer = "Камень";
                            break;
                        case 'Н':
                            answer = "Ничья";
                            break;
                        case 'Б':
                            answer = "Ножницы";
                            break;
                    }
                    break;
                case 'Б':
                    switch (choice2)
                    {
                        case 'К':
                            answer = "Бумага";
                            break;
                        case 'Н':
                            answer = "Ножницы";
                            break;
                        case 'Б':
                            answer = "Ничья";
                            break;
                    }
                    break;

            }
            Console.WriteLine("Результат: " + answer);
            Console.WriteLine("Для завершения работы программы нажмите любую клавишу...");
            Console.ReadKey();

            Console.WriteLine("\n\tЗадача 9 Альтернативное решение (через if else-if)");            // Задача9 Альтернативное решение (if else-if)
            Console.WriteLine("1 - Камень\n2 - Ножницы\n3 - Бумага");
            Console.WriteLine("First Choice: ");
            int var = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Second Choice: ");
            int var2 = Convert.ToInt32(Console.ReadLine());

            if (var == var2)
                Console.WriteLine("Ничья");
            else if (var == 1 & var2 == 2)
                Console.WriteLine("Победил Камень");
            else if (var == 1 & var2 == 3)
                Console.WriteLine("Победила Бумага");
            else if (var == 2 & var2 == 1)
                Console.WriteLine("Победил Камень");
            else if (var == 2 & var2 == 3)
                Console.WriteLine("Победили Ножницы");
            else if (var == 3 & var2 == 1)
                Console.WriteLine("Победил Камень");
            else if (var == 3 & var2 == 2)
                Console.WriteLine("Победили Ножницы");

            Console.ReadKey();


        }
    }
}
