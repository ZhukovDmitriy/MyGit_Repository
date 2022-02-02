using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "HW_06";
            
            // Задача 1 
            Console.WriteLine("\tЗадача 1");
            Console.WriteLine("Заполнить массив из 10 элементов случайными числами в интервале [-10..10]");

            Console.Write("\nВывод массива: ");

            int[] arr = new int[10];
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-10, 11);
                Console.Write(arr[i] + "  ");
            }

            Console.WriteLine("\nДля перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();

            // Задача 2
            Console.WriteLine("\n\tЗадача 2");
            Console.WriteLine("Дан двумерный массив.\nа) Вывести на экран элемент, расположенный в правом верхнем углу массива." +
                "\nб) Вывести на экран элемент, расположенный в левом нижнем углу массива.\n");

            int index1 = 5;                          // Количество строк массива
            int index2 = 10;                         // Длинна строки массива
            int[,] arr1 = new int[index1, index2];
            Random random1 = new Random();

            for (int i = 0; i < index1; i++)
            {
                for (int j = 0; j < index2; j++)
                {
                    arr1[i, j] = random1.Next(1, 11);
                    Console.Write(arr1[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nПравый верхний элемент массива: {0}", arr1[0, 9]);
            Console.WriteLine("\nЛевый нижний элемент массива: {0}", arr1[4, 0]);
            Console.WriteLine("\nДля перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();

            // Задача 3 
            Console.WriteLine("\n\tЗадача 3");
            Console.WriteLine("Составить программу:\nа) заменяющую значение любого элемента пятой строки двумерного массива\nчислом 1949;" +
                "\nб) заменяющую значение любого элемента двумерного массива числом a.\n");

            Console.WriteLine("Дан двумерный массив чисел от одного до пятидесяти: \n");

            int index3 = 5;
            int index4 = 10;
            int[,] arrNew = new int[index3, index4];
            int n = 1;

            for (int i = 0; i < index3; i++)
            {
                for (int j = 0; j < index4; j++)
                {
                    arrNew[i, j] = n++;
                    Console.Write(arrNew[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.Write("Введите номер элемента пятой строки который нужно заменить на число 1949: ");
            int changeNum = Convert.ToInt32(Console.ReadLine());
            arrNew[4, changeNum - 1] = 1949;

            Console.WriteLine();

            for (int i = 0; i < index3; i++)
            {
                for (int j = 0; j < index4; j++)
                {
                    Console.Write(arrNew[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Введите координаты элемента который хотите заменить.");
            Console.Write("\nНомер строки: ");
            int nX = Convert.ToInt32(Console.ReadLine());

            Console.Write("Номер элемента в этой строке: ");
            int nY = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nВведите значение для замены: ");
            int changeNum2 = Convert.ToInt32(Console.ReadLine());
            arrNew[nX - 1, nY - 1] = changeNum2;

            Console.WriteLine();

            for (int i = 0; i < index3; i++)
            {
                for (int j = 0; j < index4; j++)
                {
                    Console.Write(arrNew[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Для перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();

            // Задача 4 
            Console.WriteLine("\n\tЗадача 4");
            Console.WriteLine("Заполнить двумерный массив результатами таблицы умножения\n");

            int index5 = 9;
            int index6 = 9;
            int[,] arrTab = new int[index5, index6];
            int temp5 = 1;
            int temp6 = 1;

            for (int i = 0; i < index5; i++)
            {
                for (int j = 0; j < index6; j++)
                {
                    arrTab[i, j] = temp5 * temp6++;
                    Console.Write(arrTab[i, j] + "\t");
                }

                temp5++;
                temp6 = 1;
                Console.WriteLine();
            }

            Console.WriteLine("\nДля перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();

            // Задача 5
            Console.WriteLine("\n\tЗадача 5");
            Console.WriteLine("Дан двумерный массив. Вывести на экран:" +
                "\nа) все элементы третьей строки массива,\nначиная с последнего элемента этой строки;" +
                "\nб) все элементы k-го столбца массива,\nначиная с нижнего элемента этого столбца.\n");

            // int index3 = 5;                              //  !!! Для решения этой задачи используется двумерный массив из третьей задачи !!!
            // int index4 = 10;                             //                       !!! Заполненный числами 1 - 50. !!!
            // int[,] arrNew = new int[index3, index4];

            for (int i = 0; i < index3; i++)
            {
                for (int j = 0; j < index4; j++)
                {
                    Console.Write(arrNew[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nВывод элементов третьей строки массива в обратном порядке: ");
            Console.WriteLine();

            for (int j = index4 - 1; j >= 0; j--)
            {
                Console.Write(arrNew[2, j] + "\t");
            }

            Console.Write("\nВведите номер столбца массива: ");
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            for (int i = index3 - 1; i >= 0; i--)
            {
                Console.WriteLine(arrNew[i, k - 1]);
            }

            Console.WriteLine("\nДля перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            
            // Задача 6 // Задача 7 // Задача 8
            Console.WriteLine("\n\tЗадача 6 / Задача 7 / Задача 8");
            Console.WriteLine("Дан двумерный массив. Определить:\n" +
            "а) сумму всех элементов третьей строки массива;\nб) сумму всех элементов s-го столбца массива.\n" +
            "\nа) сумму всех элементов второго столбца массива;\nб) сумму всех элементов k-й строки массива.\n" +
            "\nа) сумму квадратов элементов второй строки массива;\nб) сумму квадратов элементов c-го столбца массива.\n");

            int index7 = 5;
            int index8 = 5;
            int[,] arrNew1 = new int[index7, index8];
            int n1 = 1;
            int sum = 0;            // сумму всех элементов третьей строки массива 
            int sum2 = 0;           // сумму всех элементов s-го столбца массива       
            int sum3 = 0;           // сумму всех элементов второго столбца массива
            int sum4 = 0;           // сумму всех элементов k-й строки массива
            double sum5 = 0;        // сумму квадратов элементов второй строки массива
            double sum6 = 0;        // сумму квадратов элементов c-го столбца массива

            for (int i = 0; i < index7; i++)                // Выводим двумерный массив заполнив его числами от 1-ого до 25-ти
            {
                for (int j = 0; j < index8; j++)
                {
                    arrNew1[i, j] = n1++;
                    Console.Write(arrNew1[i, j] + "\t");
                }

                Console.WriteLine("\n");
            }

            for (int j = 0; j < index8; j++)                // Расчет - суммы всех элементов третьей строки массива
            {
                sum = arrNew1[2, j] + sum;
            }

            Console.WriteLine("\nСумма всех элементов третьей строки массива: {0}", sum);

            Console.Write("\nВведите номер столбца массива: ");
            int s = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < index7; i++)                // Расчет - суммы всех элементов s-го столбца массива
            {
                sum2 = arrNew1[i, s - 1] + sum2;
            }

            Console.WriteLine("Сумма всех элементов {1}-го столбца массива: {0}", sum2, s);

            for (int i = 0; i < index7; i++)                // Расчет - суммы всех элементов второго столбца массива
            {
                sum3 = arrNew1[i, 1] + sum3;
            }

            Console.WriteLine("\nСумма всех элементов второго столбца массива: {0}", sum3);

            Console.Write("\nВведите номер строки массива: ");
            int k1 = Convert.ToInt32(Console.ReadLine());

            for (int j = 0; j < index8; j++)                // Расчет - суммы всех элементов k-й строки массива
            {
                sum4 = arrNew1[k1 - 1, j] + sum4;
            }

            Console.WriteLine("Cумма всех элементов {1}-й строки массива:{0}", sum4, k1);

            for (int j = 0; j < index8; j++)                // Расчет - суммы квадратов элементов второй строки массива
            {
                sum5 = Math.Pow(arrNew1[1, j], 2) + sum5;           // Аналог:  sum5 = arrNew1[1, j] * arrNew1[1, j] + sum5; 
            }

            Console.WriteLine("\nСумма квадратов элементов второй строки массива: {0}", sum5);

            Console.Write("\nВведите номер столбца: ");
            int c = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < index7; i++)                // Расчет - суммы квадратов элементов c-го столбца массива
            {
                sum6 = Math.Pow(arrNew1[i, c - 1], 2) + sum6;
            }

            Console.WriteLine("Сумма квадратов элементов {1}-го столбца массива: {0}", sum6, c);

            Console.WriteLine("Для перехода к следующей задаче нажмите Enter...");
            
            // Задача 9
            Console.WriteLine("\n\tЗадача 9");
            Console.WriteLine("Дан двумерный массив. Определить:" +
                "\nа) максимальный элемент массива;" +
                "\nб) минимальный элемент массива;" +
                "\nв) координаты минимального элемента массива." +
                "\nЕсли элементов с минимальным значением несколько," +
                "\nто должны быть найдены координаты самого нижнего и самого правого из них" +
                "\nг) координаты максимального элемента массива." +
                "\nЕсли элементов с максимальным значением несколько," +
                "\nто должны быть найдены координаты самого верхнего и самого левого из них.\n");

            int index9 = 5;
            int index10 = 5;
            int[,] arrLast = new int[index9, index10];
            Random randomLast = new Random();
            int aMax = arrLast[0, 0];

            for (int i = 0; i < index9; i++)
            {
                for (int j = 0; j < index10; j++)
                {
                    arrLast[i, j] = randomLast.Next(1, 11);
                    Console.Write(arrLast[i, j] + "\t");
                }

                Console.WriteLine("\n");
            }

            int aMin = arrLast[0, 0];                   // aMin нужно обьявлять после создания и заполнения массива !
            int iMin = 0, jMin = 0;                     // Координаты минимального элемента
            int iMax = 0, jMax = 0;                     // Координаты максимального элемента

            for (int i = 0; i < index9; i++)            // Поиск максимального и минимального элемента массива
            {
                for (int j = 0; j < index10; j++)
                {
                    if (arrLast[i, j] > aMax)           // arrLast[i, j] > aMax   примет и сохранит значения только самого первого максимального элемента 
                    {                                   // а значит - он же и будет самым верхним и левым элементом массива
                        aMax = arrLast[i, j];
                        iMax = i + 1;
                        jMax = j + 1;
                    }

                    if (arrLast[i, j] <= aMin)          // arrLast[i, j] <= aMin   прнимает и сохраняет каждое минимальное значения, вплоть до последнего  
                    {                                   // а значит - последнее сохраненное значение и будет самым нижним правым 
                        aMin = arrLast[i, j];
                        iMin = i + 1;
                        jMin = j + 1;
                    }

                }
            }

            Console.WriteLine("\nМаксимальный элемент массива: {0}", aMax);
            Console.WriteLine("\nМинимальный элемент массива: {0}", aMin);
            Console.WriteLine("\nКоординаты минимального элемента массива: строка {0}, cтолбец {1}", iMin, jMin);
            Console.WriteLine("\nКоординаты максимального элемента массива: строка {0}, cтолбец {1}", iMax, jMax);
            Console.WriteLine("Для завершение работы программы нажмите Enter...");
            Console.ReadKey();

        }
    }
}

