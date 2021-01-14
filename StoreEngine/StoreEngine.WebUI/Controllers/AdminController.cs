using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreEngine.Domain.Abstract;
using StoreEngine.Domain.Entities;
using StoreEngine.WebUI.Models;

namespace StoreEngine.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Home()
        {
            return View();
        }

        public ViewResult ProductsList()
        {
            AdminIndexViewModel model = new AdminIndexViewModel
            {
                Products = repository.Products,
                Categories = repository.Categories
            };

            return View(model);
        }

        public ViewResult CategoriesList()
        {
            AdminIndexViewModel model = new AdminIndexViewModel
            {
                Products = repository.Products,
                Categories = repository.Categories
            };

            return View(model);
        }

        // Метод Edit для класса Product
        public ViewResult Edit(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }

                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);

                return RedirectToAction("CategoriesList");
            }
            else
            {
                // Что-то не так со значениями данных.
                return View(product);
            }
        }

        // Создание нового товара Product
        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        // Создание новой категории Category
        public ViewResult CreateCategory()
        {
            return View(new Category());
        }

        // Обрабатывает отправку формы, принимает List атрибутов в заданном порядке
        [HttpPost]
        public ActionResult CreateCategory(Category category, List<string> attribute)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCategory(category);
                repository.SaveAttributes(attribute);

                TempData["message"] = string.Format("Category {0} has been created", category.Name);
            }

            return RedirectToAction("CategoriesList");
        }

        // Метод предоставляет представлению данные для редактирования значений определенной категории и атрибутов этой категории  
        public ViewResult EditCategory(int categoryId)
        {
            CreateCategoryViewModel model = new CreateCategoryViewModel
            {
                Category = repository.Categories.FirstOrDefault(p => p.CategoryID == categoryId),
                Attributes = repository.Attributes.Where(p => p.CategoryID == categoryId).OrderBy(p => p.SortPosition).ToList()
            };

            return View(model);
        }

        // Метод обрабатывающий отправку формы,
        // в случае передачи параметру List<> attribute значений, 
        // выполняет вызов перегруженного метода добавляющий новые атрибуты к уже существующим атрибутам в БД определенной категории 
        [HttpPost]
        public ActionResult EditCategory(CreateCategoryViewModel model, List<string> attribute)
        {
            repository.SaveCategory(model.Category);
            repository.SaveAttributes(model.Attributes, model.Category);

            if (attribute != null)
            {
                repository.SaveAttributes(attribute, model.Category);
            }

            TempData["message"] = string.Format("Changes in category {0} have been saved", model.Category.Name);

            return RedirectToAction("CategoriesList");
        }

        // Метод предоставляет представлению данные для редактирование позиций атрибутов
        public ViewResult EditAttributesPosition(int categoryId)
        {
            CreateCategoryViewModel model = new CreateCategoryViewModel
            {
                Category = repository.Categories.FirstOrDefault(p => p.CategoryID == categoryId),
                Attributes = repository.Attributes.Where(p => p.CategoryID == categoryId).OrderBy(p => p.SortPosition).ToList()
            };

            return View(model);
        }

        // Обрабатывает отправку формы, принимает модель List<> Attributes с новым порядком позиций атрибутов
        [HttpPost]
        public ActionResult EditAttributesPosition(CreateCategoryViewModel model)
        {
            repository.SaveAttributesPosition(model.Attributes, model.Category);

            TempData["message"] = string.Format("Attributes position have been saved");

            return RedirectToAction("CategoriesList");
        }

        // Передает определенный товар Product для удаления, соответствующему методу из предметной области
        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);

            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedProduct.Name);
            }

            return RedirectToAction("CategoriesList");
        }

        // Передает определенную категорию Category для удаления, соответствующему методу из предметной области
        [HttpPost]
        public ActionResult RemoveCategory(int categoryId)
        {
            Category deletedCategory = repository.DeleteCategory(categoryId);

            if (deletedCategory != null)
            {
                TempData["message"] = string.Format("Category {0} was deleted", deletedCategory.Name);
            }

            return RedirectToAction("CategoriesList");
        }
    }
}