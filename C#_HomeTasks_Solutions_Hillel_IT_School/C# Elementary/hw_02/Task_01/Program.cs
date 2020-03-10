using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Определить класс с именем Order содержащую следующие поля:
расчетный счет плательщика (формат уточнить в Интернете);
расчетный счет получателя;
перечисляемая сумма в грн.
   Методы:
ввод данных в массив из n элементов в типа Order;
упорядочить по убыванию перечисляемой суммы;
вывод информации о тех плательщиках, перечисляемая сумма которых не меньше суммы, введенной пользователем.
*/
namespace Task_01
{
    class Order // Заказ
    {
        private long payerAccount;          // Расчетный счет плательщика (20 цифр)
        private long recipientAccount;      // Расчетный счет получателя (20 цифр)
        private double transferAmount;      // Перечисляемая сумма (в гривнах)

        public long PayerAccount { get => payerAccount; }
        public long RecipientAccount { get => recipientAccount; }
        public double TransferAmount { get => transferAmount; }

        public Order(long payerAcc, long recipientAcc, double transferAm)
        {
            payerAccount = payerAcc;
            recipientAccount = recipientAcc;
            transferAmount = transferAm;
        }
    }

    class Orders // Заказы
    {
        List<Order> orders;                // Создаем список для обьектов Order, который будет содержать заказы 
        List<Order> temporary;             // Создаем пустой список (временный) в котором будем производить сортировку

        public Orders()                    // В конструкторе по умолчанию определяем новый экземпляр списка
        {
            orders = new List<Order>();
            temporary = new List<Order>();
        }

        public void InputUserData(Order order)        // Метод добавляния данных о заказе (параметр Order order) в список orders
        {
            orders.Add(order);                        // Добавляем новый элемент в список orders
        }

        public void Show(Order order)                 // Метод вывода информации о заказе
        {
            Console.WriteLine($"{order.PayerAccount} => {order.RecipientAccount} => {order.TransferAmount}");
        }

        public void Print()                           // Метод вывода информации о заказах без сортировки
        {
            foreach (var order in orders)
            {
                Show(order);
            }
        }

        public void Print(bool isSorted)              // (перегруженный) Метод сортировки по убыванию перечисляемой суммы 
        {                                             // в случае, если список необходимо сортировать
            if (isSorted)
            {
                temporary = orders.OrderByDescending(x => x.TransferAmount).ToList();     // Для сортировки используем язык LINQ. 
                                                                                          // Сортируем по убыванию заполненный список orders приравнивая его к временному списку
                foreach (var order in temporary)                                          // и преобразовываем к типу List    
                {
                    Show(order);
                }
            }
        }

        public void Print(double requestAmount)       // (перегруженный) Метод вывода информации о плательщиках, 
        {                                             // перечисляемая сумма которых не меньше суммы, введенной пользователем (параметр requestAmount)                              
            foreach (var order in orders)
            {
                if (requestAmount <= order.TransferAmount)
                {
                    Show(order);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Orders orders = new Orders();         // Создаем новый экземпляр списка в котором будут содержаться заказы order

            Order order1 = new Order(0677412682, 0995488392, 120.0);
            Order order2 = new Order(0951309104, 0995488392, 140.5);
            Order order3 = new Order(0636915099, 0995488392, 35.5);

            orders.InputUserData(order1);
            orders.InputUserData(order2);
            orders.InputUserData(order3);

            orders.Print();
            Console.WriteLine(new string('=', 40));

            orders.Print(isSorted: true);
            Console.WriteLine(new string('=', 40));

            orders.Print(90.0);

            Console.ReadKey();
        }
    }
}
