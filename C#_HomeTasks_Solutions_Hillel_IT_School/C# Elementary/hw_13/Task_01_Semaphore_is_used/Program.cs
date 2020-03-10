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
namespace Task_01_Semaphore_is_used
{
    class SharedRes
    {
        private static string[] links;                          // Массив Url адресов
        public static string[] fileNames;                       // Массив содежащий именна файлов
        public static string fileExtension = @".jpg";           // Расширение файлов
        public static string folderPath = @"E:\DownloadTest\";  // Директория загрузки файлов

        public static string[] Links { get => links; set => links = value; }

        public void GetFileNames()  // Метод возвращающий именна скачеваемых файлов
        {
            Array.Copy(Links, fileNames = new string[Links.Length], Links.Length);          // Копируем все данные из массива links в массив fileNames

            for (int i = 0; i < fileNames.Length; i++)
            {
                fileNames[i] = fileNames[i].Substring(fileNames[i].LastIndexOf('/') + 1);   // Обрезаем строки Url адресов в массиве fileNames 
                fileNames[i] = fileNames[i].Substring(0, fileNames[i].LastIndexOf('.'));    // для получения имён файлов 
            }

            Console.WriteLine("Спиcок Url адресов:\n");

            foreach (var item in Links)
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
    }

    class MyThread
    {
        public Thread Thrd;

        // Создаем семафор, дающий только два разрешения из двух первоначально имеющихся
        static Semaphore sem = new Semaphore(2, 2);

        // Диапазон скачиваемых файлов
        public int begin;   // Стартовая позиция   
        public int end;     // Конечная позиция

        public MyThread(string name, int begin, int end)
        {
            Thrd = new Thread(this.DownloadFiles);
            Thrd.Name = name;
            this.begin = begin;
            this.end = end;
            object args = new object[2] { begin, end };     // Массив параметров передаваемых в метод DownloadFiles() при запуске потока
            Thrd.Start(args);
        }

        // Точка входа в поток
        public void DownloadFiles(object args)  // Метод производящий загрузку файлов 
        {                                       // Принимает несколько параметров от потоков
            Array argsArray = new object[2];
            argsArray = (Array)args;

            // Получаем параметры из массива:  
            int begin = (int)argsArray.GetValue(0);     // Стартовая позиция для начала скачивания
            int end = (int)argsArray.GetValue(1);       // Конечная позиция скачивания

            Console.WriteLine(Thrd.Name + ": ожидает разрешения");

            sem.WaitOne();

            Console.WriteLine(Thrd.Name + ": получает разрешение");

            WebClient client = new WebClient();         // Класс для загрузки файлов с опрделенных URI ресурсов

            for (int i = begin; i <= end; i++)
            {
                Thread.Sleep(250);

                client.DownloadFile(new Uri(SharedRes.Links[i]), SharedRes.folderPath + SharedRes.fileNames[i] + SharedRes.fileExtension);

                Console.WriteLine("Метод использует: " + Thrd.Name + " Файл загружен: " + SharedRes.folderPath + SharedRes.fileNames[i]);
            }

            Console.WriteLine(Thrd.Name + ": высвобождает разрешение");

            // Освободить семафор
            sem.Release();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SharedRes res = new SharedRes();

            SharedRes.Links = new string[]{
                "https://ja-rastu.ru/uploads/posts/2013-01/thumbs/1358787810_a.jpg",
                "https://ja-rastu.ru/uploads/posts/2013-01/thumbs/1358787831_b.jpg",
                "https://ja-rastu.ru/uploads/posts/2013-01/1358787871_c.jpg",
                "https://ja-rastu.ru/uploads/posts/2013-01/1358787790_d.jpg",
                "https://ja-rastu.ru/uploads/posts/2013-01/thumbs/1358788085_e.jpg",
                "https://ja-rastu.ru/uploads/posts/2013-01/thumbs/1358788126_f.jpg",
                "https://ja-rastu.ru/uploads/posts/2013-01/thumbs/1358788101_g.jpg",
                "https://ja-rastu.ru/uploads/posts/2013-01/thumbs/1358788173_i.jpg",
                "https://ja-rastu.ru/uploads/posts/2013-01/thumbs/1358788168_j.jpg",
                "https://ja-rastu.ru/uploads/posts/2013-01/thumbs/1358788169_k.jpg",
                "https://ja-rastu.ru/uploads/posts/2013-01/thumbs/1358788133_l.jpg",
            };

            res.GetFileNames();     // Получаем именна скачиваемых файлов 

            // Для демонстрации работы класса Semaphore
            // Инициализируем обьекты задавая диапазоны скачивания для каждого потока
            MyThread mt1 = new MyThread("Поток #1", 0, 1);  // Поток mt1 скачивает файлы 1 - 2    
            MyThread mt2 = new MyThread("Поток #2", 2, 5);  // Поток mt2 скачивает файлы 3 - 6 
            MyThread mt3 = new MyThread("Поток #3", 6, 9);  // Поток mt3 скачивает файлы 7 - 9

            // Ожидаем завершение потоков
            mt1.Thrd.Join();
            mt2.Thrd.Join();
            mt3.Thrd.Join();

            Console.ReadKey();
        }
    }
}
