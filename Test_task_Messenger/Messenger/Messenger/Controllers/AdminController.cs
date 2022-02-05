using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messenger.Infrastructure.Abstract;
using Messenger.Models;
using Messenger.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Controllers
{
    // Фильтр авторизации, допуск только для роли: Администратор
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IMessageRepository messageRepository;
        private IUserRepository userRepository;

        public AdminController(IMessageRepository msgRepo, IUserRepository usrRepo)
        {
            messageRepository = msgRepo;
            userRepository = usrRepo;
        }

        // Метод инициализирует модель представления - извлекает из БД пользователя вошедшего в административную область
        // а также собирает коллекцию сообщений всех пользователей
        // Принимает параметр: тип сортировки (по умолчанию сортирует сообщения по дате)
        public ViewResult Index(int sortType)
        {
            int userID = HttpContext.Session.GetInt32("UserID").Value;

            UserMessagesViewModel viewModel = new UserMessagesViewModel
            {
                User = userRepository.Users.FirstOrDefault(u => u.UserID == userID),

                // Сортировка по дате сообщение
                Messages = messageRepository.Messages.Include(m => m.User).OrderBy(m => m.Date)
            };

            // Сортировка по фамилии
            if (sortType == 2)
            {
                viewModel.Messages = messageRepository.Messages
                    .Include(m => m.User).OrderBy(m => m.User.FirstName);
            }
            // Сортировка по имени
            if (sortType == 3)
            {
                viewModel.Messages = messageRepository.Messages
                    .Include(m => m.User).OrderBy(m => m.User.LastName);
            }

            return View(viewModel);
        }

        // Метод извлекает в коллекцию данные о пользователях
        public ViewResult UserData()
        {
            IEnumerable<User> users = userRepository.Users.Include(u => u.Role);

            return View(users);
        }

        public ViewResult UserList()
        {
            IEnumerable<User> users = userRepository.Users.Include(u => u.Role);

            return View(users);
        }

        public ViewResult UserMessage(int userId)
        {
            UserMessagesViewModel viewModel = new UserMessagesViewModel
            {
                User = userRepository.Users.FirstOrDefault(u => u.UserID == userId),
                Messages = messageRepository.Messages.Include(m => m.User).Where(m => m.UserID == userId)
            };

            return View(viewModel);
        }

        // Перегруженный метод принимающий ID удаляемого объекта
        // Извлекает из БД сообщение и передает далее для удаления
        [HttpPost]
        public ActionResult RemoveMessage(int messageId)
        {
            Message removeMessage = messageRepository.Messages.FirstOrDefault(m => m.MessageID == messageId);

            messageRepository.DeleteMessage(removeMessage);

            return RedirectToAction("Index");
        }
    }
}
