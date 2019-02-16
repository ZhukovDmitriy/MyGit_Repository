using System;
using System.IO;    // пространство имен содержащее основные классы потоков 
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Создайте класс AbstractHandler.
 * В теле класса создать методы void Open(), void Create(), void Change(), void Save().
 * Создать производные классы XMLHandler, TXTHandler, DOCHandler от базового класса AbstractHandler.
 * Написать программу, которая будет выполнять определение документа
 * и для каждого формата должны быть методы
 * открытия,
 * создания,
 * редактирования,
 * сохранения определенного формата документа.
 */
namespace Task_01
{
    abstract class AbstractHandler  // ========== Базовый абстрактный класс ==========
    {
        public abstract void Open(string path);     // Абстрактные методы: Открытия(), Создания(), Редактирования файлов().
        public abstract void Create(string path);
        public abstract void Change(string path);
        // public abstract void Save();             // Не реализован за ненадобностью 

        class XMLHandler : AbstractHandler                      // ========== Производный класс наследуемый от базового ==========
        {
            public override void Open(string path)  // ===== переопределенный Метод откытия файла .xml =====
            {
                Console.WriteLine("Документ открыт: {0}\n", path);

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

                StreamReader stream = new StreamReader(fsm);    // заключить поток файлового ввода-вывода в оболочку класса StreamReader

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

            public override void Create(string path)    // ===== переопределенный Метод создания файла .xml =====
            {
                Console.WriteLine("Документ создан: {0}", path);

                FileStream fsm;

                try
                {
                    fsm = new FileStream(path, FileMode.Create);
                }

                catch (IOException exc)
                {
                    Console.WriteLine(exc.Message);
                    return;
                }

                fsm.Close();
            }

            public override void Change(string path)    // ===== переопределенный Метод редактирования файла .xml =====
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
                        sw.Write(" " + str);
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            //public override void Save()
            //{
            //}
        }

        class TXTHandler : AbstractHandler                   // ========== Производный класс наследуемый от базового ==========
        {
            public override void Open(string path)  // ===== переопределенный Метод откытия файла .txt =====
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

                StreamReader stream = new StreamReader(fsm);

                try
                {
                    while ((str = stream.ReadLine()) != null)
                    {
                        Console.WriteLine(str); 
                    }
                }

                catch (IOException exc)
                {
                    Console.WriteLine(exc.Message);
                }

                finally
                {
                    stream.Close();
                }
            }

            public override void Create(string path)    // ===== переопределенный Метод создания файла .txt =====
            {
                Console.WriteLine("Документ создан: {0}", path);

                FileStream fsm;

                try
                {
                    fsm = new FileStream(path, FileMode.Create);
                }

                catch (IOException exc)
                {
                    Console.WriteLine(exc.Message);
                    return;
                }

                fsm.Close();
            }

            public override void Change(string path)    // ===== переопределенный Метод редактирования файла .txt =====
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

                    using (StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8))
                    {
                        sw.Write(" " + str);
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            //public override void Save()
            //{
            //}
        }

        class DOCHandler : AbstractHandler                   // ========== Производный класс наследуемый от базового ==========
        {
            public override void Open(string path)  // ===== переопределенный Метод откытия файла .doc =====
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

                StreamReader stream = new StreamReader(fsm);

                try
                {
                    while ((str = stream.ReadLine()) != null)
                    {
                        Console.WriteLine(str); 
                    }
                }

                catch (IOException exc)
                {
                    Console.WriteLine(exc.Message);
                }

                finally
                {
                    stream.Close();
                }
            }

            public override void Create(string path)    // ===== переопределенный Метод создания файла .doc =====
            {
                Console.WriteLine("Документ создан: {0}", path);

                FileStream fsm;

                try
                {
                    fsm = new FileStream(path, FileMode.Create);
                }

                catch (IOException exc)
                {
                    Console.WriteLine(exc.Message);
                    return;
                }

                fsm.Close();
            }

            public override void Change(string path)    // ===== переопределенный Метод редактирования файла .doc =====
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

                    using (StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8))
                    {
                        sw.WriteLine(" " + str);
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            //public override void Save()
            //{
            //}
        }

        class Assistant     // Вспомогательный класс
        {
            public string FileExtension(string path)    // Метод получения формата файла
            {
                return path.Substring(path.LastIndexOf(".") + 1);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("\t\tИспользуйте клавиши вверх / вниз\n\t\tчтобы дублировать ранее набранные команды!");
                Console.WriteLine(new string('=', 80));

                Assistant assistant = new Assistant();

                int numChoice;
                string filePath;    // полный путь к файлу
                string fileFormat;  // расширение файла - содержит все символы после точки

                Console.WriteLine("Выберите действие.\n");
                Console.WriteLine("Создать файл:\t\t[1]\nОткрыть файл:\t\t[2]\nРедактировать файл:\t[3]\n");
                Console.Write("Нажмите соответствующую клавишу: ");
                numChoice = int.Parse(Console.ReadLine());

                do
                {
                    if (numChoice == 1)
                    {
                        Console.Write("\nУкажите полный путь, имя и расширение создаваемого файла .txt .doc .xml\n: ");
                        filePath = Console.ReadLine();
                        fileFormat = assistant.FileExtension(filePath);

                        if (fileFormat == "txt")
                        {
                            TXTHandler txt = new TXTHandler();
                            txt.Create(filePath);
                        }
                        else if (fileFormat == "doc")
                        {
                            DOCHandler doc = new DOCHandler();
                            doc.Create(filePath);
                        }
                        else if (fileFormat == "xml")
                        {
                            XMLHandler xml = new XMLHandler();
                            xml.Create(filePath);
                        }
                    }

                    else if (numChoice == 2)
                    {
                        Console.Write("\nУкажите полный путь, имя и расширение открываемого файла .txt .doc .xml\n: ");
                        filePath = Console.ReadLine();
                        fileFormat = assistant.FileExtension(filePath);

                        if (fileFormat == "txt")
                        {
                            TXTHandler txt = new TXTHandler();
                            txt.Open(filePath);
                        }
                        else if (fileFormat == "doc")
                        {
                            DOCHandler doc = new DOCHandler();
                            doc.Open(filePath);
                        }
                        else if (fileFormat == "xml")
                        {
                            XMLHandler xml = new XMLHandler();
                            xml.Open(filePath);
                        }
                    }

                    else if (numChoice == 3)
                    {
                        Console.Write("\nУкажите полный путь, имя и расширение редактируемого файла .txt .doc .xml\n: ");
                        filePath = Console.ReadLine();
                        fileFormat = assistant.FileExtension(filePath);

                        if (fileFormat == "txt")
                        {
                            TXTHandler txt = new TXTHandler();
                            txt.Change(filePath);
                        }
                        else if (fileFormat == "doc")
                        {
                            DOCHandler doc = new DOCHandler();
                            doc.Change(filePath);
                        }
                        else if (fileFormat == "xml")
                        {
                            XMLHandler xml = new XMLHandler();
                            xml.Change(filePath);
                        }
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
}
