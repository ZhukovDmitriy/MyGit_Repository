using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Mydb
{
    class WorkWithPhoneNumber           // Класс содержащий методы манимпуляции данными в БД для таблицы contact_phone_number - Добавить / Удалить / Обновить данные
    {
        public static void InsertPhoneNumber(int idChoice)          // Принимает параметр idChoice связующий его с Foreign Key конкретного человека 
        {                                                           // по таблице contact_phone_number, а также для передачи его методу OutputContactPhoneNumbers
            Console.Write("\nДобавьте номер телефона: ");
            string phoneNumber = Console.ReadLine();

            ConnectionDB.Connection.Open();

            string sqlQuery = string.Format("INSERT INTO contact_phone_numbers (Phone_number, Person_fk)" +
                                         "VALUES (@Phone_number, @Person_fk)");

            MySqlCommand command = new MySqlCommand(sqlQuery, ConnectionDB.Connection);

            command.Parameters.AddWithValue("@Phone_number", phoneNumber);
            command.Parameters.AddWithValue("@Person_fk", idChoice);

            command.ExecuteNonQuery();

            ConnectionDB.Connection.Close();

            Console.Clear();

            ConsoleOutput.OutputContactPhoneNumbers(idChoice);          // Вызов метода - вывода на консоль телефонных номеров (с уже добавленным телефоном)
        }

        public static void DeletePhoneNumber(int idChoice)          // Метод - удаления телефонного номера по выбранному id номера в списке номеров 
        {                                                           // Принимает idChoice только для того чтобы передать его как аргумент методу OutputContactPhoneNumbers            
            Console.WriteLine("\nДля удаления номера телефона");
            Console.Write("Введите его id: ");
            int idDel = int.Parse(Console.ReadLine());

            string sqlQuery = "DELETE FROM contact_phone_numbers WHERE ID = @idDel;";

            ConnectionDB.Connection.Open();

            MySqlCommand command = new MySqlCommand(sqlQuery, ConnectionDB.Connection);

            command.Parameters.AddWithValue("@idDel", idDel);

            command.ExecuteNonQuery();

            ConnectionDB.Connection.Close();

            Console.Clear();

            ConsoleOutput.OutputContactPhoneNumbers(idChoice);          // Вызов метода - вывода на консоль телефонных номеров (с уже удаленным номером телефона)
        }

        public static void UpdatePhoneNumber(int idChoice)          // Метод - обновления/изменения телефонного номера по выбранному id номера в списке номеров
        {                                                           // Принимает idChoice только для того чтобы передать его как аргумент методу OutputContactPhoneNumbers
            Console.Write("Введите ID телефона: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Введите номер: ");
            string phoneNumber = Console.ReadLine();

            ConnectionDB.Connection.Open();

            string sql = string.Format("UPDATE contact_phone_numbers SET Phone_number = '{0}' WHERE ID = '{1}'",
                phoneNumber, id);

            MySqlCommand command = new MySqlCommand(sql, ConnectionDB.Connection);

            command.ExecuteNonQuery();

            ConnectionDB.Connection.Close();

            Console.Clear();

            ConsoleOutput.OutputContactPhoneNumbers(idChoice);          // Вызов метода - вывода на консоль телефонных номеров (с обновленным номером телефона)
        }
    }
}
