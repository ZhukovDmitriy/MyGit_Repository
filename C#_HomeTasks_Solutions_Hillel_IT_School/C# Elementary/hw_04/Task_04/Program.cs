using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Создайте класс DocumentWorker.
 * В теле класса создайте три метода OpenDocument(), EditDocument(), SaveDocument().
 * В тело каждого из методов добавьте вывод на экран соответствующих строк:
 * "Документ открыт",
 * "Редактирование документа доступно в версии Про",
 * "Сохранение документа доступно в версии Про".
 * Создайте производный класс ProDocumentWorker.
 * Переопределите соответствующие методы, при переопределении методов выводите следующие строки:
 * "Документ отредактирован",
 * "Документ сохранен в старом формате,
 * сохранение в остальных форматах доступно в версии Эксперт".
 * Создайте производный класс ExpertDocumentWorker от базового класса ProDocumentWorker.
 * Переопределите соответствующий метод.
 * При вызове данного метода необходимо выводить на экран "Документ сохранен в новом формате".
 * В теле метода Main() реализуйте возможность приема от пользователя номера ключа доступа pro и exp.
 * Если пользователь не вводит ключ, он может пользоваться только бесплатной версией (создается экземпляр базового класса),
 * если пользователь ввел номера ключа доступа pro и exp,
 * то должен создаться экземпляр соответствующей версии класса, приведенный к базовому - DocumentWorker.
 */
namespace Task_04
{
    class DocumentWorker
    {
        public virtual void OpenDocument()
        {
            Console.WriteLine("Документ открыт");
        }

        public virtual void EditDocument()
        {
            Console.WriteLine("Редактирование документа доступно в версии Про");
        }

        public virtual void SaveDocument()
        {
            Console.WriteLine("Сохранение документа доступно в версии Про");
        }
    }

    class ProDocumentWorker : DocumentWorker
    {
        public override void OpenDocument()
        {
            Console.WriteLine("Документ открыт");
        }

        public override void EditDocument()
        {
            Console.WriteLine("Документ отредактирован");
        }

        public override void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в старом формате,\nсохранение в остальных форматах доступно в версии Эксперт");
        }
    }

    class ExpertDocumentWorker : ProDocumentWorker
    {
        public override void OpenDocument()
        {
            Console.WriteLine("Документ открыт");
        }

        public override void EditDocument()
        {
            Console.WriteLine("Документ отредактирован");
        }

        public override void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в новом формате");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DocumentWorker document;

            Console.WriteLine("Вы пользуетесь бесплатной версией программы.\n");
            Console.WriteLine("Желаете активировать версии Pro или Expert ?\n");
            Console.WriteLine("Pro версия позволяет:\n - редактирование документа\n - сохранение в существующем формате");
            Console.WriteLine("Expert версия позволяет:\n - редактирование документа\n - сохранение в разных форматах");

            Console.WriteLine("\nПродолжить пользоваться бесплатной версией программы:\t[1]");
            Console.WriteLine("Активировать версию Pro:\t\t\t\t[2]");
            Console.WriteLine("Активировать верисю Exp:\t\t\t\t[3]");

            Console.Write("\nВыберите действие: ");
            int numChoice = int.Parse(Console.ReadLine());

            if (numChoice == 1)
            {
                document = new DocumentWorker();

                Console.WriteLine();
                document.OpenDocument();
                document.EditDocument();
                document.SaveDocument();
            }

            else if (numChoice == 2)
            {
                Console.WriteLine("\nАктивируйте Pro версию!");
                Console.Write("Введите ключ: ");
                string proKey = Console.ReadLine();

                if (proKey == "proKey")
                {
                    Console.WriteLine("\nPro версия программы успешно активирована!");

                    document = new ProDocumentWorker();

                    Console.WriteLine();
                    document.OpenDocument();
                    document.EditDocument();
                    document.SaveDocument();
                }

                else if (proKey != "proKey")
                {
                    Console.WriteLine("\nВы ввели не верный ключ!");
                }
            }

            else if (numChoice == 3)
            {
                Console.WriteLine("\nАктивируйте Expert версию!");
                Console.Write("Введите ключ: ");
                string expertKey = Console.ReadLine();

                if (expertKey == "expertKey")
                {
                    Console.WriteLine("\nExpert версия программы успешно активирована!");

                    document = new ExpertDocumentWorker();

                    Console.WriteLine();
                    document.OpenDocument();
                    document.EditDocument();
                    document.SaveDocument();
                }

                else if (expertKey != "expertKey")
                {
                    Console.WriteLine("\nВы ввели не верный ключ!");
                }
            }

            Console.ReadKey();
        }
    }
}
