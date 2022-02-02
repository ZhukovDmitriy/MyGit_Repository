using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;    // содержит классы, предоставляющие основные службы сжатия и распаковки для потоков.

/* Напишите приложение для поиска заданного файла на диске.
 * Добавьте код, использующий класс FileStream
 * и позволяющий просматривать файл в текстовом окне.
 * В заключение добавьте возможность сжатия найденного файла.
 */
namespace Task_03
{
    class FileSearch
    {
        public void Scan(DirectoryInfo seacrhDriver, string searchFile)     // Метод - поиск файла в указанной директории
        {
            FileInfo[] fileInfo;

            try                                             // try {} catch {return;} необходимы чтобы игнорировать ошибку:  
            {                                               // "Отказано в доступе"  System Volume Information - скрытая системная папка,
                fileInfo = seacrhDriver.GetFiles();         // которая используется программой восстановления системы 
            }                                               // для хранения своих данных и точек восстановления.
                                                            // Такая папка создается в каждом разделе жесткого диска компьютера.
            catch { return; }

            foreach (var file in fileInfo)
            {
                //Console.WriteLine(file);

                if (file.Name == searchFile)
                {
                    Console.WriteLine("\nФайл: {0} найден!\nДиректория: {1}", file.Name, file.DirectoryName);
                }
            }

            DirectoryInfo[] dirInfo = seacrhDriver.GetDirectories();

            foreach (var dir in dirInfo)
            {
                //Console.WriteLine(dir);
            }

            for (int i = 0; i < dirInfo.Length; i++)
            {
                //Console.WriteLine(dirInfo);

                Scan(dirInfo[i], searchFile);   // рекурсивный подход
            }
        }
    }

    class WorkWithFile
    {
        public void Open(string path)  // Метод - откытие файла
        {
            Console.WriteLine("\nДокумент открыт: {0}", path);

            FileStream fsm;
            string str;

            try
            {
                fsm = new FileStream(path, FileMode.Open);
            }

            catch (IOException exc)     // перехватить все исключения, связанные с вводом-выводом
            {
                Console.WriteLine(exc.Message);     // обработать ошибку
                return;
            }
            // Encoding.Default - позволяет распознавать русский текст
            StreamReader stream = new StreamReader(fsm, Encoding.Default);    // заключить поток файлового ввода-вывода в оболочку класса StreamReader

            try
            {
                while ((str = stream.ReadLine()) != null)   // считать всю строку до конца
                {                   
                    Console.WriteLine(str);
                }
            }

            catch (IOException exc)     // перехватить любое другое исключение    
            {
                Console.WriteLine(exc.Message);     // обработать ошибку
            }

            finally     // блок finally закрывает файл независимо от исключений
            {
                stream.Close();
            }
        }
    }

    class FileCompression
    {
        public void Compress(string sourceFile, string compressedFile)  // Метод - сжатие файла
        {
            // поток для чтения исходного файла
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                // поток для записи сжатого файла
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    // поток архивации
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream); // копируем байты из одного потока в другой

                        Console.WriteLine("\nСжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",

                            sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\tВнимание!\n\tПрограмма является учебной и не обработана до конца" +
                "\n\tУбедитесь в существовании файла который необходимо найти\n\tПравильно вводите имя файла и следуйте инструкции программы");

            Console.WriteLine(new string('=', 75));

            Console.WriteLine("Список локальных дисков вашего компьютера:");

            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo driver in allDrives)
            {
                Console.WriteLine(driver);
            }

            string searchDriver;    // имя диска для поиска 
            string searchFile;      // имя файла который необходимо найти

            Console.Write("\nВведите имя диска на котором будет осуществлен поиск: ");
            searchDriver = Console.ReadLine();

            DirectoryInfo dirInfo = new DirectoryInfo(searchDriver);

            Console.Write("\nВведите имя файла для поиска указав расширение файла: ");
            searchFile = Console.ReadLine();

            FileSearch fileSearch = new FileSearch();
            fileSearch.Scan(dirInfo, searchFile);   // вызов метода поиска

            string filePath;

            Console.Write("\nДля открытия файла:");
            Console.Write("\nукажите полный путь к файлу включая имя и расширение файла:\nДиректория: ");
            filePath = Console.ReadLine();

            WorkWithFile fileWork = new WorkWithFile();
            fileWork.Open(filePath);    // вызов метода - открытие файла

            Console.WriteLine("\nДля сжатия (архивации файла):");
            Console.Write("введите полный путь к файлу указав расширение файла" +
                "\n(используйте клавиши вверх вниз для повторения ранее введеных команд)" +
                "\nДиректория: ");

            string sourceFile = Console.ReadLine();     // директория исходного файла

            Console.WriteLine("\nСжатый файл будет сохранен в текущей директории.");
            Console.WriteLine("Нажмите Enter для продолжения...");
            Console.ReadKey();

            string compressedFile = sourceFile;

            compressedFile = compressedFile.Substring(0, compressedFile.LastIndexOf('.') + 1);
            compressedFile += "gz";     // директория сохранения сжатого файла

            FileCompression fileCompress = new FileCompression();

            fileCompress.Compress(sourceFile, compressedFile);  // вызов метода - создание сжатого файла

            Console.ReadKey();
        }
    }
}