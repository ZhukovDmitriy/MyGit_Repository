using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messenger.Models;

namespace Messenger.Infrastructure.Abstract
{
    // Интерфейс содержащий свойства и методы для работы с сообщениями от пользователя
    public interface IMessageRepository
    {
        IQueryable<Message> Messages { get; }

        void SaveMessage(Message message);
        void DeleteMessage(Message message);
    }
}
