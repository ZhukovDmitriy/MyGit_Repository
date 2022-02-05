using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messenger.Infrastructure.Concrete;
using Messenger.Models;
using Messenger.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Messenger.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext context;

        public AccountController(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        // Метод обрабатывает отправленные данные пользователем при авторизации
        // Если учетные данные верны, создает сессию и хранит в ней данные пользователя  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);

                if (user != null)
                {
                    await Authenticate(user);

                    HttpContext.Session.SetInt32("UserID", user.UserID);
                    HttpContext.Session.SetInt32("RoleID", user.Role.RoleID);
                    HttpContext.Session.SetString("LastName", user.LastName);
                    HttpContext.Session.SetString("FirstName", user.FirstName);

                    return RedirectToAction("Index", "Message");
                }

                ModelState.AddModelError("", "Неверный логин или пароль!");
            }

            return View(model);
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.RoleName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(id));
        }

        public async Task<ActionResult> Logout()
        {
            // Удаляем аутентификационные куки
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
