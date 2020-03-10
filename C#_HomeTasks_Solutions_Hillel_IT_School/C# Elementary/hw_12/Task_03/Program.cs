using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/* Расширьте задание 2, так,
 * чтобы в одном столбце одновременно могло быть две цепочки символов.
 */
namespace Task_03
{
    class Matrix
    {
        static object lockOn = new object();    // Закрытый статический обьект синхронизации доступа к разделяемому ресурсу (обьект блокировки),  
                                                // доступный для последующей блокировки
        Random random;

        string symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";    // Строковое поле (36 символов)

        private int colunm;         // Столбец
        private bool doubleChain;

        public int Colunm { get => colunm; set => colunm = value; }
        public bool DoubleChain { get => doubleChain; set => doubleChain = value; }

        public Matrix(int colunm, bool doubleChain)
        {
            this.colunm = colunm;
            this.doubleChain = doubleChain;

            // Генерация случайных чисел происходит по четкому математическому алгоритму
            // Эта переменная дается алгоритму для генерации, а посколько DateTime.Now.Ticks это 1 / 1000 секунды
            // то это делает маловероятным тот факт что милисекунды двух генераций совпадут
            random = new Random((int)DateTime.Now.Ticks);   // Этим способом можно добиться максимальной неповторимости    
        }

        public char GetChar()   // Метод возвращающий случайный символ
        {
            return symbols.ToCharArray()[random.Next(0, 35)];   // Копируем символы в массив знаков, 
                                                                // где метод Next будет выбирать один случайный символ из массива в диапазоне от 1 - 36
        }

        public void Fall()  // Метод отображения одной цепочки
        {
            int lenght;     // Длина одной цепочки
            int count;      // Количество символов цепочки

            while (true)    // Бесконечный цикл - регулируемый вызовом метода Fall из цикла for в методе Main  
            {
                count = random.Next(3, 12);  // Метод возвращает случайную длинну цепочки в указаном промежутке
                lenght = 0;

                // Останавливаем поток на случайное значение - полученное методом Next в указаном диапазоне (в миллисекундах)
                Thread.Sleep(random.Next(20, 5000));    // Если закоментировать, то все цепочки появятся почти одновременно                

                for (int i = 0; i < 40; i++)
                {
                    // Заблокировать блок кода - организовываем управление доступом к кодовому блоку в обьекте для одного потока
                    lock (lockOn)   // Когда блокировка снимается одним потоком, обьект становится доступен для использования в другом потоке    
                    {
                        // Console.CursorTop = 0;                       // Задаем позицию строки курсора
                        Console.ForegroundColor = ConsoleColor.Black;   // Устанавливаем цвет курсора
                        Console.CursorTop = i - lenght;                 // Устанавливаем строку в которой нужно отобразить символ

                        for (int j = i - lenght - 1; j < i; j++)
                        {
                            Console.CursorLeft = Colunm;    // Устанавливаем позицию курсора в столбце
                            Console.WriteLine(" ");         // Курсор
                        }

                        if (lenght < count)
                        {
                            lenght++;   // Увеличиваем длинну цепочки
                        }

                        else if (lenght == count)
                        {
                            count = 0;  // Обнуляем переменную
                        }

                        if (DoubleChain && i < 20 && i > lenght + 2 && (random.Next(1, 5) == 3))
                        {
                            new Thread(new Matrix(Colunm, false).Fall).Start();     // Вызываем метод Fall в новом потоке

                            DoubleChain = false;
                        }

                        if (39 - i < lenght)
                        {
                            lenght--;   // Уменьшаем длинну цепочки по достижению заданной нижней гранницы консоли
                        }

                        Console.CursorTop = i - lenght + 1; // Устанавливаем координату курсора от верхенего края консоли
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        for (int j = 0; j < lenght - 2; j++)
                        {
                            Console.CursorLeft = Colunm;    // Устанавливаем позицию курсора в рядке
                            Console.WriteLine(GetChar());   // Получаем и выводим на консоль случайный символ 
                        }

                        if (lenght >= 2)    // Для каждого второго символа в цепочке
                        {
                            Console.ForegroundColor = ConsoleColor.Green;   // Устанавливаем цвет
                            Console.CursorLeft = Colunm;                    // Устанавливаем позицию в столбце
                            Console.WriteLine(GetChar());                   // Получаем и выводим на консоль случайный символ 
                        }

                        if (lenght >= 1)    // Для каждого первого символа в цепочке
                        {
                            Console.ForegroundColor = ConsoleColor.White;   // Устанавливаем цвет
                            Console.CursorLeft = Colunm;                    // Устанавливаем позицию в столбце
                            Console.WriteLine(GetChar());                   // Получаем и выводим на консоль случайный символ 
                        }

                        Thread.Sleep(20);
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.SetWindowSize(80, 42);  // Устанавливаем размер окна консоли в размере 80-ти символов по ширине  

            Matrix mx;

            for (int i = 0; i < 26; i++)
            {
                mx = new Matrix(i * 3, true);
                new Thread(mx.Fall).Start();    // Запускаем метод Fall экземпляра класса mx в отдельном потоке
            }

            Console.ReadKey();
        }
    }
}
