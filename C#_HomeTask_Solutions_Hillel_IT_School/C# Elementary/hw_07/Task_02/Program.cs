using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;     // пространство имен содержит классы для воспроизведения звуковых файлов

/*Создайте 2 интерфейса IPlayable и IRecodable.
 * В каждом из интерфейсов создайте по 3 метода
 * void Play()
 * void Pause()
 * void Stop()
 * и
 * void Record()
 * void Pause()
 * void Stop() соответственно. 
 * Создайте производный класс Player 
 * от базовых интерфейсов IPlayable и IRecodable.
 * Написать программу, которая выполняет проигрывание и запись.
 */
namespace Task_02
{
    public interface IPlayable  // Интерфейс IPlayable
    {
        void Play(string path);     // Метод Play()
        //void Pause();
        void Stop(string path);     // Метод Stop()
    }

    public interface IRecordable    // Интерфейс IRecordable 
    {
        void Record(string path);
        void Pause(string path);
        void Stop(string path);
    }

    class Player : IPlayable, IRecordable    // Реализовать интерфейсы IPlayable и IRecordable в классе Player
    {
        void IPlayable.Play(string path)   // Явная реализация интерфейса IPlayable - воспроизведение аудиофайла
        {
            try
            {
                SoundPlayer sp = new SoundPlayer(path);
                sp.Play();
            }

            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return;
            }
        }

        //void IPlayable.Pause(string path)   // Интерфейс IPlayable не реализован, так как метод Pause() отсутствует в пространстве имен System.Media
        //{

        //}

        void IPlayable.Stop(string path)     // Явная реализация интерфейса IPlayable - остановка воспроизведения аудиофайла
        {
            SoundPlayer sp = new SoundPlayer(path);
            sp.Stop();
        }

        // Интерфейс IRecordable в программе не реализован !
        void IRecordable.Record(string path)    
        {
            Console.WriteLine("Record");
        }

        void IRecordable.Pause(string path)
        {
            Console.WriteLine("Pause");
        }

        void IRecordable.Stop(string path)
        {
            Console.WriteLine("Stop");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tПрограмма поддерживает проигрывание только файлов формата .wav");
            Console.WriteLine(new string('=', 80));

            Player player = new Player();
            IPlayable iPlay = player;       // Интерфейсная ссылка  IPlayable на объект класса Player 
            IRecordable iRec = player;      // Интерфейсная ссылка  IRecordable на объект класса Player 

            string filePath;

            Console.Write("Укажите полный путь, имя и расширение открываемого аудиофайла .wav\n: ");
            filePath = Console.ReadLine();

            ConsoleKeyInfo keyPress;

            Console.WriteLine("\nФайл: {0} подготовен к воспроизведению\nНажмите следующие из клавиш: \n", filePath);
            Console.WriteLine(" p\tPlay (Воспроизвести)\n h\tHold (Пауза)\t! функция не реализована в данной версии программы !" +
                                                      "\n s\tStop (Остановить)\n q\tQuit (Выйти из  программы)");

            do
            {
                Console.WriteLine();
                keyPress = Console.ReadKey();

                if (keyPress.KeyChar == 'p')
                {
                    Console.WriteLine(" - Воспроизвести аудеофайл");
                    iPlay.Play(filePath);       // Вызов метода Play() по ссылке на интерфейс IPlayable
                }

                //else if (keyPress.KeyChar == 'h')
                //{
                //    Console.WriteLine(" - Приостановить воспроизведение");
                //    iPlay.Pause(filePath);
                //}

                else if (keyPress.KeyChar == 's')
                {
                    Console.WriteLine(" - Остановить воспроизведение");
                    iPlay.Stop(filePath);       // Вызов метода Stop() по ссылке на интерфейс IPlayable
                }

                else if (keyPress.KeyChar == 'q')
                {
                    Console.WriteLine(" - Закрыть программу");
                }

            } while (keyPress.KeyChar != 'q');
        }
    }
}
