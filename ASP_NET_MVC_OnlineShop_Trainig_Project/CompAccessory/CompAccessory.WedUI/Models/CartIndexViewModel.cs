using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompAccessory.Domain.Entites;

namespace CompAccessory.WedUI.Models
{
    public class CartIndexViewModel
    {
        // Передаем представлению которое будет отображать контент корзины две порции информации
        public Cart Cart { get; set; }              // Объект Cart
        // URL для отображения, когда пользователь щелкает на кнопке "Продолжить покупку"
        public string ReturnUrl { get; set; }
    }
}