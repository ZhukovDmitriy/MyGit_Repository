using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompAccessory.Domain.Abstract;
using CompAccessory.Domain.Entites;
using CompAccessory.WedUI.Models;

namespace CompAccessory.WedUI.Controllers
{
    public class CartController : Controller
    {
        private IAccessoryRepository repository;            // Обьявляем ссылку на объект интерфейса
        private IOrderProcessor orderProcessor;

        // Используем конструктор для того, чтобы он требовал реализацию интерфейсов 
        // при создании экземляра CartController
        public CartController(IAccessoryRepository repo, IOrderProcessor proc)
        {
            repository = repo;
            orderProcessor = proc;
        }

        // PartialViewResult базовый класс используемый для отправки в ответ частичного представления
        public PartialViewResult Summary(Cart cart)
        {
            // PartialView визуализирует частичное представление, используя заданную модель
            return PartialView(cart);
        }

        // Метод действия обрабатывающий отправку POST формы, когда пользователь щелкает на кнопке "Подтвердить заказ"
        // Атрибут HttpPost означает, что метод будет вызываться для запроса POST - когда пользователь отправляет форму  
        // Метод запроса POST предназначен для запроса, при котором веб-сервер принимает данные, заключённые в тело сообщения, для хранения. 
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Завершено");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public ViewResult Checkout()
        {
            // Метод Checkout возвращает стандартное предстваление, передавая ему новый объект
            // ShippingDetails в качестве модели представления
            return View(new ShippingDetails());
        }

        // Метод Index применяется для отображения контента Cart 
        // по нажатию на кнопке "Добавить в корзину"
        // Возвращая объект ViewResult из метода действия, мы тем самым указываем MVC,
        // что нужно визуализировать представление.
        public ViewResult Index(Cart cart, string returnUrl)
        {
            // Вызов метода View возвращает объект ViewResult
            // Затем уже ViewResult производит рендеринг определенного представления в ответ.
            // В качестве параметра, метод View использует новый экземпляр класса CartIndexViewModel 
            // который используется в качестве модели во время визуализации представления.
            // При вызове метода View() имя файла представления не указывается, 
            // поэтому будет выбрано стандартное представление для метода действия.
            // Согласно настройкам по умолчанию, если представление не указано явным образом, 
            // то в качестве представления будет использоваться то, имя которого совпадает с именем метода действия в контроллере.
            return View(new CartIndexViewModel
            {
                // ===== Изменен (модифицирован) =====
                // Cart = GetCart(),
                // ===================================

                // Избавляемся от метода GetCart() переложив всю работу на наш связыватель модели (CartModelBinder)
                Cart = cart,

                ReturnUrl = returnUrl
            });
        }

        // Метод GetCart позволяет пользователю заводить корзину которая будет сохранятся между запросами,
        // то-есть корзина будет сохранять данные уже добавленных товаров в процессе работы с приложением
        private Cart GetCart()
        {
            // Извлекаем объект из состояния сеанса - считываем значения с ключом ["Cart"] в объекте Session
            Cart cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                // Добавляем объект в состояние сеанса, установкой значения для определенного ключа ["Cart"] в объекте Session
                Session["Cart"] = cart;
            }
            return cart;
        }

        // Был удален метод GetCart() и добавлен к каждому методу действия параметр Cart.
        // Когда инфраструктура MVC Framework получает запрос, требующий вызова, скажем, метода действия AddToCart,
        // она начинает с просмотра параметров для этого метода действия. Она берет список доступных связывателей и
        // пытается найти в нём тот, который может создать экземпляры каждого типа параметра.
        // Нашему специальному связывателю поручается создание объекта Cart и он делает это, взаимодействуя со средством
        // состояния сеанса. Между обращениями к нашему связывателю и стандартному связывателю инфраструктура MVC Framework 
        // создает набор параметров, требуемых для вызова метода действия. Это позволяет провести рефакторинг контроллера так,
        // чтобы он не имел никакого понятия о том, как создаются объекты Cart, когда поступают запросы.
        // RedirectToRouteResult - позволяет выполнить более детальную настройку перенаправлений. 
        // Он возвращается двумя методами: RedirectToAction и RedirectToRoute
        public RedirectToRouteResult AddToCart(Cart cart, int accessoryId, string returnUrl)
        {
            // Accessories - свойство доступа к интерфейсу перечеслителя IQueryable позволяющему перемещаться по данным в хранилище 
            // Метод FirstOrDefault возвращает первый объект из хранилища который соответствует заданному условию
            // или null в случае отсутствия таких объектов 
            // Далее объект из хранилища присваивается объекту класса Accessory
            Accessory accessory = repository.Accessories
            .FirstOrDefault(p => p.AccessoryID == accessoryId);

            if (accessory != null)
            {
                // ===== Изменен (модифицирован) =====
                // GetCart().AddItem(accessory, 1);
                // ===================================

                cart.AddItem(accessory, 1);
            }

            // Метод RedirectToAction позволяет перейти к определенному действию определенного контроллера. 
            // Он также позволяет задать передаваемые параметры: имя действия (метода действия) и значение маршрута
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int accessoryId, string returnUrl)
        {
            Accessory accessory = repository.Accessories
            .FirstOrDefault(p => p.AccessoryID == accessoryId);

            if (accessory != null)
            {
                // ===== модифицирован =====
                // GetCart().RemoveLine(accessory);
                // =========================

                cart.RemoveLine(accessory);
            }

            return RedirectToAction("Index", new { returnUrl });
        }


    }
}