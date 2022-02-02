using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* Создать статический класс FindAndReplaceManager
 * с методом void FindNext(string str) для поиска по книге.
 * При вызове этого метода, производится последовательный поиск строки в книге.
 * (Книга любая, подгружаем с помощью Filestream)
 */
namespace Task_02
{
    static class FindAndReplaceManager
    {
        static public void FindNext(string str, string find)
        {
            FileStream fsm;
            string line;

            try
            {
                fsm = new FileStream(str, FileMode.Open, FileAccess.Read);  // открыть поток файлового ввода - вывода
            }

            catch (IOException exc)     // перехватить все исключения, связанные с вводом-выводом
            {
                Console.WriteLine(exc.Message);     // обработать ошибку
                return;
            }

            StreamReader stream = new StreamReader(fsm, Encoding.Default);  // заключить поток файлового ввода-вывода в оболочку класса StreamReader

            try
            {
                while ((line = stream.ReadLine().ToLower()) != null)    // считать строку в нижнем регистре
                {
                    if (line.Contains(find))    // возвращает true, если любой элемент входной последовательности соответствует указанному значению
                    {
                        Console.WriteLine("\nСтрока: {0}\nВстречается в тексте!", find);
                        break;
                    }

                    else
                    {
                        Console.WriteLine("\nСтрока: {0}\nНе найдена в тексте!", find);
                    }
                }
            }

            catch (IOException exc)     // перехватить любое другое исключение 
            {
                Console.WriteLine(exc.Message);     // обработать ошибку
            }

            finally
            {
                stream.Close();     // закрыть поток
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filePath;    // путь к файлу
            string findString;  // строка для поиска

            Console.Write("Введите путь к файлу, указав расширение файла\n: ");
            filePath = Console.ReadLine();

            Console.Write("\nВведите строку для поиска в данном файле\n: ");
            findString = Console.ReadLine().ToLower();  // возвращает копию строки в нижнем регистре

            FindAndReplaceManager.FindNext(filePath, findString);

            Console.ReadKey();
        }
    }
}
