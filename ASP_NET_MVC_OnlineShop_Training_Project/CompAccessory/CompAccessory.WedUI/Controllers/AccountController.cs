using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompAccessory.WedUI.Infrastructure.Abstract;
using CompAccessory.WedUI.Models;

namespace CompAccessory.WedUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;

        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        // Создаем две версии метода Login, на который производится сслыка в файле Web.config (loginUrl="~/Account/Login")

        // Первая версия будет визуализировать представление, которое содержит запрос на вход.
        public ViewResult Login()
        {
            return View();
        }

        // Вторая версия - обрабатывает запрос POST, когда пользователь отправляет учетные данные.
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            // Свойство IsValid объекта ModelState осуществляет валидацию внутри контроллера
            // Объект ModelState сохраняет все значения, которые пользователь ввел для свойств модели, 
            // а также все ошибки, связанные с каждым свойством и с моделью в целом. 
            // Если в объекте ModelState имеются какие-нибудь ошибки, то свойство ModelState.IsValid возвратит false
            if (ModelState.IsValid)
            {
                // Возвращаемым типом данных метода Authenticate является bool
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    // Неверное имя пользователя или пароль
                    ModelState.AddModelError("", "Неверное имя пользователя или пароль");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}