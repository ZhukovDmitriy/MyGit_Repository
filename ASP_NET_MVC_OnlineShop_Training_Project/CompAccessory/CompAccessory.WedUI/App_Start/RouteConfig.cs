using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CompAccessory.WedUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Сводка по маршрутам
            routes.MapRoute(null, "",                       // / Выводит первую страницу списка товаров всех категорий
                new
                {
                    controller = "Accessory",
                    action = "List",
                    category = (string)null,
                    page = 1
                }
                );

            routes.MapRoute(null, "Page{page}",             // /Page2 Выводит указанную страницу, показывая элементы всех категорий
                new { controller = "Accessory", action = "List", category = (string)null },
                new { page = @"\d+" }
                );

            routes.MapRoute(null, "{category}",             // /Клавиатуры Отображает первую страницу элементов указанной категории
                new { controller = "Accessory", action = "List", page = 1 }
                );

            routes.MapRoute(null, "{category}/Page{page}",  // /Клавиатуры/Page2 Отображает заданную страницу элементов указанной категории
                new { controller = "Accessory", action = "List" },
                new { page = @"\d+" }
                );

            routes.MapRoute(null, "{controller}/{action}"); // /Anything/Else вызывает метод действия Else контроллера Anything

            // ========== Изменен ==========
            // Создаем схему по шаблону "компонуемых URL" - URL понятный пользователю
            // тоесть: http://localhost/Page2 в отличае от строки запроса http://localhost/?page=2
            //routes.MapRoute(
            //    name: null,
            //    url: "Page{page}",
            //    defaults: new { Controller = "Accessory", action = "List" });

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",

            // Указываем инфраструктуре MVC, что поступающие запросы к корневому каталогу нашего сайта (http://mysite/)
            // должны быть отображенны на метод действия List класса AccessoryController
            // Изменения направляют запросы, адресованные стандартному URL, в определенный нами метод действия
            //defaults: new { controller = "Accessory", action = "List", id = UrlParameter.Optional });
            // ========== Изменен ==========
        }
    }
}
