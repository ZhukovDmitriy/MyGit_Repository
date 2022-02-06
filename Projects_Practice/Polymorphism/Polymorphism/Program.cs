using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism
{
    public class Base
    {
        public virtual void Who()
        {
            Console.WriteLine("Метод Who() в класса Base");
        }
    }

    public class Derived1 : Base
    {
        public override void Who()
        {
            Console.WriteLine("Метод Who() в классе Derived1");
        }
    }

    public class Derived2 : Base
    {
        public override void Who()
        {
            Console.WriteLine("Метод Who() в классе Derived2");
        }
    }

    public class Vehicle
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int EnginePower { get; set; }
        public double UnloadedMass { get; set; }
        public double Price { get; set; }

        public Vehicle(int id, string brand, string model, int enginePower, double unloadedMass, double price)
        {
            ID = id;
            Brand = brand;
            Model = model;
            EnginePower = enginePower;
            UnloadedMass = unloadedMass;
            Price = price;
        }

        public virtual double LoadedSpecificPower()
        {
            return 0;
        }
    }

    public class Bus : Vehicle
    {
        public int PassengerCapacity { get; set; }

        public Bus(int passengerCapacity, int id, string brand, string model, int enginePower, double unloadedMass, double price)
            : base(id, brand, model, enginePower, unloadedMass, price)
        {
            PassengerCapacity = passengerCapacity;
        }

        public override double LoadedSpecificPower()
        {
            double averagePassengerWeight = 70;
            double loadedMass = PassengerCapacity * averagePassengerWeight + UnloadedMass;

            return loadedMass / EnginePower;
        }
    }

    public class Truck : Vehicle
    {
        public double CarryingCapacity { get; set; }

        public Truck(double carryingCapacity, int id, string brand, string model, int enginePower, double unloadedMass, double price)
            : base(id, brand, model, enginePower, unloadedMass, price)
        {
            CarryingCapacity = carryingCapacity;
        }

        public override double LoadedSpecificPower()
        {
            double loadedMass = UnloadedMass + CarryingCapacity;

            return loadedMass / EnginePower;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Вариант 1
            Base baseOb = new Base();

            Derived1 derivedOb1 = new Derived1();
            Derived2 derivedOb2 = new Derived2();

            baseOb.Who();

            baseOb = derivedOb1;
            baseOb.Who();

            baseOb = derivedOb2;
            baseOb.Who();

            Console.WriteLine();
            Console.WriteLine("Полиморфизм - это свойство одних и тех же объектов и методов примнимать разные формы");
            Console.WriteLine("Практическое применение полиморфизма:");

            // Вариант 2
            Vehicle[] vehicles = new Vehicle[4];

            vehicles[0] = new Bus(24, 1, "Volvo", "V24B", 180, 3600, 28500);
            vehicles[1] = new Bus(32, 2, "Volvo", "V32B", 240, 4100, 33800);
            vehicles[2] = new Truck(5000, 1, "MAN", "M5TT", 340, 4600, 27000);
            vehicles[3] = new Truck(7500, 2, "MAN", "M75TT", 380, 5200, 36500);

            foreach (var item in vehicles)
            {
                Console.WriteLine();
                Console.WriteLine("Транспортное средство: " + item.Brand + " " + item.Model);
                Console.WriteLine("Удельная мощность полностью снаряженного транспортного средства равна " + item.LoadedSpecificPower());
            }
        }
    }
}
