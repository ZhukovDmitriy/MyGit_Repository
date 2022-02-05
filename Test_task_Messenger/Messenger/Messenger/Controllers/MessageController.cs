using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messenger.Models;
using Microsoft.AspNetCore.Http;
using Messenger.Infrastructure.Abstract;
using Messenger.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class MessageController : Controller
    {
        private IUserRepository userRepository;
        private IMessageRepository messageRepository;

        public MessageController(IUserRepository userRepo, IMessageRepository msgRepo)
        {
            userRepository = userRepo;
            messageRepository = msgRepo;
        }

        // Метод инициализирует модель представления - извлекает из БД пользователя вошедшего в систему
        // а также собирает коллекцию сообщений всех пользователей (сортирует по дате сообщения)
        public ViewResult Index()
        {
            int userID = HttpContext.Session.GetInt32("UserID").Value;

            UserMessagesViewModel viewModel = new UserMessagesViewModel
            {
                User = userRepository.Users.FirstOrDefault(u => u.UserID == userID),
                Messages = messageRepository.Messages.Include(m => m.User).OrderBy(m => m.Date)
            };

            return View(viewModel);
        }

        // Перегруженный метод обрабатывающий отправку сообщения пользователем
        // Создает новый объект Message, инициализирует все его свойства на основании
        // вошедшего пользователя и параметра: message - отправленное пользователем сообщение 
        // Передает объект userMessage для сохранения
        [HttpPost]
        public ActionResult Index(string message)
        {
            int userID = HttpContext.Session.GetInt32("UserID").Value;
            User user = userRepository.Users.FirstOrDefault(u => u.UserID == userID);

            Message userMessage = new Message
            {
                UserID = user.UserID,
                Content = message,
                Date = DateTime.Now
            };

            messageRepository.SaveMessage(userMessage);

            return RedirectToAction("Index");
        }
    }
}
