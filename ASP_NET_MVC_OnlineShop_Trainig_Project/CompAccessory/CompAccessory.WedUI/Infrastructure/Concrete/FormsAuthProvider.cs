using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;  // Содержит классы, используемые для реализации безопасности ASP.NET в приложениях веб-сервера
using CompAccessory.WedUI.Infrastructure.Abstract;

namespace CompAccessory.WedUI.Infrastructure.Concrete
{
    // Реализация интерфейса IAuthProvider которая будет служить 
    // оболочкой для статических методов класса FormsAuthentication
    public class FormsAuthProvider : IAuthProvider
    {
        // Реализация метода Authenticate вызывает статические методы FormsAuthentication, 
        // которые мы хоти держать за пределами контроллера
        public bool Authenticate(string username, string password)
        {
            // Метод Authenticate проверяет имя пользователя и пароль для учетных данных,
            // хранящихся в файле конфигурации приложения Web.config (user name="admin" password="secret")
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                // Метод SetAuthCookie добавляет cookie-набор к ответу, предназаченному для браузера, 
                // чтобы пользователям не понадобилось проходить аутентификацию каждый раз, когда они делают запрос.
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return result;
        }
    }
}