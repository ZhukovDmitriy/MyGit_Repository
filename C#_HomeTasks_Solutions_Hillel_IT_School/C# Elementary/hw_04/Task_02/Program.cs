using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Создать класс, представляющий учебный класс ClassRoom.
 * Создайте класс ученик Pupil.
 * В теле класса создайте методы
 * void Study(),
 * void Read(),
 * void Write(),
 * void Relax().
 * Создайте 3 производных класса
 * ExcelentPupil,
 * GoodPupil, 
 * BadPupil
 * от класса базового класса Pupil
 * и переопределите каждый из методов, 
 * в зависимости от успеваемости ученика.
 * Конструктор класса ClassRoom принимает аргументы типа Pupil,
 * класс должен состоять из 4 учеников. 
 * Предусмотрите возможность того, 
 * что пользователь может передать 2 или 3 аргумента. 
 * Выведите информацию о том,
 * как все ученики экземпляра класса ClassRoom умеют учиться, читать, писать, отдыхать.
 */
namespace Task_02
{
    class ClassRoom
    {
        List<Pupil> pupils;

        public ClassRoom(Pupil pupil1)
        {
            pupils = new List<Pupil>() { pupil1 };
        }

        public ClassRoom(Pupil pupil1, Pupil pupil2)
        {
            pupils = new List<Pupil>() { pupil1, pupil2 };
        }

        public ClassRoom(Pupil pupil1, Pupil pupil2, Pupil pupil3)
        {
            pupils = new List<Pupil>() { pupil1, pupil2, pupil3 };
        }

        public ClassRoom(Pupil pupil1, Pupil pupil2, Pupil pupil3, Pupil pupil4)
        {
            pupils = new List<Pupil>() { pupil1, pupil2, pupil3, pupil4 };
        }

        public void PrintStudy()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Вызов метода Study() в Производных классах : ");
            Console.ResetColor();

            foreach (var item in pupils)
            {
                item.Study();
            }
        }

        public void PrintRead()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Вызов метода Read() в Производных классах : ");
            Console.ResetColor();

            foreach (var item in pupils)
            {
                item.Read();
            }
        }

        public void PrintWrite()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Вызов метода Write() в Производных классах : ");
            Console.ResetColor();

            foreach (var item in pupils)
            {
                item.Write();
            }
        }

        public void PrintRelax()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Вызов метода Relax() в Производных классах : ");
            Console.ResetColor();

            foreach (var item in pupils)
            {
                item.Relax();
            }
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nВывод для каждого аргумента: ");
            Console.ResetColor();

            foreach (var item in pupils)
            {                       
                Console.WriteLine(new string('=', 35));
                item.Study();
                item.Read();
                item.Write();
                item.Relax();                
            }
        }
    }

    class Pupil  // Базовый класс 
    {
        public virtual void Study()
        {
        }

        public virtual void Read()
        {
        }

        public virtual void Write()
        {
        }

        public virtual void Relax()
        {
        }
    }

    class ExcelentPupil : Pupil     // Производный класс (ExcelentPupil) от Базового класса (Pupil) 
    {
        public override void Study()
        {
            Console.WriteLine("Ученик отличник: Учится на отлично.");
        }

        public override void Read()
        {
            Console.WriteLine("Ученик отличник: Читает отлично.");
        }

        public override void Write()
        {
            Console.WriteLine("Ученик отличник: Пишет отлично.");
        }

        public override void Relax()
        {
            Console.WriteLine("Ученик отличник: Отдыхает отлично.");
        }
    }

    class GoodPupil : Pupil     // Производный класс (GoodPupil) от Базового класса (Pupil) 
    {
        public override void Study()
        {
            Console.WriteLine("Хороший ученик: Учится хорошо.");
        }

        public override void Read()
        {
            Console.WriteLine("Хороший ученик: Читает хорошо.");
        }

        public override void Write()
        {
            Console.WriteLine("Хороший ученик: Пишет хорошо.");
        }

        public override void Relax()
        {
            Console.WriteLine("Хороший ученик: Отдыхает хорошо.");
        }
    }

    class BadPupil : Pupil     // Производный класс (BadPupil) от Базового класса (Pupil)         
    {
        public override void Study()
        {
            Console.WriteLine("Плохой ученик: Учится плохо.");
        }

        public override void Read()
        {
            Console.WriteLine("Плохой ученик: Читет плохо.");
        }

        public override void Write()
        {
            Console.WriteLine("Плохой ученик: Пишет плохо.");
        }

        public override void Relax()
        {
            Console.WriteLine("Плохой ученик: Отдыхает плохо.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {               
            ClassRoom classRoom = new ClassRoom(new ExcelentPupil(), new GoodPupil(), new BadPupil(), new GoodPupil());
                                   
            classRoom.PrintStudy();
            classRoom.PrintRead();
            classRoom.PrintWrite();
            classRoom.PrintRelax();

            Console.WriteLine("\nНажмите Enter...");
            Console.ReadKey();
            classRoom.Show();

            // ========== Еще один способ организации программы ==========

            ExcelentPupil pupil1 = new ExcelentPupil();
            GoodPupil pupil2 = new GoodPupil();
            BadPupil pupil3 = new BadPupil();

            ClassRoom classRoom2 = new ClassRoom(pupil1, pupil2, pupil3);
            Console.WriteLine("\nНажмите Enter...");
            Console.ReadKey();

            Console.Clear();
            classRoom2.Show();

            Console.ReadKey();
        }
    }
}