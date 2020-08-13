using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.Models;
using Portfolio.Infrastructure.Concrete;

namespace Portfolio.Controllers
{
    public class AccountController : Controller
    {
        FormsAuthProvider authProvider;

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            authProvider = new FormsAuthProvider();

            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Неверное имя пользователся или пароль");
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