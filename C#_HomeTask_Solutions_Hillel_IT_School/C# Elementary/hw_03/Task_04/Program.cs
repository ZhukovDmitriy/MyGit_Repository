using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Разработать систему «Интернет-магазин».  +
 * Товаровед добавляет информацию о Товаре. +
 * Клиент делает (заказ)                    +
 * и оплачивает Заказ на Товары.            +
 * Товаровед регистрирует Продажу           +
 * и может занести неплательщика в «черный список».  +
 */
namespace Task_04
{
    class Product   // Товар
    {
        private int productID = 0;                      // id товара
        private string productName = string.Empty;      // название товара
        private double productPrice = 0;                // стоимость товара

        public int ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public double ProductPrice { get => productPrice; set => productPrice = value; }

        public Product(int id, string name, double price)
        {
            productID = id;
            productName = name;
            productPrice = price;
        }
    }

    class Merchandise   // Товаровед
    {
        public Product Factory(int id, string name, double price)   // метод "фабрика класса" для построения обьектов другого класса
        {
            Product product = new Product(id, name, price);

            return product;
        }

        public void PaymentCheck(Order order, BlackList blackList)  // Метод проверки оплаты и добавления в "черный список"
        {
            if (order.PaymentStatus == false)
            {
                blackList.AddViolator(order.Client);  // добавляем  в список нарушителей клиента не оплатившего заказ 
                Console.WriteLine("Заказ не оплачен!");
            }
            else
            {
                Console.WriteLine("Заказ оплачен!");
            }
        }
    }

    class BlackList     // Черный список
    {
        private List<Client> violatorsClients;        // создаем список ("список нарушителей") для обьектов Client

        internal List<Client> ViolatorsClients { get => violatorsClients; set => violatorsClients = value; }

        public BlackList()
        {
            violatorsClients = new List<Client>();    // определяем новый экземпляр списка
        }

        public void AddViolator(Client client)        // метод добавляющий Клиентов (Client) в список нарушителей 
        {
            ViolatorsClients.Add(client);
        }
    }

    class Client    // Клиент
    {
        private string clientFio = string.Empty;            // фамилия инициалы клиента
        private int clientContact = 0;                      // контактный номер телефона клиента
        private string deliveryAddress = string.Empty;      // адрес доставки товара

        public string ClientFio { get => clientFio; set => clientFio = value; }
        public int ClientContact { get => clientContact; set => clientContact = value; }
        public string DeliveryAddress { get => deliveryAddress; set => deliveryAddress = value; }

        public Client(string fio, int contact, string address)
        {
            clientFio = fio;
            clientContact = contact;
            deliveryAddress = address;
        }

        public Order Factory(Product product, Client client, bool status)  // метод "фабрика класса" для построения обьектов другого класса 
        {
            Order order = new Order(product, client, status);

            return order;
        }
    }

    class Order     // Заказ
    {
        private Product product = null;         // обьект класса Товар
        private Client client = null;           // обьект класса Клиент
        private bool paymentStatus = false;     // статус оплаты заказа: оплачен / не оплачен 

        internal Product Product { get => product; set => product = value; }
        internal Client Client { get => client; set => client = value; }
        public bool PaymentStatus { get => paymentStatus; set => paymentStatus = value; }

        public Order(Product product, Client client, bool status)
        {
            Product = product;
            Client = client;
            paymentStatus = status;
        }

        public void ProductPayment(Order order, bool payment)       // метод оплаты заказа
        {
            order.PaymentStatus = payment;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Merchandise merchandise = new Merchandise();
            BlackList blackList = new BlackList();

            // Товаровед добовляет (создает) товар
            Product product1 = merchandise.Factory(1, "product1", 280);
            Product product2 = merchandise.Factory(2, "product2", 310);
            Product product3 = merchandise.Factory(3, "product3", 480);

            Client client1 = new Client("Жуков Д.Ю.", 0995488392, "Тверская 1а");

            // Клиент оформляет заказ на товар и может тут же его оплатить
            Order order1 = client1.Factory(product2, client1, false);      // заказ НЕ ОПЛАЧЕН

            order1.ProductPayment(order1, true);                           // вызов метода оплаты заказа

            // Товаровед регистрирует продажу (проверяет оплату)
            // в случае не оплаченного заказа: заносит клиента в "черный список" 
            merchandise.PaymentCheck(order1, blackList);

            Console.ReadKey();
        }
    }
}
