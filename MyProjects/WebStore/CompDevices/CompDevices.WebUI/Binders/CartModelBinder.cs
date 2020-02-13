﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompDevices.Domain.Entities;

namespace CompDevices.WebUI.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Получить объект Cart из сеанса
            Cart cart = (Cart)controllerContext.HttpContext.Session[sessionKey];

            // Создать экземпляр Cart из сеанса
            if (cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }

            // Вернуть объект Cart
            return cart;
        }
    }
}