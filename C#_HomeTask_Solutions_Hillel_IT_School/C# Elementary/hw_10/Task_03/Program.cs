using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Создайте анонимный метод,
 * который принимает в качестве аргумента массив делегатов
 * и возвращает среднее арифметическое возвращаемых значений методов сообщенных с делегатами в массиве.
 * Методы, сообщенные с делегатами из массива, возвращают случайное значение типа int.
 */
namespace Task_03
{
    delegate int Number();
    delegate double AverageValue(Number[] delegates);

    class DelegateDemo
    {
        static Random random = new Random();

        static int AddNumber()
        {
            int randomValue = 0;

            randomValue = random.Next(1, 10);

            Console.WriteLine("Случайное значение: {0}", randomValue);

            return randomValue;
        }

        static void Main(string[] args)
        {
            Number number = new Number(AddNumber);

            Number[] arrayObject = new Number[3] { number, number, number };

            AverageValue value = delegate (Number[] delegates)
            {
                double result = 0;

                for (int i = 0; i < delegates.Length; i++)
                {
                    result += delegates[i]();
                }
                
                result = result / delegates.Length;

                return result;
            };

            Console.WriteLine("\nСреднее арифметическое: {0}", value(arrayObject));

            Console.ReadKey();
        }
    }
}
