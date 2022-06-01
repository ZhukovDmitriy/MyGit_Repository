using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Producer.RabbitMQ
{
    public class RabbitMqService : IRabbitMqService
    {
        public void SendMessage(object obj)
        {
            var message = JsonSerializer.Serialize(obj);
            SendMessage(message);
        }

        public void SendMessage(string message)
        {
            // Облачный сервис
            // var factory = new ConnectionFactory() { Uri = new Uri("строка_подключения") };

            // Стандартный адрес локального сервера http://localhost:15672
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var chanel = connection.CreateModel())
            {
                chanel.QueueDeclare(queue: "MyQueue",
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                chanel.BasicPublish(exchange: "",
                    routingKey: "MyQueue",
                    basicProperties: null,
                    body: body);
            }
        }
    }
}
