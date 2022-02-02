using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;   // Пространство имен предоставляет классы, используемые с маршрутизацией URL-адресов, 
                            // позволяющей использовать URL-адреса, не соответствующие физическим файлам.
using Ninject;
using CompAccessory.Domain.Abstract;
using CompAccessory.Domain.Entites;
using CompAccessory.Domain.Concrete;

using System.Configuration; // Содержит типы, которые обеспечивают программную модель для работы с данными конфигурации.

using CompAccessory.WedUI.Infrastructure.Abstract;
using CompAccessory.WedUI.Infrastructure.Concrete;

namespace CompAccessory.WedUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        // Объявляем ссылку на объект ninjectKernel ядра Ninject интерфейса IKernel.
        // Объект ninjectKernel предназначен для взаимодействия с Ninject,
        // и запрашивания реализаций интерфейсов.
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();   // Распределяем память для объекта - конструированием нового экземпляра класса StandardKernal   
            AddBindings();                          // Конструируем метод AddBindings устанавливающий отношения(связи) между интерфейсом и классом
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            // Здесь размещаются привязки
            // Привязываем с помощью Ninject имитированное хранилище к реальному хранилищу
            ninjectKernel.Bind<IAccessoryRepository>().To<EFAccessoryReposirory>();
            // Привязка указывает библиотеке Ninject о том, что для обслуживания запросов к интерфейсу IAccesorryRepository
            // необходимо создавать экземпляры класса EFAccessoryRepository
            // (было настроенно отношение между интерфейсом в приложении и классом реализации с которым требуется работать)

            // Создаем объект emailSettings экземпляра класса EmailSettings
            EmailSettings emailSettings = new EmailSettings
            {
                // Указываем значени только одного свойства EmailSettings по имени WriteAsFile.
                // Значение этого свойства читается с использованием свойства ConfigurationManager.AppSettings,
                // которое позволяет получать доступ к настройкам приложения, размещенным в файле Web.config (из корневой папки проекта)
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };

            // Имея реализацию интерфейса IOrderProcessor классом EmailOrderProcessor и средства для её настройки, 
            // можно воспользоваться Ninject для создания экземпляров этой реализации. 

            // Настраиваем отношения между интерфейсом в приложении и классом реализии этого интерфейса с которым требуется работать.
            // Данное выражение сообщает Ninject о том, что когда запрашивается реализация интерфейса IOrderProcessor,
            // этот запрос должен быть обслужен путем создания нового экземпляра класса EmailOrderProcessor.
            ninjectKernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                // объект emailSettings используется в Ninject-методе WithConstructorArgument для того,
                // чтобы у нас была возможность внедрять этот объект в конструкторе класса EmailOrderProcessor,
                // когда создаются новые экземпляры класса EmailOrderProcessor для обслуживания запросов интерфейса IOrderProcessor.
                .WithConstructorArgument("settings", emailSettings);

            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}