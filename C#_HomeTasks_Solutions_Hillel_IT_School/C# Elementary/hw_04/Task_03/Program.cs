using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Создать класс Vehicle.
 * В теле класса создайте поля:
 * координаты
 * и параметры средств передвижения
 * (цена, скорость, год выпуска).
 * Создайте 3 производных класса Plane, Саг и Ship.
 * Для класса Plane должна быть определена высота и количество пассажиров.
 * Для класса Ship — количество пассажиров и порт приписки.
 * Написать программу, которая выводит на экран 
 * информацию о каждом средстве передвижения.
 */
namespace Task_03
{
    class Vehicle
    {
        private double coordinatesX = 0;
        private double coordinatesY = 0;
        private double vehiclePrice = 0;
        private double vehicleSpeed = 0;
        private string vehicleCreateData = string.Empty;

        public double CoordinatesX { get => coordinatesX; set => coordinatesX = value; }
        public double CoordinatesY { get => coordinatesY; set => coordinatesY = value; }
        public double VehiclePrice { get => vehiclePrice; set => vehiclePrice = value; }
        public double VehicleSpeed { get => vehicleSpeed; set => vehicleSpeed = value; }
        public string VehicleCreateData { get => vehicleCreateData; set => vehicleCreateData = value; }

        public Vehicle(double coordX, double coordY, double price, double speed, string createData)
        {
            coordinatesX = coordX;
            coordinatesY = coordY;
            vehiclePrice = price;
            vehicleSpeed = speed;
            vehicleCreateData = createData;
        }

        public virtual void Show()
        {
            Console.WriteLine("Координаты транспортного средства:\nПо оси X:\t\t{0}\nПо оси Y:\t\t{1}\nЦена:\t\t\t{2}\nСкорость:\t\t{3}\nГод выпуска:\t\t{4}"
                , CoordinatesX, CoordinatesY, VehiclePrice, VehicleSpeed, VehicleCreateData);
        }
    }

    class Plane : Vehicle
    {
        private double planeHeight = 0;
        private int passengerNumber = 0;

        public double PlaneHeight { get => planeHeight; set => planeHeight = value; }
        public int PassengerNumber { get => passengerNumber; set => passengerNumber = value; }

        public Plane(double height, int planePassenger, double coordX, double coordY, double price, double speed, string createData)
            : base(coordX, coordY, price, speed, createData)
        {
            planeHeight = height;
            passengerNumber = planePassenger;
        }

        public override void Show()
        {
            Console.WriteLine("Самолет: ");
            base.Show();
            Console.WriteLine("Высота самолёта:\t{0}\nКоличество пассажиров:\t{1}", PlaneHeight, PassengerNumber);
        }
    }

    class Ship : Vehicle
    {
        private int passengerNumber = 0;
        private string registrationPort = string.Empty;

        public int PassengerNumber { get => passengerNumber; set => passengerNumber = value; }
        public string RegistrationPort { get => registrationPort; set => registrationPort = value; }

        public Ship(int shipPassanger, string registration, double coordX, double coordY, double price, double speed, string createData)
            : base(coordX, coordY, price, speed, createData)
        {
            passengerNumber = shipPassanger;
            registrationPort = registration;
        }

        public override void Show()
        {
            Console.WriteLine("Судно: ");
            base.Show();
            Console.WriteLine("Количество пассажиров:\t{0}\nПорт регистрации:\t{1}", PassengerNumber, RegistrationPort);
        }
    }

    class Car : Vehicle
    {
        public Car(double coordX, double coordY, double price, double speed, string createData)
            : base(coordX, coordY, price, speed, createData)
        {
        }

        public override void Show()
        {
            Console.WriteLine("Автомобиль: ");
            base.Show();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Plane plane = new Plane(11.5, 48, 0, 50, 78000.0, 550, "11.02.2012");
            Ship ship = new Ship(189, "Атлантида", 1505, 2355, 180800.0, 81.5, "02.15.2017");
            Car car = new Car(0, 0, 11500.0, 190, "10.10.2018");

            plane.Show();
            Console.WriteLine();
            ship.Show();
            Console.WriteLine();
            car.Show();

            Console.ReadKey();
        }
    }
}
