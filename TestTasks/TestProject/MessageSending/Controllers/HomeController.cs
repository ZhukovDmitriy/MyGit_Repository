using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageSending.Models;

namespace MessageSending.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult SendingForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult SendingForm(ClientMessage clientMessage)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", clientMessage);
            }
            else
            {
                return View();
            }
        }
    }
}