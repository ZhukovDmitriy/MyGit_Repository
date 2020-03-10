using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Разработать систему «Вступительные экзамены». 
 * Абитуриент регистрируется на Факультет,       
 * сдает Экзамены.
 * Преподаватель выставляет Оценку.
 * Система подсчитывает средний бал
 * и определяет Абитуриента,
 * зачисленного в учебное заведение.
 */
namespace Task_05
{
    class Faculty   // Факультет
    {
        private string facultyName = string.Empty;      // Название факультета 
        private List<Abiturient> abiturients;           // Список "абитуриентов" содержащий обьекты класса Абитуриент
        private List<Abiturient> students;              // Список "студентов" содержащий обьекты класса Абитуриент

        public string FacultyName { get => facultyName; set => facultyName = value; }
        internal List<Abiturient> Abiturients { get => abiturients; set => abiturients = value; }
        internal List<Abiturient> Students { get => students; set => students = value; }

        public Faculty(string name, List<Abiturient> abiturients, List<Abiturient> students)
        {
            facultyName = name;
            Abiturients = abiturients;
            Students = students;
        }

        // Метод добавляющий абитуриента в список на поступления выбранной кафедры
        public void AddAbiturient(Abiturient abiturient, List<Abiturient> Abiturients)
        {
            Abiturients.Add(abiturient);
            Console.WriteLine("\nСтудент добавлен в список на поступление!");

            foreach (var item in Abiturients)
            {
                abiturient.Show(abiturient);
            }
        }

        // Метод перемещающий абитуриента из списка абитуриентов в список студентов при условии успешно сданного вступительного экзамена
        public void EnteredInStudent(Abiturient abiturient, List<Abiturient> Abiturients, List<Abiturient> Students)
        {
            if (abiturient.PassedExam == true)
            {
                Abiturients.Remove(abiturient);
                Students.Add(abiturient);
                Console.WriteLine("\nСтудент зачислен на факультет");
            }
            else
                Console.WriteLine("\nВы не зачисленны на факультет");

            foreach (var item in Students)
            {
                abiturient.Show(abiturient);
            }
        }
    }

    class Abiturient    // Абитуриент
    {
        private string abiturientFio = string.Empty;        // Фамилия инициалы абитуриента
        private bool passedExam = false;                    // Сдал ли вступительный экзамен? false / true
        private string abiturientFaculty = string.Empty;    // Название факультета студента 
        private int answerExamBuild = 0;                    // поле - содержит ответ на экзамен Строительного факультета 
        private string answerExamBio = string.Empty;        // поле - содержит ответ на экзамен факультета Биологии

        public string AbiturientFio { get => abiturientFio; set => abiturientFio = value; }
        public bool PassedExam { get => passedExam; set => passedExam = value; }
        public string AbiturientFaculty { get => abiturientFaculty; set => abiturientFaculty = value; }
        public int AnswerExamBuild { get => answerExamBuild; set => answerExamBuild = value; }
        public string AnswerExamBio { get => answerExamBio; set => answerExamBio = value; }

        public Abiturient(string fio, string faculty, bool exam)
        {
            abiturientFio = fio;
            abiturientFaculty = faculty;
            passedExam = exam;
        }

        public void Show(Abiturient abiturient)
        {
            Console.WriteLine("Фамилимя студента:\t{0}\nФакультет поступления:\t{1}\nПоступил:\t\t{2}", abiturientFio, abiturient.abiturientFaculty, passedExam);
        }
    }

    class Exam  // Экзамен
    {
        public void ExamBuildingFac(Abiturient abiturient)          // Метод - вступительный экзамен Строительного факультета (ответ: 4)))
        {
            Console.WriteLine("\nДля поступления на Строительный факультет решите задачу: ");
            Console.WriteLine("Сколько будет 2+2 ?");
            Console.Write("Ответ: ");
            abiturient.AnswerExamBuild = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ответ принят! Ожидайте результат...");
        }

        public void ExamBioFac(Abiturient abiturient)               // Метод - вступительный экзамен факультета Биологии (ответ: "человек")
        {
            Console.WriteLine("\nДля поступления на факультет Биологии ответьте на вопрос: ");
            Console.WriteLine("Как называется биологический организм именнуемый \"кожанный мешок с костями ?\"");
            Console.Write("Ответ: ");
            abiturient.AnswerExamBio = Console.ReadLine();

            Console.WriteLine("Ответ принят! Ожидайте результат...");
        }
    }

    class Teacher   // Преподаватель
    {
        public void CheckBuildingExam(int answer, Abiturient abiturient)        // Метод - проверки ответа на экзамен Строительного факультета  
        {
            if (answer == 4)
            {
                abiturient.PassedExam = true;
                Console.WriteLine("\nПоздравляем, вы успешно сдали экзамен Строительного факультета!");
            }
            else
                Console.WriteLine("\nВы не сдали экзамен Сторительного факультета!");
        }

        public void CheckBiologicExam(string answer, Abiturient abiturient)     // Метод - проверки ответа на экзамен факультета Биологии
        {
            if (answer == "человек")
            {
                abiturient.PassedExam = true;
                Console.WriteLine("\nПоздравляем, вы успешно сдали экзамен факультета Биологии!");
            }
            else
                Console.WriteLine("\nВы не сдали экзамен факультета Биологии!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Faculty faculty1 = new Faculty("Строительный факультет", new List<Abiturient>(), new List<Abiturient>());
            Faculty faculty2 = new Faculty("Факультет Биологии", new List<Abiturient>(), new List<Abiturient>());

            Abiturient abiturient1 = new Abiturient("Иванов И.И.", "Строительный факультет", exam: false);
            Abiturient abiturient2 = new Abiturient("Смирнов С.С.", "Факультет Биологии", exam: false);

            // Регистрация на выбранный факультет, довляет абитуриента в список на поступление 
            faculty1.AddAbiturient(abiturient1, faculty1.Abiturients);
            faculty2.AddAbiturient(abiturient2, faculty2.Abiturients);
            Console.WriteLine(new string('=', 50));

            Exam exam = new Exam();

            // Абитуриент сдает экзамен 
            exam.ExamBuildingFac(abiturient1);
            exam.ExamBioFac(abiturient2);
            Console.WriteLine(new string('=', 50));

            Teacher teacher = new Teacher();

            // Преподаватель проверяет ответ на экзамен и обьявляет результат
            teacher.CheckBuildingExam(abiturient1.AnswerExamBuild, abiturient1);
            teacher.CheckBiologicExam(abiturient2.AnswerExamBio, abiturient2);
            Console.WriteLine(new string('=', 50));

            // Студенты успешно сдавшие вступительные экзамены зачисляются на факультеты
            faculty1.EnteredInStudent(abiturient1, faculty1.Abiturients, faculty1.Students);
            faculty2.EnteredInStudent(abiturient2, faculty2.Abiturients, faculty2.Students);

            Console.ReadKey();
        }
    }
}
