using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Определить класс с именем Prise содержащую следующие поля:
название товара;
название магазина, в котором продается товар;
стоимость товара в грн.
   Методы:
ввод данных в массив из n элементов в типа Prise;
упорядочить в алфавитном порядке по названиям товаров;
вывод информации о товаре, название которого ввел пользователь.
*/
namespace Task_03
{
    class Prise
    {
        private string productName = string.Empty;          // Название товара
        private string storeName = string.Empty;            // Название магазина
        private double productPrice;                        // Стоимость товара (в гривнах)

        public string ProductName { get => productName; }
        public string StoreName { get => storeName; }
        public double ProductPrice { get => productPrice; }

        public Prise(string product, string store, double price)
        {
            productName = product;
            storeName = store;
            productPrice = price;
        }
    }

    class Prises
    {
        List<Prise> prises;
        List<Prise> temporary;

        public Prises()
        {
            prises = new List<Prise>();
            temporary = new List<Prise>();
        }

        public void InputUserData(Prise prise)
        {
            prises.Add(prise);
        }

        public void Show(Prise prise)
        {
            Console.WriteLine($"{prise.ProductName} => {prise.StoreName} => {prise.ProductPrice}");
        }

        public void Print()
        {
            foreach (var prise in prises)
            {
                Show(prise);
            }
        }

        public void Print(bool isSorted)                                // Сортируем в алфавитном порядке по названиям товаров
        {
            if (isSorted)
            {
                temporary = prises.OrderBy(x => x.ProductName).ToList();
            }

            foreach (var prise in temporary)
            {
                Show(prise);
            }
        }

        public void Print(string requestProductName)                    // Вывод информации о товаре, название которого ввел пользователь
        {
            foreach (var prise in prises)
            {
                if (requestProductName == prise.ProductName)
                {
                    Show(prise);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Prises prises = new Prises();

            Prise prise1 = new Prise("C# 4.0", "BookLand.Dnepr", 849.0);
            Prise prise2 = new Prise("ASP.NET MVC 4", " BookLand.Kiev", 970.0);
            Prise prise3 = new Prise("Professional .NET Network", "BookLand.Dnepr", 530.5);

            prises.InputUserData(prise1);
            prises.InputUserData(prise2);
            prises.InputUserData(prise3);

            prises.Print();
            Console.WriteLine(new string('=', 60));

            prises.Print(isSorted: true);
            Console.WriteLine(new string('=', 60));

            prises.Print("C# 4.0");

            Console.ReadKey();
        }
    }
}
