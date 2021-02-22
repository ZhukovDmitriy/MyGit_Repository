using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreEngine.Domain.Abstract;
using StoreEngine.Domain.Entities;
using StoreEngine.WebUI.Models;

namespace StoreEngine.WebUI.Controllers
{
    //[Authorize]
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

        // Метод инициализирует модель объединяющию данные из двух таблиц при помощи навигационного свойства Category
        public ViewResult ProductsList()
        {
            AdminIndexViewModel model = new AdminIndexViewModel()
            {
                Products = repository.Products.Include(p => p.Category)
            };

            return View(model);
        }

        // Предоставляет представлению список категорий (на основании которых будут создаваться продукты соответствующей категории)
        public ViewResult ProductCreateList()
        {
            AdminIndexViewModel model = new AdminIndexViewModel
            {
                Categories = repository.Categories
            };

            return View(model);
        }

        // Инициализирует модель предоставляющую список категорий
        public ViewResult CategoriesList()
        {
            AdminIndexViewModel model = new AdminIndexViewModel
            {
                Products = repository.Products,
                Categories = repository.Categories
            };

            return View(model);
        }

        // Инициализирует все необходимые данные для редактирования конкретного продукта
        public ViewResult EditProduct(int productId, int categoryID)
        {
            CreateProductViewModel model = new CreateProductViewModel()
            {
                Product = repository.Products.FirstOrDefault(p => p.ProductID == productId),
                Category = repository.Categories.FirstOrDefault(p => p.CategoryID == categoryID),
                Images = repository.Images.Where(p => p.ProductID == productId).OrderBy(p => p.SortPosition).ToList(),
                AttributeValues = repository.AttributeValues.Include(p => p.Attribute)
                .Where(p => p.ProductID == productId).OrderBy(p => p.Attribute.SortPosition)
            };

            return View("EditProduct", model);
        }

        // Метод отвечает за обработку данных при создании или редактировани продукта
        [HttpPost]
        public ActionResult EditProduct(CreateProductViewModel model, HttpPostedFileBase[] imageUploads, List<string> attributeValue, List<int> imgID, List<int> newImgPos, List<int> onDelete)
        {
            bool existInDB = model.Product.ProductID == 0;
            bool existImgInDB = newImgPos != null;
            bool deleteImg = onDelete != null;

            if (deleteImg)
            {
                repository.DeleteImage(imgID, model.Product.ProductID);
            }

            List<Image> images = repository.Images.Where(p => p.ProductID == model.Product.ProductID)
                .OrderBy(p => p.SortPosition).ToList();

            if (images != null)
            {
                List<int> currentImgPos = images.Select(p => p.SortPosition).ToList();

                if (newImgPos != null)
                {
                    bool changeExistImg = currentImgPos.SequenceEqual(newImgPos);

                    if (!changeExistImg)
                    {
                        repository.SaveImagePosition(model.Product.ProductID, imgID);
                    }
                }
            }

            repository.SaveProduct(model.Product, model.Category);

            if (imageUploads[0] != null)
            {
                model.Images = new List<Image>();

                foreach (var img in imageUploads)
                {
                    Image newImage = new Image()
                    {
                        Name = img.FileName,
                        ImageData = new byte[img.ContentLength],
                        ImageMimeType = img.ContentType
                    };

                    img.InputStream.Read(newImage.ImageData, 0, img.ContentLength);

                    model.Images.Add(newImage);
                }

                repository.SaveImages(model.Product, model.Images, existImgInDB);
            }

            if (existInDB)
            {
                repository.CreateAttributesValues(attributeValue);
            }
            else
            {
                repository.SaveAttributesValues(model.Product.ProductID, attributeValue);
            }

            TempData["message"] = string.Format("Product {0} has been saved", model.Product.Name);

            return RedirectToAction("ProductsList");

        }

        // На основании переданного ID категории метод инициализирует модель, создавая новый продукт 
        // и собирает все аттрибуты соответствующие ID категории
        public ViewResult CreateProduct(int categoryId)
        {
            CreateProductViewModel model = new CreateProductViewModel
            {
                Product = new Product(),
                Category = repository.Categories.FirstOrDefault(p => p.CategoryID == categoryId),
                Attributes = repository.Attributes.Where(p => p.CategoryID == categoryId).OrderBy(p => p.SortPosition)
            };

            return View("EditProduct", model);
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
        public ActionResult RemoveProduct(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);

            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedProduct.Name);
            }

            return RedirectToAction("ProductsList");
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