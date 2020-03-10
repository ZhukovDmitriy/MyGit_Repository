using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Определить класс с именем Worker, содержащую следующие поля:
фамилия и инициалы работника;
название занимаемой должности;
год поступления на работу.
   Методы:
ввод данных в массив из n элементов в типа Worker;
упорядочить по алфавиту фамилии работников;
вывод работников, чей стаж работы в фирме превышает значение, введенное пользователем.
*/
namespace Task_02
{
    class Worker // Работник
    {
        private string surName = string.Empty;          // Фамилия и инициалы работника
        private string postName = string.Empty;         // Название занимаеиой должности
        private double arrivalYear;                     // Год поступления на работу

        public string SurName { get => surName; }
        public string PostName { get => postName; }
        public double ArrivalYear { get => arrivalYear; }

        public Worker(string Name, string Post, double Year)
        {
            surName = Name;
            postName = Post;
            arrivalYear = Year;
        }
    }

    class Workers // Работники
    {
        List<Worker> workers;
        List<Worker> temporary;

        public Workers()
        {
            workers = new List<Worker>();
            temporary = new List<Worker>();
        }

        public void InputUserData(Worker worker)
        {
            workers.Add(worker);
        }

        public void Show(Worker worker)
        {
            Console.WriteLine($"{worker.SurName} => {worker.PostName} => {worker.ArrivalYear}");
        }

        public void Print()
        {
            foreach (var worker in workers)
            {
                Show(worker);
            }
        }

        public void Print(bool isSorted)                        // Сортируем по фамилии работников (по алфавиту)
        {
            if (isSorted)
            {
                temporary = workers.OrderBy(x => x.SurName).ToList();           
            }

            foreach (var worker in temporary)
            {
                Show(worker);
            }
        }

        public void Print(double requestExperience)             // Вывод работников, чей стаж работы в фирме превышает значение, введенное пользователем
        {
            foreach (var worker in workers)
            {
                if (requestExperience <= worker.ArrivalYear)
                {
                    Show(worker);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Workers workers = new Workers();

            Worker worker1 = new Worker("Иванов И.И.", ".Net Devoloper", 1.5);
            Worker worker2 = new Worker("Смирнов С.С.", "Back End", 2.0);
            Worker worker3 = new Worker("Николаенко Н.Н.", "Architector", 3.5);

            workers.InputUserData(worker1);
            workers.InputUserData(worker2);
            workers.InputUserData(worker3);

            workers.Print();
            Console.WriteLine(new string('=', 40));

            workers.Print(isSorted: true);
            Console.WriteLine(new string('=', 40));

            workers.Print(2.0);

            Console.ReadKey();
        }
    }
}
