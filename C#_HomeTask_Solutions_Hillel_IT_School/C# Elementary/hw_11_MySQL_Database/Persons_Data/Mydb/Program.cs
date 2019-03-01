using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Mydb
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionDB connectionDB = new ConnectionDB();
            connectionDB.ConnectionRequest();                   // Программа начинается с вызова метода - запрос на подключение 
           
            ConsoleOutput.OutputPersons();                      // Далее вызывается метод - вывода на консоль таблицы данных о всех персонах

            Console.ReadKey();
        }
    }
}
