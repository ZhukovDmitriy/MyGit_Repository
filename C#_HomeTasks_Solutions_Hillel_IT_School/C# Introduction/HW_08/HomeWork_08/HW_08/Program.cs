using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "HW_08";
            // Задача 1 
            Console.WriteLine("\tЗадача 1");
            Console.WriteLine("Дано слово. Вывести на экран его третий символ.");

            string str = string.Empty;

            Console.Write("\nВведите слово не короче трех букв: ");
            do
            {
                str = Console.ReadLine();
                if (str.Length < 3)
                    Console.Write("Ваше слово короче трёх букв!\nПовторите ввод: ");

            } while (str.Length < 3);
            
            Console.WriteLine("Отлично!\nТретий символ вашего слова: {0}", str[3 - 1]);
            Console.WriteLine("Для перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            
            // Задача 2 
            Console.WriteLine("\n\tЗадача 2");
            Console.WriteLine("Дано слово. Определить, одинаковы ли второй и четвертый символы в нем.");
                        
            Console.Write("\nВведите слово: ");
            string str2 = Console.ReadLine();

            if (str2[2 - 1] == str2[4 - 1])
            {
                Console.WriteLine("Второй и четвертый символы одинаковы");
            }
            else
            {
                Console.WriteLine("Второй и четвертый символы разные");
            }

            Console.WriteLine("Для перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            
            // Задача 3 
            Console.WriteLine("\n\tЗадача 3");
            Console.WriteLine("Дано название футбольного клуба. Напечатать его на экране \"столбиком\".");

            string str3 = "Шахтер";

            for (int i = 0; i < str3.Length; i++)
            {
                Console.WriteLine("\n\t" + str3[i]);
            }

            Console.WriteLine("\nДля перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            
            // Задача 4 
            Console.WriteLine("\n\tЗадача 4");
            Console.WriteLine("Дано слово s1. Получить слово s2, образованное нечетными буквами слова s1");

            string s2 = string.Empty;

            Console.Write("\nВведите слово: ");
            string s1 = Console.ReadLine();

            for (int i = 0; i < s1.Length; i += 2)
            {
                s2 = s2 + s1[i];
            }

            // Либо использовать if (i % 2 == 0)
            // перебирая каждый символ; i++
             
            Console.Write("\nСлово s2: " + s2);
            Console.Write("\nСлово s1: " + s1);
            Console.WriteLine("\nДля перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            
            // Задача 5 
            Console.WriteLine("\n\tЗадача 5");
            Console.WriteLine("Дан текст. Сколько раз в нем встречается символ \" + \" \nи сколько раз символ \" * \" ?");

            Console.Write("\nВведите текст с наличием символов \" + \" \" * \": ");
            string str4 = Console.ReadLine();

            int countPlus = 0;
            int countStar = 0;

            for (int i = 0; i < str4.Length; i++)
            {
                if (str4[i] == '+')
                    countPlus++;

                if (str4[i] == '*')
                    countStar++;
            }

            Console.WriteLine("\nСимвол \" + \" встречается в тексте {0} раз(а)", countPlus);
            Console.WriteLine("Символ \" * \" встречается в тексте {0} раз(а)", countStar);
            Console.WriteLine("\nДля перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            
            // Задача 6 
            Console.WriteLine("\n\tЗадача 6");
            Console.WriteLine("Дано предложение. Все буквы е в нем заменить буквой и.");

            Console.Write("\nВведите предложение: ");           // Решение с помощью метода Replace();
            string str5 = Console.ReadLine();

            str5 = str5.Replace("е", "и");
            str5 = str5.Replace("Е", "И");

            Console.Write("\n(Решение 2) Введите предложение: ");           // Решение с помощью класса StringBuilder
            StringBuilder str6 = new StringBuilder(Console.ReadLine());

            for (int i = 0; i < str6.Length; i++)
            {
                if (str6[i] == 'е')
                    str6[i] = 'и';

                if (str6[i] == 'Е')
                    str6[i] = 'И';
            }

            Console.WriteLine("\nВывод результата: {0}", str5);
            Console.WriteLine("\n(Решение 2) Вывод результата: {0}", str6);
            Console.WriteLine("Для перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            
            // Задача 7 
            Console.WriteLine("\n\tЗадача 7");
            Console.WriteLine("Дано предложение. Все пробелы в нем заменить символом \"_\".");

            Console.Write("\nВведите предложение: ");
            string str7 = Console.ReadLine();

            str7 = str7.Replace(" ", "_");

            Console.WriteLine("\nВывод резальтата: {0}", str7);
            Console.WriteLine("Для перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            
            // Задача 8 
            Console.WriteLine("\n\tЗадача 8");
            Console.WriteLine("Дан текст. Напечатать все имеющиеся в нем цифры.");

            Console.Write("\nВведите текст с наличием в нём цифр: ");
            string str8 = Console.ReadLine();

            Console.Write("\nВывод всех имеющихся в тексте цифр: ");

            char[] arrNum = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            for (int i = 0; i < str8.Length; i++)
            {
                for (int j = 0; j < arrNum.Length; j++)
                {
                    if (arrNum[j] == str8[i])
                        Console.Write(arrNum[j]);
                }
            }

            Console.WriteLine("\nДля перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            
            // Задача 9 
            Console.WriteLine("\n\tЗадача 9");
            Console.WriteLine("Дан текст, в котором имеются цифры. \nа) Найти их сумму. \nб) Найти максимальную цифру");

            Console.Write("\nВведи текст с наличием в нём цифр: ");
            string str9 = Console.ReadLine();
            string str10 = string.Empty;
            long sum = 0, kMax = 0, k = 0;

            for (int i = 0; i < str9.Length; i++)
            {
                if (char.IsDigit(str9[i]))
                {
                    str10 += str9[i];
                }
            }

            long number = Int64.Parse(str10);               // Int64 Может вместить большее число нежели Int32
                                                            // Int64 -- (-9,223,372,036,854,775,808 to +9,223,372,036,854,775,807)

            for (long i = number; number > 0; number /= 10)
            {
                k = number % 10;
                sum += k;

                if (k > kMax)
                {
                    kMax = k;
                }
            }

            Console.WriteLine("\nСумма всех цифр в тексте: {0}", sum);
            Console.WriteLine("\nМасимальная цифра в тексте: {0}", kMax);
            Console.WriteLine("\nДля перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            
            // Задача 10 
            Console.WriteLine("\n\tЗадача 10");
            Console.WriteLine("Составить программу, которая запрашивает название государства и его столицы," +
                "\nа затем выводит сообщение: \"Столица государства... — город...\"" +
                "\n(на месте многоточий должны быть выведены соответствующие значения)." +
                "\nПопробовать решить  с помощью массивов или/и swtich");

            string[] arrCountry = new string[3];
            string[] arrCapital = new string[3];

            for (int i = 0; i < arrCountry.Length; i++)
            {
                Console.Write("\nВведите название страны: ");
                string country = Console.ReadLine();
                arrCountry[i] += country;

                Console.Write("Введите название её столицы: ");
                string capital = Console.ReadLine();
                arrCapital[i] += capital;
            }

            Console.WriteLine("\nНазвание введенных вами государств: ");

            for (int i = 0; i < arrCountry.Length; i++)
            {
                Console.WriteLine((i + 1) + "." + arrCountry[i]);
            }

            Console.Write("\nСтолицу какого государства вы хотите вывести на экран?\nВведите номер государства: ");
            int question = Convert.ToInt32(Console.ReadLine());

            switch (question)

            {
                case 1:
                    Console.WriteLine("\nСтолица государства {0} - город {1}", arrCountry[0], arrCapital[0]);
                    break;
                case 2: 
                    Console.WriteLine("\nСтолица государства {0} - город {1}", arrCountry[1], arrCapital[1]);
                    break;
                case 3: 
                    Console.WriteLine("\nСтолица государства {0} - город {1}", arrCountry[2], arrCapital[2]);
                    break;
            }

            Console.WriteLine("\nДля перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            
            // Задача 11 
            Console.WriteLine("\n\tЗадача 11");
            Console.WriteLine("Даны три слова. Напечатать их общие буквы. \nПовторяющиеся буквы каждого слова не рассматривать.");

            Console.Write("\nНапечатайте несколько слов: ");
            string[] arrWords = Console.ReadLine().Split(' ');      // .Split() делит строку на части между символами которые ему передадут в 1 параметре
                                                                    // Пример: "вася/петя/саша".Split('/');
                                                                    // Вернет в массив: string[] {"вася", "петя", "саша"}
            string letter = string.Empty;

            foreach (string Word in arrWords)                       // По очереди обрабатывет каждый элемент (каждое разделенное слово) массива 
            {
                for (int i = 0; i < arrWords.Length; i++)
                {
                    if (Word != arrWords[i])
                    {
                        for (int j = 0; j < Word.Length; j++)
                        {
                            if (arrWords[i].ToString().IndexOf(Word[j]) != -1 && letter.IndexOf(Word[j]) == -1)
                            // Преобразует эллемент массива arrWords[i] в строковое представление 
                            // и просматривает в нем наличие символов из элемента Word[j]
                            // Пример: В слове петя  ищет поочередно наличие символов: в а с я 

                            // в случае совпадения - добавляет символ в string letter.
                            // в дальнейшем проверяет в условии if наличие уже существующего символа && letter.IndexOf(Word[j]) == -1
                            {
                                letter += Word[j];          
                            }
                        }
                    }
                }
            }

            if (letter == "")
                Console.WriteLine("Слова не имеют общих букв");
            else
                Console.WriteLine("\nОбщие буквы слов: {0}", letter);

            Console.WriteLine("\nДля перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            
            // Задача 12 
            Console.WriteLine("\n\tЗадача 12");
            Console.WriteLine("Дано предложение из 10 слов. Заполнить ими массив из 10 элементов.");

            Console.WriteLine("\nВведите предложение содержащее не более 10 слов: ");
            string text = Console.ReadLine();

            string[] arrWords2 = new string[10];
            arrWords2 = text.Split(' ');
            Console.Write("Массив заполнен!");

            Console.Write("\n\nВведите номер слова которое хотите вывести: ");      // Проверка
            int f = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nВаше слово: {0}", arrWords2[f - 1]);
            Console.WriteLine("\nДля перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            
            // Задача 13 
            Console.WriteLine("\n\tЗадача 13");
            Console.WriteLine("Дано предложение. Напечатать его в обратном порядке слов, например," +
                "\nпредложение мама мыла раму должно быть напечатано в виде раму мыла мама.");

            Console.Write("\nВведите предложение: ");
            string[] arrWords3 = Console.ReadLine().Split(' ');

            Console.Write("\nВывод результата: ");

            for (int i = arrWords3.Length - 1; i >= 0; i--)
            {
                Console.Write(arrWords3[i] + " ");
            }

            Console.WriteLine("\nДля перехода к следующей задаче нажмите Enter...");
            Console.ReadKey();
            
            // Задача 14 
            Console.WriteLine("\n\tЗадача 14");
            Console.WriteLine("Дано предложение. Определить:" +
                "\nа) количество слов, начинающихся с буквы н;\nб) количество слов, оканчивающихся буквой р.");

            int countStart = 0;
            int countEnd = 0;

            Console.Write("\nВведите предложение: ");
            string[] arrWords4 = Console.ReadLine().ToLower().Split(' ');
            
            foreach (string Word in arrWords4)
            {
                if (Word.StartsWith("н"))
                {
                    countStart++;
                }

                if (Word.EndsWith("р"))
                {
                    countEnd++;
                }
            }

            Console.WriteLine("\nКоличество слов начинающихся на букву \"н\": {0}", countStart);
            Console.WriteLine("\nКоличество слов заканчивающихся на букву \"р\": {0}", countEnd);
            Console.WriteLine("\nДля завершения работы программы нажмите Enter...");
            Console.ReadKey();
            
        }
    }
}
