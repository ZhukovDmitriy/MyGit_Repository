using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace DockerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Publisher
            var counter = 0;
            int timeToSleep = new Random().Next(1000, 3000);
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

                    Console.WriteLine(" Recived message: {0}", message);
                };

                channel.BasicConsume(queue: "dev-queue",
                    autoAck: true,
                    consumer: consumer);

                Console.WriteLine("Subscribed to the queue 'dev-queue'");
                Console.ReadLine();
            }
        }
    }
}
