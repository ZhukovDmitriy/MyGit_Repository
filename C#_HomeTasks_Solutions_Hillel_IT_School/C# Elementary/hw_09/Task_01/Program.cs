using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* Создайте на диске 100 директорий с именами от Folder_0 до Folder_99,
 * затем удалите их.
 */
namespace Task_01
{
    class WorkWithDirectory
    {
        private string dirPath = string.Empty;

        public string DirPath { get => dirPath; set => dirPath = value; }

        public static void CreateDirectory(string path)     // Метод - создание папок в указанной директории
        {
            Directory.CreateDirectory(path);
        }

        public static void DeleteDirectory(string path)     // Метод - удаление всех папок из директории
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            foreach (DirectoryInfo directory in dirInfo.GetDirectories())
            {
                directory.Delete(true);
            }
        }
    }
   
    class Program
    {
        static void Main(string[] args)
        {
            WorkWithDirectory dirWork = new WorkWithDirectory();
                        
            dirWork.DirPath = @"E:\testFolder\Folder";

            int folderQuant = 0;    // количество директорий для создания 
            string modDirPath = dirWork.DirPath;    // создаем новую строку для хранения измененного пути 

            Console.Write("Какое количество папок вы хотите создать в директории\n{0} ?\n: ", dirWork.DirPath);
            folderQuant = int.Parse(Console.ReadLine());

            Console.WriteLine();

            for (int i = 0; i < folderQuant; i++)
            {
                modDirPath += "_";  // добавить символ "_" к строке содержащей путь: Folder_
                modDirPath += i;    // добавить номер папки к строке содержащей путь: Folder_0
                Console.WriteLine(modDirPath);

                WorkWithDirectory.CreateDirectory(modDirPath);
                modDirPath = dirWork.DirPath;   // вернуть указанный путь к первоначальному состоянию: Folder
            }

            Console.WriteLine("\nПапки успешно созданны!");

            char numChoice;

            modDirPath = modDirPath.Substring(0, modDirPath.LastIndexOf('\\') + 1);  // обрезать строку до последнего вхождения слеша: E:\testFolder\

            Console.Write("\nЖелаете удалить все папки из директории\n{0} ?\nвыберите y / n: ", modDirPath);
            numChoice = char.Parse(Console.ReadLine());

            if (numChoice == 'y')
            {
                WorkWithDirectory.DeleteDirectory(modDirPath);

                Console.WriteLine("\nВсе папки успешно удалены!\nнажмите Enter для завершения программы...");
                Console.ReadKey();
            }

            else if (numChoice == 'n')
            {
                Console.WriteLine("\nнажмите Enter для завершения программы...");
                Console.ReadKey();
            }            
        }
    }
}