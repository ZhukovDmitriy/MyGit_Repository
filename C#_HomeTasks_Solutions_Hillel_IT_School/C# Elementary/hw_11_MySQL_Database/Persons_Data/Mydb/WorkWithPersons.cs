using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Mydb
{
    class WorkWithPersons           // Класс содержащий методы манимпуляции данными в БД для таблицы persons - Добавить / Удалить / Обновить данные
    {
        public static void InsertData()
        {
            Console.WriteLine("\nДля добавления пользователя введите данные о нём: ");
            Console.Write("Введите ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Фамилия: ");
            string surname = Console.ReadLine();

            Console.Write("Имя: ");
            string firstname = Console.ReadLine();

            Console.Write("Отчество: ");
            string lastname = Console.ReadLine();

            ConnectionDB.Connection.Open();

            string sqlQuery = string.Format("INSERT INTO persons (IDPerson, Surname, Firstname, Lastname)" +
                                         "VALUES (@ID, @Surname, @Firstname, @Lastname)");

            MySqlCommand command = new MySqlCommand(sqlQuery, ConnectionDB.Connection);

            command.Parameters.AddWithValue("@ID", id);
            command.Parameters.AddWithValue("@Surname", surname);
            command.Parameters.AddWithValue("@Firstname", firstname);
            command.Parameters.AddWithValue("@Lastname", lastname);

            command.ExecuteNonQuery();

            ConnectionDB.Connection.Close();

            ConsoleOutput.OutputPersons();          // Вызов метода - вывод таблицы persons на консоль (с уже добавленными данными)  
        }

        public static void DeleteData()
        {
            Console.WriteLine("\nДля удаления пользвателя");
            Console.Write("Введите его id: ");
            int idDel = int.Parse(Console.ReadLine());

            string sqlQuery = "DELETE FROM persons WHERE IDPerson = @idDel;";

            ConnectionDB.Connection.Open();

            MySqlCommand command = new MySqlCommand(sqlQuery, ConnectionDB.Connection);

            command.Parameters.AddWithValue("@idDel", idDel);

            command.ExecuteNonQuery();

            ConnectionDB.Connection.Close();

            ConsoleOutput.OutputPersons();          // Вызов метода - вывод таблицы persons на консоль (с уже удаленными данными)  
        }

        public static void UpdateData()
        {
            Console.Write("Введите ID пользователя: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Фамилия: ");
            string surname = Console.ReadLine();

            Console.Write("Имя: ");
            string firstname = Console.ReadLine();

            Console.Write("Отчество: ");
            string lastname = Console.ReadLine();

            ConnectionDB.Connection.Open();

            string sql = string.Format("UPDATE persons SET Surname = '{0}', Firstname = '{1}', Lastname = '{2}' WHERE IDPerson = '{3}'",
                surname, firstname, lastname, id);

            MySqlCommand command = new MySqlCommand(sql, ConnectionDB.Connection);

            command.ExecuteNonQuery();

            ConnectionDB.Connection.Close();

            ConsoleOutput.OutputPersons();          // Вызов метода - вывод таблицы persons на консоль (с обновленными данными)  
        }
    }
}
