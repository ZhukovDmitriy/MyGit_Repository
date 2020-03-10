using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Разработать систему «Автобаза».
 * Диспетчер распределяет заявки на Рейсы между Водителями и назначает для этого Автомобиль.
 * Водитель может сделать заявку на ремонт.
 * Диспетчер может отстранить Водителя от работы.
 * Водитель делает отметку о выполнении Рейса и состоянии Автомобиля.
 */
namespace Task_03
{
    class Waypoint      // Маршрут 
    {
        private string way = string.Empty;      // Маршрут
        private bool wayStatus = false;         // Состояние рейса (выполнен / не выполнен)

        public string Way { get => way; set => way = value; }
        public bool WayStatus { get => wayStatus; set => wayStatus = value; }

        public Waypoint(string way, bool wayStatus)
        {
            this.way = way;
            this.wayStatus = wayStatus;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Маршрут:\t\t{0}", Way);
            Console.WriteLine("Состояние маршрута:\t{0}", WayStatus);
        }
    }

    class Driver        // Водитель
    {
        private string driverFio = string.Empty;        // Фамилия инициалы водителя

        public string DriverFio { get => driverFio; set => driverFio = value; }

        public Driver(string driverFio)
        {
            this.driverFio = driverFio;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Водитель:\t\t{0}", DriverFio);
        }

        public void SetWayStatus(Dispatcher voyage, bool wayStatus, bool autoStatus) // Метод: отчет водителя о выполнении рейса и состоянии автомобиля
        {                                                  // принимает конкретный рейс voyage1 и значения полей обьектов этого рейса waypoint1 и auto1  
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tУ вас новое сообщение!");
            Console.WriteLine("Отчет водителя о выполнении рейса: \n");

            voyage.Waypoint.WayStatus = wayStatus;      // voyage1 -> waypoint1 -> WayStatus
            voyage.Auto.AutoStatus = autoStatus;        // voyage1 -> auto1 -> AutoStatus
            voyage.Show();
        }

        public void RepeierAuto(Dispatcher voyage, bool ifNeed)         // Метод: заявка водителя на ремонт
        {
            if (ifNeed)                                                 // Если автомобиль требует ремонт - выводим сообщение                                                          
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nТребуется ремонт автомобиля: ");
                voyage.Auto.Show();
            }
        }
    }

    class Auto      // Автомобиль
    {
        private string autoID = string.Empty;       // Номер автомобиля
        private string autoModel = string.Empty;    // Марка автомобиля
        private bool autoStatus = true;             // Состояние автомобиля

        public string AutoID { get => autoID; set => autoID = value; }
        public string AutoModel { get => autoModel; set => autoModel = value; }
        public bool AutoStatus { get => autoStatus; set => autoStatus = value; }

        public Auto(string autoID, string autoModel, bool autoStatus)
        {
            this.autoID = autoID;
            this.autoModel = autoModel;
            this.autoStatus = autoStatus;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Номер автомобиля:\t{0}", AutoID);
            Console.WriteLine("Марка автомобиля:\t{0}", AutoModel);
            Console.WriteLine("Состояние автомобиля:\t{0}", AutoStatus);
        }
    }

    class Dispatcher        // Диспетчер - создает рейсы (voyage) из обьектов других классов
    {
        private Waypoint waypoint = null;
        private Driver driver = null;
        private Auto auto = null;

        internal Waypoint Waypoint { get => waypoint; set => waypoint = value; }
        internal Driver Driver { get => driver; set => driver = value; }
        internal Auto Auto { get => auto; set => auto = value; }

        public Dispatcher(Waypoint waypoint, Driver driver, Auto auto)
        {
            this.waypoint = waypoint;
            this.driver = driver;
            this.auto = auto;
        }

        public void Show()
        {
            Waypoint.Show();
            Driver.Show();
            Auto.Show();
        }

        public void SetDriver(Dispatcher voyage, Driver driver) // Метод замены водителя - принимает конкретный рейс и водителя для замены в этом рейсе
        {
            voyage.Driver = driver;
            voyage.Show();              // Выводим на экран информацию о рейсе где был заменен водитель  

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nДать разрешение на отправку маршрута?\nНажмите Enter...\n");
            Console.ReadKey();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Waypoint waypoint1 = new Waypoint("Новый_Центр - Новомосковск", false);
            Waypoint waypoint2 = new Waypoint("Новый_Центр - Павлограл", false);
            Waypoint waypoint3 = new Waypoint("Новый_Центр - Запорожье", false);

            Driver driver1 = new Driver("Иванов И.И.");
            Driver driver2 = new Driver("Смирнов С.С.");
            Driver driver3 = new Driver("Попов П.П.");

            Auto auto1 = new Auto("АЕ 355643 НЕ", "Богдан", true);
            Auto auto2 = new Auto("АЕ 547713 НЕ", "Спринтер", true);
            Auto auto3 = new Auto("АЕ 447341 НЕ", "Лоцман", true);

            Console.WriteLine("Рейс сформирован:\n");
            Dispatcher voyage1 = new Dispatcher(waypoint1, driver1, auto1);         // Создаем конкретный рейс  
            voyage1.Show();                                                         // Выводим информацию о рейсе на экран

            Console.ForegroundColor = ConsoleColor.Red;         // Имитация события 
            Console.WriteLine("\n\tУ вас новое сообщение:\nВодитель пришёл на работу в нетрезвом состоянии!\nНеобходимо его заменить!");
            Console.WriteLine("Нажмите Enter...\n");
            Console.ReadKey();

            voyage1.SetDriver(voyage1, driver2);        // Передаем в метод два аргумента: рейс (voyage1) и водителя для замены (driver2)

            driver1.SetWayStatus(voyage1, true, false); // Водитель делает отметку о выполнении рейса (аргументы - рейс, выполнение рейса, состояние авто.)
            driver1.RepeierAuto(voyage1, true);         // Заявка на ремонт  (аргументы - рейс, необходим ремонт?) 

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nНажмите Enter для звершение работы...");
            Console.ReadKey();
        }
    }
}