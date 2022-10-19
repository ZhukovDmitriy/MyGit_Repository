using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Npgsql;

namespace DockerTest
{
    class Program
    {
        public List<string> Message { get; set; }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Message = new List<string>();

            // Publisher
            var counter = 0;
            int timeToSleep = new Random().Next(1000, 3000);

            // Docker
            var factory = new ConnectionFactory()
            {
                HostName = "rabbit",
                UserName = "guest",
                Password = "guest"
            };

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(timeToSleep);

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "dev-queue",
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    string message = $"Message from publisher N {counter}";

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                        routingKey: "dev-queue",
                        basicProperties: null,
                        body: body);

                    Console.WriteLine($"Message is sent into Default Exchange [N:{counter++}]");
                }
            }

            //Consumer
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "dev-queue",
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (sender, e) =>
                {
                    var body = e.Body;
                    var message = Encoding.UTF8.GetString(body.ToArray());
                    program.Message.Add(message);

                    Console.WriteLine(" Recived message: {0}", message);
                };

                channel.BasicConsume(queue: "dev-queue",
                    autoAck: true,
                    consumer: consumer);

                Console.WriteLine("Subscribed to the queue 'dev-queue'");
                Console.ReadLine();
            }

            // Postgres
            if (program.Message.Count != 0)
            {
                var connectionString = "Host=postgres;Username=guest;Password=guest;Database=postgredb";

                using var connectionDB = new NpgsqlConnection(connectionString);
                connectionDB.Open();

                // Adding data to table

                var cmd = new NpgsqlCommand();
                cmd.Connection = connectionDB;

                cmd.CommandText = "INSERT INTO messages(message_id, message) VALUES(1 ,@message)";
                cmd.Parameters.AddWithValue("message", program.Message[0]);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                Console.WriteLine("Data adding success!");
            }
        }
    }
}
