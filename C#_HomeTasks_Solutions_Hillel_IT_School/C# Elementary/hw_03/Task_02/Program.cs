using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Класс Абонент: 
 *  Идентификационный номер, 
 *  Фамилия, 
 *  Имя, 
 *  Отчество, 
 *  Адрес, 
 *  Номер кредитной карточки, 
 *  Дебет, 
 *  Кредит,
 *  Время междугородных
 *  и городских переговоров;
 * Конструктор;
 * Методы: 
 *  установка значений атрибутов,
 *  получение значений атрибутов,
 *  вывод информации.
 * Создать массив объектов данного класса.
 * Вывести сведения относительно абонентов, у которых время городских переговоров превышает заданное. 
 * Сведения относительно абонентов, которые пользовались междугородной связью.
 * Список абонентов в алфавитном порядке.
 */
namespace Task_02
{
    class Subscriber
    {
        private long idNumber = 0;                  // Идентификационный номер
        private string surName = string.Empty;      // Фамилия
        private string firstName = string.Empty;
        private string secondName = string.Empty;
        private string subAddress = string.Empty;
        private long cardNumber = 0;
        private double subDebet = 0;
        private double subCredit = 0;
        private int intercityCall = 0;              // Время междугородных 
        private int cityCall = 0;                   // и городских переговоров (в секундах)

        public long IdNumber { get => idNumber; set => idNumber = value; }
        public string SurName { get => surName; set => surName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string SecondName { get => secondName; set => secondName = value; }
        public string SubAddress { get => subAddress; set => subAddress = value; }
        public long CardNumber { get => cardNumber; set => cardNumber = value; }
        public double SubDebet { get => subDebet; set => subDebet = value; }
        public double SubCredit { get => subCredit; set => subCredit = value; }
        public int IntercityCall { get => intercityCall; set => intercityCall = value; }
        public int CityCall { get => cityCall; set => cityCall = value; }

        public Subscriber(long idNumber, string surName, string firstName, string secondName, string subAddress, long cardNumber, double subDebet, double subCredit, int intercityCall, int cityCall)
        {
            this.idNumber = idNumber;
            this.surName = surName;
            this.firstName = firstName;
            this.secondName = secondName;
            this.subAddress = subAddress;
            this.cardNumber = cardNumber;
            this.subDebet = subDebet;
            this.subCredit = subCredit;
            this.intercityCall = intercityCall;
            this.cityCall = cityCall;
        }

        public void SetSubscriberData()         // Метод: установка значений атрибутов 
        {
            int numChoice = 0;

            Console.WriteLine("Какое значение хотите изменить? ");
            Console.WriteLine(" idNumber \t(1)\n surName \t(2)\n firstName \t(3)\n secondName \t(4)\n subAddress \t(5)" +
                        "\n cardNumber \t(6)\n subDebet \t(7)\n subCredit \t(8)\n intercityCall \t(9)\n cityCall \t(0)");

            Console.Write("Нажмите соответсвующую клавишу: ");
            numChoice = int.Parse(Console.ReadLine());

            do
            {                                       // =================================================================================================
                if (numChoice == 1)                 // ========== ДЛЯ ДЕМОНСТРАЦИИ РАБОТЫ МЕТОДА ОСУЩЕСТВЛЕННО ИЗМЕНЕНИЕ ТОЛЬКО ДВУХ ЗНАЧЕНИЙ ==========  
                {
                    Console.Write("\nВведите значение idNumber: ");         // Идентификационный номер
                    IdNumber = long.Parse(Console.ReadLine());
                    IdNumber = idNumber;                        
                }

                else if (numChoice == 2)
                {
                    Console.Write("\nВведите значение surName: ");          // Фамилия абонента
                    SurName = Console.ReadLine();
                    SurName = surName;
                }

                Console.WriteLine("Хотите изменить другое значение? Enter / Escape ");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.Write("\nВыберете другую операцию: ");
                numChoice = int.Parse(Console.ReadLine());

            } while (idNumber != -100);
        }
    }

    class Subscribers
    {
        List<Subscriber> subscribers;
        List<Subscriber> temporary;

        public Subscribers()
        {
            subscribers = new List<Subscriber>();
            temporary = new List<Subscriber>();
        }

        public void InputUserData(Subscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void Show(Subscriber subscriber)         
        {
            Console.WriteLine($"{subscriber.IdNumber}/ {subscriber.SurName}/ {subscriber.FirstName}/ {subscriber.SecondName}/ {subscriber.SubAddress}/ {subscriber.CardNumber}/ {subscriber.SubDebet}/ {subscriber.SubCredit}/ {subscriber.IntercityCall}/ {subscriber.CityCall}");
        }

        public void Print()         // Вывод всех существующих абонентов без сортировки
        {
            foreach (var subscriber in subscribers)
            {
                Show(subscriber);
            }
        }

        public void Print(bool isSorted)        // Вывод в алфавитном порядке абонентов (по фамилии)
        {
            if (isSorted)
            {
                temporary = subscribers.OrderBy(x => x.SurName).ToList();
            }

            foreach (var subscriber in temporary)
            {
                Show(subscriber);
            }
        }

        public void Print(int requsetCityCall)      // Вывод абонентов время городских переговоров которых превышает заданное
        {
            foreach (var subscriber in subscribers)
            {
                if (requsetCityCall <= subscriber.CityCall)
                {
                    Show(subscriber);
                }
            }
        }

        public void PrintInterCityCall()        // Вывод абонентов пользовавшихся междугородними звонками
        {
            foreach (var subscriber in subscribers)
            {
                if (subscriber.IntercityCall > 0)
                {
                    Show(subscriber);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Subscribers subscribers = new Subscribers();

            Subscriber subscriber1 = new Subscriber(1, "Жуков", "Дмитрий", "Юрьевич", "Ул.Косиора", 380995488392, 0, 3500.0, 472, 817);
            Subscriber subscriber2 = new Subscriber(2, "Иванов", "Иван", "Иванович", "Ул.Иванова", 380995488391, 0, 7000.0, 311, 547);
            Subscriber subscriber3 = new Subscriber(3, "Михайлов", "Михаил", "Михайлович", "Ул.Михалыча", 380995488390, 30.5, 1100.0, 0, 991);

            subscriber1.SetSubscriberData();

            subscribers.InputUserData(subscriber1);
            subscribers.InputUserData(subscriber2);
            subscribers.InputUserData(subscriber3);

            Console.Clear();
            Console.WriteLine("Список существующих абонентов");
            subscribers.Print();
            Console.WriteLine(new string('=', 80));

            Console.WriteLine("Сортировка по имени абонента (в алфавитном порядке)");
            subscribers.Print(isSorted: true);
            Console.WriteLine(new string('=', 80));

            Console.WriteLine("Вывод абонентов время городских переговоров которых превышает заданное");
            subscribers.Print(900);
            Console.WriteLine(new string('=', 80));

            Console.WriteLine("Вывод абонентов пользовавшихся междугородними звонками");
            subscribers.PrintInterCityCall();

            Console.ReadKey();
        }
    }
}
