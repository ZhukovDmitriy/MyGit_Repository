using ApplicationForCash.Infrastructure.Concrete;
using ApplicationForCash.Models;
using ApplicationForCash.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApplicationForCash.Controllers
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

                    return RedirectToAction("Index", "RequestCash");
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
