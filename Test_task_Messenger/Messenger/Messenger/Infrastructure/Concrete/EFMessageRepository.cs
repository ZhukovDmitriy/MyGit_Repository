using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messenger.Infrastructure.Abstract;
using Messenger.Models;

namespace Messenger.Infrastructure.Concrete
{
    // Класс хранилища, реализует интерфейс IMessageRepository
    // Использует экземпляр ApplicationDbContext для извлечения данных из БД
    public class EFMessageRepository : IMessageRepository
    {
        private ApplicationDbContext context;

        public EFMessageRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Message> Messages => context.Messages;

        // Метод сохраняет в БД сообщение пользователя
        // После, вызывает метод ограничивающий количество сохраняемых сообщений пользователем
        public void SaveMessage(Message message)
        {
            if (message != null)
            {
                context.Messages.Add(message);
                context.SaveChanges();
            }

            MessageLimiter(message.UserID, 10, 20);
        }

        // Метод удаляет из БД сообщение
        public void DeleteMessage(Message delMessage)
        {
            if (delMessage != null)
            {
                Message dbEntry = context.Messages.FirstOrDefault(m => m.MessageID == delMessage.MessageID);

                context.Messages.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        // Метод ограничивает сохраняемые в БД сообщения - путем удаления сообщений, 
        // в случае превышения разрешенного лимита
        // Параметры: 
        // userId - ID пользователя, используется для поиска количества сообщений конкретного пользователя
        // userLimit - ограничения на количество сообщений пользователя,
        // totalLimit - ограничения общего количества сообщений сохраняемого в БД
        public void MessageLimiter(int userId, int userLimit, int totalLimit)
        {
            // Количество сообщений конкретного пользователя в БД
            int userAmount = context.Messages.Where(u => u.UserID == userId).Count();

            // Общее количество сообщений всех пользователей
            int totalAmount = context.Messages.Count();

            if (userAmount > userLimit)
            {
                IEnumerable<Message> userMessages = context.Messages.Where(m => m.UserID == userId);

                Message removeMessage = userMessages.OrderBy(m => m.Date).FirstOrDefault();

                DeleteMessage(removeMessage);
            }

            if (totalAmount > totalLimit)
            {
                Message removeMessage = context.Messages.OrderBy(m => m.Date).FirstOrDefault();

                DeleteMessage(removeMessage);
            }
        }
    }
}
