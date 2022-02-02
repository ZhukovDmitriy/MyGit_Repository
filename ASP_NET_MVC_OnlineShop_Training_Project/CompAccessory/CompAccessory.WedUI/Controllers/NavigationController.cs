using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompAccessory.Domain.Abstract;

namespace CompAccessory.WedUI.Controllers
{
    // Создаем самодостаточный контроллер для управления навигационным меню, для многократного использования
    public class NavigationController : Controller
    {
        // Обьявляем ссылку на обьект интерфейса, предоставляющий удаленный доступ к базе данных
        private IAccessoryRepository repository;    

        // Добавляем конструктор принимающий в своем аргументе реализацию IAccessoryRepository
        // эта реализация будет предоставлена Ninject при создании экземпляра контроллера с использованием привязок
        public NavigationController(IAccessoryRepository repo)
        {
            repository = repo;
        }

        // Метод действия визуализирует навигационное меню 
        // и встраивает выводы из этого метода в компоновку
        public PartialViewResult Menu(string category = null)   // PartialViewResult базовый класс используемый для отправки в ответ частичного представления 
        {
            // ViewBag - это динамический объект, в котором можно устанавливать произвольные свойства, 
            // делая эти значения доступными в любом визуализироваемом представлении
            // тоесть это средство позволяет передавать данные из контроллера предствалению 
            // без использования моедели представления.
            // Динамически создаем свойство SelectedCategory в объекте ViewBag и 
            // устанавливаем его значение равным занчению параметра category
            ViewBag.SelectedCategory = category;  

            IEnumerable<string> categories = repository.Accessories
                .Select(x => x.Category)    // Операция Select определяет конкретный тип элементов, получаемых по запросу
                .Distinct()                 // Операция Distinct удаляет дублированные элементы из входной последовательности
                .OrderBy(x => x);

            // Дочеренее действие
            return PartialView(categories); // PartialView визуализирует частичное представление, используя заданную модель
        }
    }
}