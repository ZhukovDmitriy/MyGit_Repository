using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompAccessory.Domain.Entites;

namespace CompAccessory.WedUI.Binders
{
    // Инфраструктура MVC Framework использует систему "привязки модели" для создания объектов C# 
    // из запросов HTTP и передаёт эти объекты в виде параметров в методы действия.
    // Подобным образом MVC обрабатывает, например, формы. Затем MVC Framework просматривает 
    // параметры целевого метода действия и применяет "связыватель модели" для получения значений
    // из элементов ввода формы и преобразования их к типам параметров с соответсвующими именами.

    // Создаем специальный связыватель модели, который будет получать объект Cart,
    // содержащийся внутри данных сеанса. В результате инфраструктура MVC Framework получит 
    // возможность создавать объекты Cart и передавать их в виде параметров методам дейстия класса CartController.
    // IModelBinder определяет методы, которые требуются для связывателя модели

    public class CartModelBinder : IModelBinder     
    {
        private const string sessionKey = "Cart";

        // В интерфейсе IModelBinder определен один метод BindModel
        // Метод BindModel принимает два параметра, чтобы обеспечить возможность создания объекта модели предметной области.
        // Параметр ControllerContext предоставляет доступ ко всей информации, которую имеет класс контроллера,
        // включая детали запроса от клиента. 
        // Параметр ModelBindingContext дает сведения об объекте модели, который требуется создать,
        // а также ряд инструментов для упрощения процесса привязки. 
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Класс ControllerContext имеет свойство HttpContext, которое в свою очередь, содержит свойство Session,
            // позволяющее получать и устанавливать данные сеанса.

            // Получить объект Cart из сеанса
            Cart cart = (Cart)controllerContext.HttpContext.Session[sessionKey];

            // Объект Cart получается за счет чтения значения для ключа из данных сеанса и создания экземпляра Cart,
            // если оказалось, что он не существует.

            // Создать экземпляр Cart, если его не обнаружено в данных сеанса
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