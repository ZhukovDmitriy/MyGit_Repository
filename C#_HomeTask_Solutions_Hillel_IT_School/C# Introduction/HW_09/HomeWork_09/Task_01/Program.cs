using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{ /* 1.	Определить класс с именем Student, содержащую следующие поля: фамилия и инициалы; номер группы; успеваемость – массив из 10 элементов.
     методы:
     ввод данных в массив из n элементов в типа Student;
     упорядочить по возрастанию номера в группе;
     вывод студентов и номеров групп для студентов, если средний балл студента больше 67.
  */
    class Student
    {
        public string surName;
        public int groupNumber;
        public int[] rating = new int[3];
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество студентов: ");
            int studQuant = Convert.ToInt32(Console.ReadLine());

            Student[] GetStud = new Student[studQuant];
            StudentCreate(GetStud);
            Sort(GetStud);

            Console.ReadKey();

            void StudentCreate(Student[] Students)                  // Метод  - создание студентов
            {
                for (int i = 0; i < studQuant; i++)
                {
                    Student student = new Student();
                    Students[i] = student;

                    Console.Write("Введите фамилию и инициалы {0}-ого студента: ", i + 1);
                    student.surName = Console.ReadLine();

                    Console.Write("Введите номер группы студента: ");
                    student.groupNumber = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Введите {0} оценок студента: ", student.rating.Length);
                    for (int j = 0; j < student.rating.Length; j++)
                    {
                        Console.Write("{0}) ", j + 1);
                        student.rating[j] = Convert.ToInt32(Console.ReadLine());
                    }
                }

            }

            void Sort(Student[] Students)                           // Метод - сортировка по номеру группы
            {
                Student[] studBuff = new Student[1];

                for (int i = 0; i < Students.Length - 1; i++)
                {
                    for (int j = i + 1; j < Students.Length; j++)
                    {
                        if (Students[i].groupNumber > Students[j].groupNumber)
                        {
                            studBuff[0] = Students[i];
                            Students[i] = Students[j];
                            Students[j] = studBuff[0];
                        }
                    }
                }

                for (int i = 0; i < studQuant; i++)               // Вывод студентов
                {
                    Console.WriteLine("{0} {1}", Students[i].surName, Students[i].groupNumber);
                }
            }
        }
    }
}