using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Mydb
{
    class OptionsChoice             // Класс содержащий методы - выводящие список команд дальнейших действий для соответствующих таблиц
    {
        public static void ChoicePersons()          // Выбор команд дальнейших действий для таблицы persons 
        {
            int choice;

            Console.WriteLine("\nВыберите действие: \n");
            Console.WriteLine(" - Добавить контакт:\t\t[1]\n - Удалить контакт:\t\t[2]\n - Обновить данные:\t\t[3]\n" +
                " - Подробная информация:\t[4]\n\n - Выйти из программы:\t\t[5]");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                WorkWithPersons.InsertData();           // Вызываем метод - добавляющий человека в таблицу persons
            }
            else if (choice == 2)
            {
                WorkWithPersons.DeleteData();           // Вызов метода - удаляющий все данные выбранного человека  
            }
            else if (choice == 3)
            {
                WorkWithPersons.UpdateData();           // Вызов метода - обновления данных выбранного человека
            }
            else if (choice == 4)
            {
                ConsoleOutput.AdditionalInformation();  // Вызов  вспомогательного метода - дополнительная информация о человеке по id
            }
            else if (choice == 5)
            {
                Environment.Exit(0);                    // Завершение работы программы
            }
        }

        public static void AdditionalPersonChoice(int idChoice)             // Выбор команд дальнейших действий для конкретного человека 
        {                                                                   // (принимает id человека (idChoice) - для дальнейшей передачи параметра вызываемым методам)
            int referenceID = idChoice;                                      

            Console.WriteLine("\nВывести: \n");
            Console.WriteLine(" - Контактные номера:\t\t\t[1]\n - Email адреса:\t\t\t[2] [в разработке]\n" + 
                " - Адрес проживания:\t\t\t[3] [в разработке]\n - Всю информацию о человеке:\t\t[4] [в разработке]\n\n" + 
                " - Вернуться в предыдущее меню\t\t[5]");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                ConsoleOutput.OutputContactPhoneNumbers(idChoice);          // Вызываем метод - вывода на консоль телефонных номеров конкретного человека 
            }                                                               // для этого передаем id человека - аргумент (idChoice)
            else if (choice == 2)   
            {
                Console.WriteLine("Функция в процессе разработки!\nДля продолжения нажмите Enter...");
                Console.ReadKey();
                AdditionalPersonChoice(idChoice);
            }
            else if (choice == 3)
            {
                Console.WriteLine("Функция в процессе разработки!\nДля продолжения нажмите Enter...");
                Console.ReadKey();
                AdditionalPersonChoice(idChoice);
            }
            else if (choice == 4)
            {
                Console.WriteLine("Функция в процессе разработки!\nДля продолжения нажмите Enter...");
                Console.ReadKey();
                AdditionalPersonChoice(idChoice);
            }
            else if (choice == 5)
            {
                Console.Clear();
                ConsoleOutput.OutputPersons();          // Вызов метода - выводящий таблицу persons - возврат к предыдущей таблице
            }
        }

        public static void ChoiceContactPhoneNumber(int idChoice)           // Выбор команд дальнейших действий  
        {                                                                   // для таблицы телефонных номеров человека, по его id
            int choice;

            Console.WriteLine("\nВыберите действие: \n");
            Console.WriteLine(" - Добавить телефон:\t\t[1]\n - Удалить телефон:\t\t[2]\n - Обновить телефон:\t\t[3]\n\n" +
                " - Вернуться в предыдущее меню:\t[4]");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                WorkWithPhoneNumber.InsertPhoneNumber(idChoice);            // Вызов метода - добавления телефонного номера человека, по его Foreign Key 
            }
            else if (choice == 2)
            {
                WorkWithPhoneNumber.DeletePhoneNumber(idChoice);            // Вызов метода - удаления телефонного номера человека, по ID номера телефона в списке  
            }
            else if (choice == 3)
            {
                WorkWithPhoneNumber.UpdatePhoneNumber(idChoice);            // Вызов метода - обновления/изменения текущего номера, по ID номера в списке
            }
            else if (choice == 4)
            {
                Console.Clear();
                AdditionalPersonChoice(idChoice);                           // Возврат в предидущее меню - меню выбора команд дальнейших действий 
            }                                                               // для конкретного человека (по его id). Передаем обратно аргумент idChoice     
        }
    }
}
