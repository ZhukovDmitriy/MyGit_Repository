using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Concrete;

namespace Portfolio.Controllers
{
    public class FormController : Controller
    {
        public EmailOrderProcessor emailOrderProcessor;

        public ViewResult Checkout()
        {
            return View("Contacts", new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails shippingDetails)
        {
            emailOrderProcessor = new EmailOrderProcessor();

            if (ModelState.IsValid)
            {
                emailOrderProcessor.ProcessOrder(shippingDetails);

                string msg = shippingDetails.Name;
                TempData["Message"] = msg;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                string msgError = "При отправке возникла ошибка!";
                TempData["MessageError"] = msgError;

                return RedirectToAction("Index", "Home");
            }
        }
    }
}