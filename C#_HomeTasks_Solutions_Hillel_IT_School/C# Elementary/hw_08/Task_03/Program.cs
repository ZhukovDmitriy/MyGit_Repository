using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Создать расширяющий метод для целочисленного массива,
 * который сортирует элементы массива по возрастанию. 
 */
namespace Task_03
{
    public static class ExtensionMeths    // статический класс содержащий метод расширения
    {
        public static void ArraySort(this int[] array)  // метод расширения - сортировка массива по возрастанию
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];

            Console.Write("Введите числа через пробел: ");  
            string[] parts = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parts.Length; i++)
            {
                array[i] = Convert.ToInt32(parts[i]);
            }

            array.ArraySort();

            Console.WriteLine("Вывод отсортированного массива: ");

            foreach (int item in array)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
