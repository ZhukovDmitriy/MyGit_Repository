using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Producer.RabbitMQ
{
    public interface IRabbitMqService
    {
        void SendMessage(object obj);
        void SendMessage(string message);
    }
}
