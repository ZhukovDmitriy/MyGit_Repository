using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;    // Пространство имен System.Data.SqlClient является поставщиком данных платформы .NET для SQL Server.

/* Изучить Singelton.
 * Создать класс, где необходимо подключить базу данных в проект и класс,
 * который будет отвечать за соединение с ней.
 * Один раз создается соединение и нет нужды создавать его снова и снова.
 */
namespace Task_04
{
    public sealed class Database    
    {
        private static volatile SqlConnection instance;

        private const string connectionString = "Data Source=ServerName;" +
                                                "Initial Catalog=DataBaseName;" +
                                                "User id=UserName;" +
                                                "Password=Secret;";

        private Database() { }

        public static SqlConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    {
                        if (instance == null)
                            instance = new SqlConnection(connectionString);
                    }
                }

                return instance;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = Database.Instance;
            SqlConnection sqlConnection2 = Database.Instance;

            Console.WriteLine(sqlConnection.GetHashCode());
            Console.WriteLine(sqlConnection.GetHashCode());

            Console.ReadKey();
        }
    }
}
