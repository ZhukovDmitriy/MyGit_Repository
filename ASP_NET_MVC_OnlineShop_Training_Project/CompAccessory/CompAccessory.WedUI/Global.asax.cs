using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;                          // Необходимо добавить в проект .WebUI - Microsoft.AspNet.WebApi 
using CompAccessory.WedUI.Infrastructure;
using CompAccessory.WedUI.App_Start;
using CompAccessory.Domain.Entites;
using CompAccessory.WedUI.Binders;

namespace CompAccessory.WedUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // Изначально WebApiConfig отсутсвует в проекте - необходимо добавить в папку App_Start класс WebApiConfig.cs (с контентом)
            WebApiConfig.Register(GlobalConfiguration.Configuration);   
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Указываем инфраструктуре MVC, что для создания объектов контроллера должен применяться класс NinjectController 
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            // Сообщаем инфраструктуре MVC Framework о том, что она может использовать класс CartModelBinder для 
            // создания экземпляра Cart. ModelBinders предоставляет глобальный доступ к связывателям моделей для приложений
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());

            // Один из способов отключения проверки достоверности на стороне клиента
            // Другой способ находится в файле Web.config (корневой каталог CompAccessory.WedUI)
            // HtmlHelper.ClientValidationEnabled = false;
            // HtmlHelper.UnobtrusiveJavaScriptEnabled = false;
        }
    }
}
