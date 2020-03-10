using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Построить три класса (базовый и 2 потомка),
 * описывающих некоторых работников с почасовой оплатой (один из потомков)
 * и фиксированной оплатой (второй потомок).
 * а) Описать в базовом классе абстрактный метод для расчета среднемесячной заработной платы.
 * Для «повременщиков» формула для расчета такова:
 * «среднемесячная заработная плата = 20.8 8 почасовую ставку»,
 * для работников с фиксированной оплатой «среднемесячная заработная плата = фиксированной месячной оплате».
 * б) Создать на базе абстрактного класса массив сотрудников и заполнить его.
 * в) Реализовать интерфейсы для возможности сортировки массива используя Array.Sort(). 
 * г) Реализовать возможность вывода данных с использованием foreach
 */
namespace Task_03
{
    abstract class Worker   // базовый абстрактный класс
    {
        private string workerFio = string.Empty;
        private double averagePayment = 0;  // среднемесячная ЗП

        public string WorkerFio { get => workerFio; set => workerFio = value; }
        public double AveragePayment { get => averagePayment; set => averagePayment = value; }

        public Worker(string workerFio)
        {
            this.workerFio = workerFio;
        }

        public abstract void AveragePaymentCalculation();   // абстрактный метод расчета среднемесячной зароботной платы
    }

    class HourlyPaymentWorker : Worker  // производный класс - работники с почасовой оплатой
    {
        private double hourlyPayment = 0;   // почасовая ставка

        public double HourlyPayment { get => hourlyPayment; set => hourlyPayment = value; }

        public HourlyPaymentWorker(string workerFio, double hourlyPayment) : base(workerFio)
        {
            this.hourlyPayment = hourlyPayment;
        }

        public override void AveragePaymentCalculation()    // переопределенный метод расчета ЗП для "повременщиков"
        {
            AveragePayment = 20.8 * 8 * HourlyPayment;
        }
    }

    class FixedPaymentWorker : Worker   // производный класс - работники с фиксированной оплатой
    {
        private double fixedPayment = 0;    // фиксированная ставка

        public double FixedPayment { get => fixedPayment; set => fixedPayment = value; }

        public FixedPaymentWorker(string workerFio, double fixedPayment) : base(workerFio)
        {
            this.fixedPayment = fixedPayment;
        }

        public override void AveragePaymentCalculation()    // переопределенный метод расчета ЗП для работников с фиксированной оплатой
        {
            AveragePayment = FixedPayment;
        }
    }

    public interface IWorkerSort    // интерфейс 
    {
        void WorkerFioSort();               // метод сортировки по фамилии
        void WorkerAveragePaymentSort();    // метод сортировки по среднемесячной ЗП 
    }

    class Workers : IWorkerSort
    {
        public List<Worker> workers;
        public List<Worker> temporary;

        public Workers()
        {
            workers = new List<Worker>();
            temporary = new List<Worker>();
        }

        public void InputWorker(Worker worker)
        {
            workers.Add(worker);
        }

        public void Show(Worker worker)
        {
            Console.WriteLine("Фамилия работника:\t{0}\nЗарплата за месяц:\t{1}", worker.WorkerFio, worker.AveragePayment);
            Console.WriteLine(new string('=', 40));
        }

        public void Print()     // г) реализовать возможность вывода данных с использованием foreach
        {
            foreach (var worker in workers)
            {
                Show(worker);
            }
        }

        void IWorkerSort.WorkerFioSort()    // явная реализация интерфейса IWorkerSort - сортировка LINQ по алфавиту 
        {
            temporary = workers.OrderBy(x => x.WorkerFio).ToList();

            foreach (var worker in temporary)
            {
                Show(worker);
            }
        }

        void IWorkerSort.WorkerAveragePaymentSort()     // явная реализация интерфейса IWorkerSort - сортировка LINQ по ЗП
        {
            temporary = workers.OrderByDescending(x => x.AveragePayment).ToList();

            foreach (var worker in temporary)
            {
                Show(worker);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Worker worker1 = new HourlyPaymentWorker("Иванов И.И.", 35);
            Worker worker2 = new HourlyPaymentWorker("Платонов П.П.", 40);
            Worker worker3 = new HourlyPaymentWorker("Соколова С.С.", 55);

            Worker worker4 = new FixedPaymentWorker("Филатов Ф.Ф.", 7500);
            Worker worker5 = new FixedPaymentWorker("Громов Г.Г.", 11400);
            Worker worker6 = new FixedPaymentWorker("Артёмова А.А.", 8300);

            Workers workers = new Workers();
            IWorkerSort iSort = workers;    // интерфейсная ссылка на обьект workers

            worker1.AveragePaymentCalculation();
            worker2.AveragePaymentCalculation();
            worker3.AveragePaymentCalculation();
            worker4.AveragePaymentCalculation();
            worker5.AveragePaymentCalculation();
            worker6.AveragePaymentCalculation();

            workers.InputWorker(worker1);
            workers.InputWorker(worker2);
            workers.InputWorker(worker3);
            workers.InputWorker(worker4);
            workers.InputWorker(worker5);
            workers.InputWorker(worker6);
                        
            workers.Print();    // вывод работников 

            Console.WriteLine("\nСортировать работников по фамилии, нажмите Enter...");
            Console.ReadKey();
            Console.Clear();
            iSort.WorkerFioSort();

            Console.WriteLine("\nСортировать работников по зароботной плате, нажмите Enter...");
            Console.ReadKey();
            Console.Clear();
            iSort.WorkerAveragePaymentSort();

            Console.WriteLine("\nЗавершить работу, нажмите Enter...");
            Console.ReadKey();
        }
    }
}
