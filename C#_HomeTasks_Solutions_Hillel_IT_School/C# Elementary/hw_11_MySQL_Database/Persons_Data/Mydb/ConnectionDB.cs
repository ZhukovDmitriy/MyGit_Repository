using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Mydb
{
    class ConnectionDB          
    {
        static MySqlConnection connection;

        public static MySqlConnection Connection { get => connection; set => connection = value; }

        public void ConnectionRequest()
        {
            // Console.Write("Порт: ");
            // string server = Console.ReadLine();
            string server = "127.0.0.1";

            // Console.Write("Имя пользователя: ");
            // string user = Console.ReadLine();
            string user = "root";

            // Console.Write("Имя базы данных: ");
            // string database = Console.ReadLine();
            string database = "persons_data";

            Console.Write("Введите пароль администартора: ");
            string password = Console.ReadLine();

            OpenConnection(server, user, database, password);
        }

        public void OpenConnection(string server, string user, string database, string password)
        {
            MySqlConnectionStringBuilder connString = new MySqlConnectionStringBuilder();

            connString.Server = server;
            connString.UserID = user;
            connString.Database = database;
            connString.Password = password;
            connString.CharacterSet = "utf8";

            // string connString = "server=127.0.0.1;user=root;database=persons_data;password=Lakrus88;charset=utf8;";

            Connection = new MySqlConnection(connString.ToString());

            try
            {
                Connection.Open();

                Console.Clear();
                Console.WriteLine("Подключение успешно произведенно!\nДля продолжения нажмите Enter...");
                Console.ReadKey();

                Connection.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine("\n" + exc.Message + "\nОшибка подключения!\nДля завершения работы программы нажмите Enter...");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void CloseConnection()
        {
            Connection.Close();
        }
    }
}
