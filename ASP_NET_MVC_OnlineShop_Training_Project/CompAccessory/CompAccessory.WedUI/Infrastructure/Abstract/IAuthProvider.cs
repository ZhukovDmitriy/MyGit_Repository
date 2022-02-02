using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompAccessory.WedUI.Infrastructure.Abstract
{
    // Использование средства аутентификации с помощью форм требует вызова 
    // двух статических методов класса System.Web.Security.FormsAuthentication:
    // Authenticate и SetAuthCookie
    // Вызов статических методов в методах действий затрудняет модульное тестирование контроллера.
    // Наилучшим способом решения упомянутой проблемы предусамтривает отделение контроллера от 
    // класса со статическими методами с использованием интерфейса.
    // Определяем интерфейс поставщика аутентификации
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}
