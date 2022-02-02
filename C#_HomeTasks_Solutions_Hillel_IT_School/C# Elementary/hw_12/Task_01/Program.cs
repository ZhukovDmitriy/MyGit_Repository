using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;     // Пространство имен содержит в себе классы поддерживающие многопоточное программирование

/* Напишите программу, в которой метод будет вызываться рекурсивно.
 * Каждый новый вызов метода выполняется в отдельном потоке.
 */
namespace Task_01
{
    class MyThread
    {
        public void Run(object num)     // класс object, неявно считается базовым классом для всех остальных классов и типов,
        {                               // включая и типы значений. Может ссылаться на объект любого другого типа
            int n = (int)num;

            if (n <= 0)
            {
                return;
            }

            Thread newThread = new Thread(Run);

            Thread.Sleep(250);

            newThread.Name = "Поток № " + n;
            newThread.Start(n - 1);

            Console.WriteLine(newThread.Name + "\tHashCode: " + Thread.CurrentThread.GetHashCode());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyThread myThread = new MyThread();

            myThread.Run(10);

            Console.ReadKey();
        }
    }
}
