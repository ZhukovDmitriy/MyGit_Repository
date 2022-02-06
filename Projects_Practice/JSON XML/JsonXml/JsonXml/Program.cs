using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace JsonXml
{
    public class User
    {
        public int UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }

    public class Message
    {
        public int MessageID { get; set; }
        public int UserID { get; set; }
        public string Content { get; set; }
    }

    public class Test
    {
        public string StartDate { get; set; }
        public string TimeSign { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyCodeL { get; set; }
        public double Units { get; set; }
        public double Amount { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Настройка форматирования JSON
            var jsonOptions = new JsonSerializerOptions
            {
                // Строковые пробелы
                WriteIndented = true
            };

            // Базовый лист пользователей
            List<User> users = new List<User>()
            {
                 new User { UserID = 1, LastName = "Zhukov", FirstName = "Dima" },
                 new User { UserID = 2, LastName = "Smirnov", FirstName = "Dima" }
            };

            // Сериализация списка пользователей
            string jsonUsers = JsonSerializer.Serialize(users, jsonOptions);

            Console.WriteLine("==========");
            Console.WriteLine("Список сериализованных пользователей");
            Console.WriteLine(jsonUsers);
            Console.WriteLine();

            // Запись пользователей в файл 
            File.WriteAllText(@"D:\MyProjects\Projects_Practice\JSON XML\Users.json", jsonUsers);

            // Работа с сообщениями!
            // Создание пустого списка для хранения сообщений
            List<Message> messages = new List<Message>();

            // Создание первого сообщения
            Message message1 = new Message { MessageID = 1, UserID = 1, Content = "Hello World" };
            messages.Add(message1);

            // Сериализация списка сообщений
            string jsonMessages = JsonSerializer.Serialize(messages, jsonOptions);

            Console.WriteLine("==========");
            Console.WriteLine("Первое сериализованное сообщение");
            Console.WriteLine(jsonMessages);
            Console.WriteLine();

            File.WriteAllText(@"D:\MyProjects\Projects_Practice\JSON XML\Messages.json", jsonMessages);

            // Создание второго сообщения
            Message message2 = new Message { MessageID = 2, UserID = 2, Content = "Hello World Again" };

            // Чтение сериализованной строки из файла .json
            string restoredMessages = File.ReadAllText(@"D:\MyProjects\Projects_Practice\JSON XML\Messages.json");

            // Десириализация строки в список сообщений
            List<Message> deserializeMessages = JsonSerializer.Deserialize<List<Message>>(restoredMessages);
            deserializeMessages.Add(message2);

            string newJsonMessages = JsonSerializer.Serialize(deserializeMessages, jsonOptions);

            Console.WriteLine("==========");
            Console.WriteLine("Добавление второго сериализованного сообщения");
            Console.WriteLine(newJsonMessages);
            Console.WriteLine();

            File.WriteAllText(@"D:\MyProjects\Projects_Practice\JSON XML\Messages.json", newJsonMessages);

            // Извлечение и редактирование сообщений!
            // Чтение сериализованной строки из файла .json
            string restoredMessages2 = File.ReadAllText(@"D:\MyProjects\Projects_Practice\JSON XML\Messages.json");

            // Десириализация строки в список сообщений
            List<Message> deserializeMessages2 = JsonSerializer.Deserialize<List<Message>>(restoredMessages2);

            deserializeMessages2[1].Content = "Modified Message";

            // Сериализация отредактированных сообщений в строку
            string newJsonMessages2 = JsonSerializer.Serialize(deserializeMessages2, jsonOptions);

            Console.WriteLine("==========");
            Console.WriteLine("Вывод отредактированных сериализованных сообщений");
            Console.WriteLine(newJsonMessages2);
            Console.WriteLine();

            File.WriteAllText(@"D:\MyProjects\Projects_Practice\JSON XML\Messages.json", newJsonMessages2);
        }
    }
}
