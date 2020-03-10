using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompAccessory.Domain.Abstract;
using CompAccessory.Domain.Entites;

namespace CompAccessory.WedUI.Controllers
{
    // Контроллер CRUD (Create Read Update Delete) предоставляет способ управления товарами
    // Используем фильтр авторизации. Атрибут Authorize предоставляет доступ к методам действий 
    // контроллера, только если пользователь прошел аутентификацию
    [Authorize]
    public class AdminController : Controller
    {
        private IAccessoryRepository repository;

        public AdminController(IAccessoryRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Accessories);    // Отображаем все товары из хранилища
        }

        // Метод ищет товар с идентификатором, соответствующим значению параметра accessoryId
        // и передает его как объект модели представления
        public ViewResult Edit(int accessoryId)
        {
            Accessory accessory = repository.Accessories
                .FirstOrDefault(p => p.AccessoryID == accessoryId);

            return View(accessory);
        }

        // Проверяем, способен ли связыватель модели проверять достоверность данных, отправленных пользователем,
        // для чего читаем значение свойства ModelState.IsValid. Если с этим всё в порядке, мы сохраняем изменения 
        // в хранилище и затем вызываем метод действия Index для возврата пользователю списка товаров. Если с данными
        // связана какая-то проблема, мы снова визуализируем представление Edit, чтобы пользователь мог внести 
        // необходимые корректировки.
        // ActionResult представляет результат метода действия
        // Расширяем версию POST метода действия Edit, чтобы принимать загруженные данные изображения 
        // и сохранять их в базе данных. 
        // Добавляем новый параметр используемый MVC Framework для передачи данных загруженного файла 
        // HttpPostedFileBase предоставляет доступ к отдельным файлам, которые были отправлены клиентом
        [HttpPost]
        public ActionResult Edit(Accessory accessory, HttpPostedFileBase image)
        {
            // ModelState получает объект словаря состояния модели, содержащий состояние модели и проверку привязки модели.
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    // Копируем данные: new byte[image.ContentLength] 
                    // и тип MIME: image.ContentType из параметра image 
                    // в объект accessory.ImageData и accessory.ImageMimeType соответсвенно, 
                    // что в результате приводит к сохранению сведений в базе данных
                    // MIME (Multipurpose Internet Mail Extension, Многоцелевые расширения почты Интернета) 
                    // - спецификация для передачи по сети файлов различного типа: изображений, музыки, текстов, видео, архивов и др. 
                    // Указание MIME-типа используется в HTML обычно при передаче данных форм и вставки на страницу различных объектов.
                    accessory.ImageMimeType = image.ContentType;
                    accessory.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(accessory.ImageData, 0, image.ContentLength);
                }

                repository.SaveAccessory(accessory);
                // После записи изменений в хранилище мы сохраняем сообщение с применением средства TempData.
                // Объект TempData - это словарь пар "ключ/значение", похожий на используемые ранее данные сеанса
                // и ViewBag. Основное его отличие от данных сеанса в том, что в конце HTTP-запроса объект 
                // TempData удаляется.
                TempData["message"] = string.Format("изменения в аксессуаре \"{0}\" успешно сохранены", accessory.Name);

                // RedirectToAction перенаправляет заданное действие, используя имя действия.
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных.
                return View(accessory);
            }
        }

        public ViewResult Create()
        {
            // Метод действия не визуализирует своё стандартное представление. Вместо этого в нем указано,
            // что должно применятся представление Edit. Также внедряем новый объект Accessory в качестве 
            // модели представления, так что представление Edit заполняется пустыми полями
            return View("Edit", new Accessory());
        }

        [HttpPost]
        public ActionResult Delete(int accessoryID)
        {
            Accessory deleteAccessory = repository.DeleteAccessory(accessoryID);
            if (deleteAccessory != null)
            {
                TempData["message"] = string.Format("аксессуар \"{0}\" успешно удален", deleteAccessory.Name);
            }

            return RedirectToAction("Index");
        }
    }
}