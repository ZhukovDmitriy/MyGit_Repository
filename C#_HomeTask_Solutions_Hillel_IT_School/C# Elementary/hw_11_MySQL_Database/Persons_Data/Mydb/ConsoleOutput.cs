using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Mydb
{
    class ConsoleOutput             // Класс содержит методы - выводящие на консоль данные из БД
    {
        public static void OutputPersons()          //  Вывод данных из таблицы persons - выводит на консоль список всех людей   
        {
            Console.Clear();

            ConnectionDB.Connection.Open();

            string sqlQuery = "SELECT IDPerson, Surname, Firstname, Lastname FROM persons";

            MySqlCommand command = new MySqlCommand(sqlQuery, ConnectionDB.Connection);

            MySqlDataReader reader = command.ExecuteReader();

            Console.WriteLine();
            while (reader.Read())
            {
                Console.WriteLine(reader[0].ToString() + " | " + reader[1].ToString() + " | " + reader[2].ToString() + " | " + reader[3].ToString());
            }

            ConnectionDB.Connection.Close();

            OptionsChoice.ChoicePersons();          // Вызов метода - выбор команд дальнейших действий для таблицы persons
        }

        public static void AdditionalInformation()          // Вспомогательный метод - необходим для вывода на консоль конкретного человека из таблицы persons
        {                                                   // по заданному id человека
            ConnectionDB.Connection.Open();

            Console.WriteLine("\nДля вывода подробной информации о персоне");
            Console.Write("Введите id: ");

            int idChoice = int.Parse(Console.ReadLine());

            string sqlQuery = string.Format("SELECT IDPerson, Surname, Firstname, Lastname FROM persons WHERE IDPerson = '{0}'", idChoice);

            MySqlCommand command = new MySqlCommand(sqlQuery, ConnectionDB.Connection);

            MySqlDataReader reader = command.ExecuteReader();

            Console.Clear();

            while (reader.Read())
            {
                Console.WriteLine("\n\t\t\t" + reader[0].ToString() + " | " + reader[1].ToString() + " | " + reader[2].ToString() + " | " + reader[3].ToString());
            }

            ConnectionDB.Connection.Close();

            OptionsChoice.AdditionalPersonChoice(idChoice);             // Вызываем метод - выводящий на консоль список команд дальнейших действий 
        }                                                               // для выбранной персоны по его id (передаем соответствующий аргумент idChoice)               

        public static void OutputContactPhoneNumbers(int idChoice)      // Метод вывода на консоль таблицы с телефонными номерами - конкретного человека
        {                                                               // (принимает id человека (параметр idChoice)) для вывода его телефонных номеров. 
            ConnectionDB.Connection.Open();                             

            string sqlQuery = string.Format("SELECT ID, Phone_number FROM contact_phone_numbers WHERE Person_fk = '{0}'", idChoice);

            MySqlCommand command = new MySqlCommand(sqlQuery, ConnectionDB.Connection);

            MySqlDataReader reader = command.ExecuteReader();

            Console.WriteLine();
            while (reader.Read())
            {
                Console.WriteLine(reader[0].ToString() + " | " + reader[1].ToString());
            }

            ConnectionDB.Connection.Close();

            OptionsChoice.ChoiceContactPhoneNumber(idChoice);           // Вызываем метод - выбора дальнейших действий (команд) для таблицы телефонных номеров
        }                                                               // конкретного человека (передаем id человека (аргумент idChoice))
    }
}
