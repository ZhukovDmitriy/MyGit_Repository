using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Составить описание класса для представления времени.
 * Предусмотреть возможности установки времени и изменения его отдельных полей (час, минута, секунда)
 * с проверкой допустимости вводимых значений.
 * В случае недопустимых значений полей выбрасываются исключения.
 * Создать методы изменения времени на заданное количество часов, минут и секунд.
 */
namespace Task_01
{
    class Time // Время
    {
        private int hour = 0;                   // Часы
        private int minute = 0;                 // Минуты
        private int second = 0;                 // Секунды

        public int Hour { get => hour; set => hour = value; }
        public int Minute { get => minute; set => minute = value; }
        public int Second { get => second; set => second = value; }

        public void TimeNow()                   // Метод вывода текущего времени
        {
            Console.Write("Текущее время: {0}:{1}:{2}", Hour, Minute, Second);
        }

        public void NewTime()                   // Метод ввода нового времени
        {
            Console.Write("\nВведите новое время разделяя ввод нажатием клавиши Enter: ");
            Console.Write("\nЧасове поле: ");
            Hour = int.Parse(Console.ReadLine());

            Console.Write("Минутное поле: ");
            Minute = int.Parse(Console.ReadLine());

            Console.Write("Секундное поле: ");
            Second = int.Parse(Console.ReadLine());

            Console.Write("Новое время: {0}:{1}:{2}", Hour, Minute, Second);
        }

        public void SetHour()                  // Метод изменяющий поле Часы
        {
            Console.Write("\nВведите новое значение часового поля: ");
            Hour = int.Parse(Console.ReadLine());

            Hour = Hour;

            Console.Write("Новое время: {0}:{1}:{2}", Hour, Minute, Second);
        }

        public void SetMinute()                // Метод изменяющий поле Минуты
        {
            Console.Write("\nВведите новое значение минутного поля: ");
            Minute = int.Parse(Console.ReadLine());

            Minute = Minute;

            Console.Write("Новое время: {0}:{1}:{2}", Hour, Minute, Second);
        }

        public void SetSecond()                // Метод изменяющий поле Секунды
        {
            Console.Write("\nВведите новое значение секундного поля: ");
            Second = int.Parse(Console.ReadLine());

            Second = Second;

            Console.Write("Новое время: {0}:{1}:{2}", Hour, Minute, Second);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numChoice = 0;

            Time time = new Time();
            time.Hour = 19;
            time.Minute = 15;
            time.Second = 00;

            Console.WriteLine("Выберите необходимое действие: ");
            Console.WriteLine(" - Вывод текущего времени \t(1)\n - Ввод нового времени \t\t(2)\n" +
                " - Изменить часовое поле \t(3)\n - Изменить минутное поле \t(4)\n - Изменить секундное поле \t(5)");

            Console.Write("\nНажмите соответсвующую цифру: ");
            numChoice = Convert.ToInt32(Console.ReadLine());


            do
            {
                if (numChoice == 1)
                {
                    time.TimeNow();                     // Вывод текущего времени
                }

                else if (numChoice == 2)
                {
                    time.NewTime();                     // Ввод нового времени 
                }

                else if (numChoice == 3)
                {
                    time.SetHour();                     // Задать часовое поле
                }

                else if (numChoice == 4)
                {
                    time.SetMinute();                   // Задать минутное поле
                }

                else if (numChoice == 5)
                {
                    time.SetSecond();                   // Задать секундное поле
                }

                Console.WriteLine("\n\nПродолжить или завершить работу с программой? Enter / Escape ");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.Write("\n\nВыберите другую оперцию: ");
                numChoice = Convert.ToInt32(Console.ReadLine());

            } while (numChoice != 100);
        }
    }
}