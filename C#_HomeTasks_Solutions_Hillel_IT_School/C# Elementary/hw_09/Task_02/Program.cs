using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* Создайте файл,
 * запишите в него произвольные данные и закройте файл.
 * Затем снова откройте этот файл, прочитайте из него данные
 * и выведете их на консоль.
 */
namespace Task_02
{
    class WorkWithFile
    {
        public void CreateFile(string path)     // Метод - создание файла
        {
            Console.WriteLine("Документ создан: {0}", path);

            FileStream fsm;

            try
            {
                fsm = new FileStream(path, FileMode.Create);
            }

            catch (IOException exc)     // перехватить все исключения, связанные с вводом-выводом
            {
                Console.WriteLine(exc.Message);      // обработать ошибку
                return;
            }

            fsm.Close();    // закрыть поток
        }

        public void EditFile(string path)   // Метод - редактирование файла
        {
            Console.WriteLine("Документ открыт для редактирования: {0}", path);

            string text;
            Console.Write("\nВведите текст: ");
            string str = Console.ReadLine();

            try
            {
                using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
                {
                    text = sr.ReadToEnd();
                }

                using (StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8))   // true - присоеденяет выводимые данные в конце существующего файла
                {                                                                       // false - перезаписывает содержимое файла
                    sw.Write(str);
                }
            }

            catch (Exception e)     
            {
                Console.WriteLine(e.Message);
            }
        }

        public void OpenFile(string path)   // Метод - открытие файла
        {
            Console.WriteLine("Документ открыт: {0}\n", path);

            FileStream fsm;
            string str;

            try
            {
                fsm = new FileStream(path, FileMode.Open);
            }

            catch (IOException exc)     
            {
                Console.WriteLine(exc.Message);    
                return;
            }

            StreamReader stream = new StreamReader(fsm);    // заключить поток файлового ввода-вывода в оболочку класса StreamReader

            try
            {
                while ((str = stream.ReadLine()) != null)   // считать всю строку до конца
                {
                    Console.WriteLine(str);     // вывести данные на консоль
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

    class Program
    {
        static void Main(string[] args)
        {          
            Console.WriteLine("\t\tИспользуйте клавиши вверх / вниз\n\t\tчтобы дублировать ранее набранные команды!");
            Console.WriteLine(new string('=', 80));           

            int numChoice;
            string filePath;    // полный путь к файлу            

            Console.WriteLine("Выберите действие.\n");
            Console.WriteLine("Создать файл:\t\t[1]\nРедактировать файл:\t[2]\nОткрыть файл:\t\t[3]\n");
            Console.Write("Нажмите соответствующую клавишу: ");
            numChoice = int.Parse(Console.ReadLine());

            do
            {
                WorkWithFile fileWork = new WorkWithFile();

                if (numChoice == 1)
                {
                    Console.Write("\nУкажите полный путь, имя и расширение создаваемого файла .txt .doc .xml\n: ");
                    filePath = Console.ReadLine();                    

                    fileWork.CreateFile(filePath);
                }

                else if (numChoice == 2)
                {
                    Console.Write("\nУкажите полный путь, имя и расширение открываемого файла .txt .doc .xml\n: ");
                    filePath = Console.ReadLine();                   

                    fileWork.EditFile(filePath);
                }

                else if (numChoice == 3)
                {
                    Console.Write("\nУкажите полный путь, имя и расширение редактируемого файла .txt .doc .xml\n: ");
                    filePath = Console.ReadLine();                   

                    fileWork.OpenFile(filePath);
                }

                Console.Write("\nВыбрать другое действие или завершить работу с программой? Enter / Escape");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.Write("\nВыберите другую оперцию: ");
                numChoice = int.Parse(Console.ReadLine());

            } while (numChoice != 100);

            Console.ReadKey();
        }                
    }
}
