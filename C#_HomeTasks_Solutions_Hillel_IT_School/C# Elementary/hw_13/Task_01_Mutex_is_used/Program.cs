using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

/* Напишите программу,
 * которая в несколько потоков скачивает файлы по заданному списку URL-адресов.
 * Используйте «традиционную» многопоточность с мьютексами, семафорами и пр.
 */
namespace Task_01_Mutex_is_used
{
    // Класс содержащий общий ресурс - Url адресса 
    // а также мьютекс (Mtx), управляющий доступом к ресурсу
    class SharedRes
    {
        public static Mutex Mtx = new Mutex();          // Взаимноисключающий синхронизирующий обьект.

        private static string[] links;                  // Массив Url адресов
        private static string[] fileNames;              // Массив содежащий именна файлов
        private static string fileExtension = @".png";  // Расширение файлов

        public string[] Links { get => links; set => links = value; }

        public void GetFileNames()          // Метод возвращающий именна скачеваемых файлов
        {
            Array.Copy(links, fileNames = new string[links.Length], links.Length);          // Копируем все данные из массива links в массив fileNames

            for (int i = 0; i < fileNames.Length; i++)
            {
                fileNames[i] = fileNames[i].Substring(fileNames[i].LastIndexOf('/') + 1);   // Обрезаем строки Url адресов в массиве fileNames 
                fileNames[i] = fileNames[i].Substring(0, fileNames[i].LastIndexOf('.'));    // для получения имён файлов 
            }

            Console.WriteLine("Спиcок Url адресов:\n");

            foreach (var item in links)
            {
                Console.WriteLine(item);    // Выводим на консоль полный список Url адресов
            }

            Console.WriteLine("\nПолучаем имена файлов:\n");

            foreach (var item in fileNames)
            {
                Console.WriteLine(item);    // Выводим на консоль список полученных имён файлов
            }

            Console.WriteLine();
        }

        public static void DownloadFiles(object args)   // Метод производящий загрузку файлов 
        {                                               // Принимает несколько параметров от потоков
            Array argsArray = new object[2];
            argsArray = (Array)args;

            // Получаем параметры из массива:  
            string threadName = (string)argsArray.GetValue(0);  // Имя потока использующий метод 
            string folderPath = (string)argsArray.GetValue(1);  // Директория для сохранения скачиваемых файлов

            WebClient client = new WebClient();         // Класс для загрузки файлов с опрделенных URI ресурсов

            Console.WriteLine(threadName + ": ожидает мьютекс");

            Mtx.WaitOne();  // Получить мьютекс

            Console.WriteLine(threadName + ": получает мьютекс");

            for (int i = 0; i != links.Length; i++)
            {
                Thread.Sleep(250);

                try
                {
                    client.DownloadFile(new Uri(links[i]), folderPath + fileNames[i] + fileExtension);

                    Console.WriteLine("Метод использует: " + threadName + " Файл загружен: " + folderPath + fileNames[i]);
                }

                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }

            Console.WriteLine(threadName + ": освобождает мьютекс");

            Mtx.ReleaseMutex();     // Освободить мьютекс
        }
    }

    class ThreadFirst   // Первый поток
    {
        public Thread Thrd;
        public static string threadName = "Поток #1";
        public static string folderPath;                            // Директория сохранения скачиваемых файлов
        object args = new object[2] { threadName, folderPath };     // Массив параметров передаваемых в метод DownloadFiles() при запуске потока

        public ThreadFirst()
        {
            Thrd = new Thread(SharedRes.DownloadFiles);
            Thrd.Start(args);
        }
    }

    class ThreadSecond  // Второй поток
    {
        public Thread Thrd;
        public static string threadName = "Поток #2";
        public static string folderPath;                            // Директория сохранения скачиваемых файлов
        object args = new object[2] { threadName, folderPath };     // Массив параметров передаваемых в метод DownloadFiles() при запуске потока

        public ThreadSecond()
        {
            Thrd = new Thread(SharedRes.DownloadFiles);
            Thrd.Start(args);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SharedRes res = new SharedRes();

            res.Links = new string[]{
                "http://www.diablo1.ru/images/diablo2/characters/amazon-small.png",
                "http://www.diablo1.ru/images/diablo2/characters/assassin-small.png",
                "http://www.diablo1.ru/images/diablo2/characters/barbarian-small.png",
                "http://www.diablo1.ru/images/diablo2/characters/druid-small.png",
                "http://www.diablo1.ru/images/diablo2/characters/necromancer-small.png",
                "http://www.diablo1.ru/images/diablo2/characters/paladin-small.png",
                "http://www.diablo1.ru/images/diablo2/characters/sorceress-small.png"
            };

            res.GetFileNames();     // Получаем именна скачиваемых файлов 

            ThreadFirst.folderPath = @"E:\DownloadTest\";
            ThreadSecond.folderPath = @"E:\DownloadTest2\";

            // Запускаем потоки
            ThreadFirst first = new ThreadFirst();
            ThreadSecond second = new ThreadSecond();

            // Ожидаем завершение потоков
            first.Thrd.Join();
            second.Thrd.Join();

            Console.ReadKey();
        }
    }
}