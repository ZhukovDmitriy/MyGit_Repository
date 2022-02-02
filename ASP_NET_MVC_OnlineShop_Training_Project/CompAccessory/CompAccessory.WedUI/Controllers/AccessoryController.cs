using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompAccessory.Domain.Abstract;    // импортируем пространства имен позволяющие ссылаться на классы хранилища 
using CompAccessory.Domain.Entites;     // не указывая их полностью определенные имена
using CompAccessory.WedUI.Models;

namespace CompAccessory.WedUI.Controllers
{
    public class AccessoryController : Controller
    {
        private IAccessoryRepository repository;          // Обьявляем ссылку на обьект интерфейса 
        public int PageSize = 4;                          // Поле указывающее количество товаров на одной странице

        // Конструктор принимает параметр accessoryRepository 
        // позволяющий Ninject внедрять зависимость для хранилища при создании экземпляра класса контроллера
        public AccessoryController(IAccessoryRepository accessoryRepository)
        {
            repository = accessoryRepository;
        }

        // Добавляем метод действия List, который будет визуализировать представление отображающее полный список товаров
        public ViewResult List(string category, int page = 1)   // Необязательный параметр, в случае вызова метода List без параметра 
        {                                               // ему будет передан необязательный пареметр и будет выведена первая страница

            // ========== Метод View был изменен ==========
            // Передавая методу View список объектов Accessories, мы снабжаем инфраструктуру данными,
            // которыми необходимо заполнить объект Model в строго тиризированном представлении
            //  return View(repository.Accessories          // Получаем объекты Accessories из хранилища
            //      .OrderBy(p => p.AccessoryID)            // Оператор OrderBy принимает критерий сортировки и сортирует набор данных по возрастанию
            //      .Skip((page - 1) * PageSize)            // Пропускаем товары, которые располагаются до начала нашей старницы, 
            //      .Take(PageSize));                       // а затем выбираем то количество товаров, которое заданно полем PageSize
            // Метод Skip() пропускает определенное количество элементов
            // Метод Take() извлекает определенное число элементов
            // [Пример (Всего в базе 12 товаров)] "вызываем" третюю страницу page = 3, 
            // .Skip((3 - 1) * PageSize) = 8 товаров пропускаем, а затем выводим PageSize = 4 
            // ========== Метод View был изменен ==========

            // Метод List использует класс AccessoriesListViewModel для снабжения представления сведениями о товарах,
            // отображаемых на страницах и информацией о разбиении на страницы
            // Эти изменение обеспечивают передачу объекта AccessoriesListViewModel представлению в качестве данных модели.
            AccessoriesListViewModel model = new AccessoriesListViewModel
            {
                // Создаем объект model экземпляра класса AccessoriesListViewModel
                // предоставляя значения свойствам Accessories интерфейса IEnumerable
                // и свойству PageInfo экземпляра класса PageInfo
                Accessories = repository.Accessories
                // Метод Where() выбирает объекты из хранилища на основе заданного параметра string category,
                // но так как, при первом запуске приложения параметр category не задан (не выбран как активный) тоесть string = string.Empty 
                // то category == null, а значит результатом условия будет true. 
                // В этом случае метод Where() выбирает все обьекты из хранилища без условно! 
                // Передавая дальнейшую сортировку следующим методам: OrderBy и т.д. 
                // Еслиже выбрать категорию: string category = "Клавиатуры" то,
                // метод Where() перебирает объекты хранилища, сравнивая каждое свойство объекта p.Category 
                // с заданным значением category, а значит выбирает объекты хранилища на основе заданного параметра category
                // и передает эти объекты дальнейшим методам сортировки... 
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.AccessoryID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PageInfo = new PageInfo
                {
                    // Присваеваем параметрам класса модели представления PageInfo значения определенные в этом классе контроллера
                    CurrentPage = page,
                    ItemsPerPages = PageSize,
                    // Корректировка счетчика страниц
                    TotalItems = category == null ?
                    // Если условие = true, то TotalItems = общему количеству элементов хранилища
                    repository.Accessories.Count() :    // Count() - возвращает количество элементов последовательности  
                    // Если условие = false, то из хранилища возвращается количество элементов
                    // свойства Category которых совпадают с параметром category
                    repository.Accessories.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category      // Устанавливаем значение свойства 
            };
            return View(model);
        }

        // FileContentResult: отправляет клиенту массив байтов, считанный из файла.
        // Метод File возвращает объект FileContentResult используя содержимое файла и тип файла
        public FileContentResult GetImage(int accessoryId)
        {
            Accessory accessory = repository.Accessories.FirstOrDefault(p => p.AccessoryID == accessoryId);

            if (accessory != null)
            {
                return File(accessory.ImageData, accessory.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}